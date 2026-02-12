using System;
using System.Threading;
using System.Windows.Input;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using _4RTools.Utils;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _4RTools.Model
{

    public class AutoSwitch : Action
    {
        public static string ACTION_NAME_AUTOSWITCH = "AutoSwitch";
        public const string item = "ITEM";
        public const string skill = "SKILL";
        public const string nextItem = "NEXTITEM";

        private _4RThread thread;
        public int delay { get; set; } = 500;
        public int switchEquipDelay { get; set; } = 3000;
        public Dictionary<EffectStatusIDs, Key> buffMapping = new Dictionary<EffectStatusIDs, Key>();
        public List<AutoSwitchConfig> autoSwitchMapping = new List<AutoSwitchConfig>();
        public List<AutoSwitchConfig> autoSwitchGenericMapping = new List<AutoSwitchConfig>();

        public List<EffectStatusIDs> autoSwitchOrder { get; set; } = new List<EffectStatusIDs>();
        [JsonIgnore]
        public List<String> listCities { get; set; }

        public class AutoSwitchConfig
        {
            public EffectStatusIDs skillId { get; set; }
            public Key itemKey { get; set; }
            public Key skillKey { get; set; }
            public Key nextItemKey { get; set; }

            public AutoSwitchConfig(EffectStatusIDs id, Key key, String type = null)
            {
                this.skillId = id;
                if (type != null)
                {
                    switch (type)
                    {
                        case item:
                            this.itemKey = key;
                            break;

                        case skill:
                            this.skillKey = key;
                            break;

                        case nextItem:
                            this.nextItemKey = key;
                            break;
                    }

                }
            }


        }

        public void Start()
        {
            Client roClient = ClientSingleton.GetClient();
            if (roClient != null)
            {
                Stop();
                if (this.listCities == null || this.listCities.Count == 0) this.listCities = GlobalVariablesHelper.CityList;
                this.thread = AutoSwitchThread(roClient);
                _4RThread.Start(this.thread);
            }
        }


        public _4RThread AutoSwitchThread(Client c)
        {
            bool equipVajra = false;
            int contVajra = 0;
            int contPet = 0;
            bool procVajra = false;
            List<EffectStatusIDs> effectStatusProcMapping = new List<EffectStatusIDs>
            {
                EffectStatusIDs.PROVOKE,
                EffectStatusIDs.OVERTHRUST,
                EffectStatusIDs.RECOGNIZEDSPELL,
                EffectStatusIDs.GN_CARTBOOST,
                EffectStatusIDs.MINDBREAKER
            };
            var currentPet = EffectStatusIDs.PROVOKE;
            bool equipedPet = false;
            bool procPet = true;
            _4RThread autoSwitchThread = new _4RThread(_ =>
            {
                procVajra = false;
                List<AutoSwitchConfig> skillClone = new List<AutoSwitchConfig>(this.autoSwitchMapping.Where(x => x.itemKey != Key.None));
                List<AutoSwitchConfig> skillCloneGeneric = new List<AutoSwitchConfig>(this.autoSwitchGenericMapping.Where(x => x.itemKey != Key.None));
                string currentMap = c.ReadCurrentMap();
                bool hasAntiBot = hasBuff(c, EffectStatusIDs.ANTI_BOT);
                bool stopBuffsCity = ProfileSingleton.GetCurrent().UserPreferences.stopBuffsCity;
                bool isInCityList = this.listCities.Contains(currentMap);
                bool hasOpenChat = c.ReadOpenChat();
                bool stopOpenChat = ProfileSingleton.GetCurrent().UserPreferences.stopWithChat;
                var autoSwitchHeal = ProfileSingleton.GetCurrent().AutoSwitchHeal;
                bool canSwitch = !hasAntiBot
                && !(hasOpenChat && stopOpenChat)
                && !(stopBuffsCity && isInCityList);

                if (KeyboardHookHelper.HandlePriorityKey())
                    return 0;

                if (canSwitch)
                {
                    if (c.IsSpBelow(ProfileSingleton.GetCurrent().AutoSwitchHeal.spPercent) && c.IsHpAbove(10))
                    {
                        switchPet();
                        equipedPet = false;
                        procPet = true;
                    }
                    for (int i = 1; i < Constants.MAX_BUFF_LIST_INDEX_SIZE; i++)
                    {
                        uint currentStatus = c.CurrentBuffStatusCode(i);

                        if (currentStatus == uint.MaxValue) { continue; }

                        EffectStatusIDs status = (EffectStatusIDs)currentStatus;

                        if (effectStatusProcMapping.Exists(x => x == status) && status == currentPet)
                        {
                            if (equipedPet)
                            {
                                equipedPet = false;
                                this.equipNextItem(autoSwitchMapping.FirstOrDefault(x => x.skillId == status).nextItemKey);
                                procPet = true;
                            }
                        }

                        if (autoSwitchMapping.Exists(x => x.skillId == status))
                        {
                            skillClone = skillClone.Where(skill => skill.skillId != status).ToList();
                        }

                        if (autoSwitchGenericMapping.Exists(x => x.skillId == status))
                        {
                            skillCloneGeneric = skillCloneGeneric.Where(skill => skill.skillId != status).ToList();
                        }

                        if (status == EffectStatusIDs.THURISAZ || status == EffectStatusIDs.FIGHTINGSPIRIT)
                        {

                            if (equipVajra)
                            {
                                equipVajra = false;
                                this.equipNextItem(autoSwitchMapping.FirstOrDefault(x => x.skillId == EffectStatusIDs.THURISAZ).nextItemKey);
                            }
                            skillClone = validadeVajraSkills(skillClone, status);
                            procVajra = true;
                        }
                    }
                    var order = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchOrder;
                    skillClone.AddRange(skillCloneGeneric);

                    skillClone = skillClone
                    .OrderBy(p => order.IndexOf(p.skillId) == -1 ? int.MaxValue : order.IndexOf(p.skillId))
                    .ToList();

                    skillClone = skillClone.Where(p => p == skillClone.FirstOrDefault() || !order.Contains(p.skillId)).ToList();

                    foreach (var skill in skillClone)
                    {
                        if (effectStatusProcMapping.Contains(skill.skillId) && skill.itemKey != Key.None)
                        {
                            contPet++;

                            preventErrorsPet(ref contPet, ref equipedPet, ref procPet, skill);

                            if (!equipedPet && procPet)
                            {
                                currentPet = skill.skillId;
                                Thread.Sleep(switchEquipDelay);
                                this.useAutobuff(skill.itemKey, skill.skillKey);
                                equipedPet = true;
                                procPet = false;
                            }
                        }
                        else if (skill.skillId == EffectStatusIDs.THURISAZ || skill.skillId == EffectStatusIDs.FIGHTINGSPIRIT)
                        {
                            contVajra++;

                            if (contVajra > 50) { contVajra = 0; equipVajra = false; }

                            if (!equipVajra)
                            {
                                Thread.Sleep(delay);
                                this.useAutobuff(skill.itemKey, skill.skillKey);
                                equipVajra = true;
                            }
                        }
                        else if (c.ReadCurrentSp() > 8)
                        {
                            this.useAutobuff(skill.itemKey, skill.skillKey);
                            Thread.Sleep(switchEquipDelay);
                            this.equipNextItem(skill.nextItemKey);
                            equipVajra = false;
                            Thread.Sleep(switchEquipDelay);
                        }
                    }
                }
                Thread.Sleep(delay);
                return 0;

            });

            return autoSwitchThread;
        }
        private List<AutoSwitchConfig> validadeVajraSkills(List<AutoSwitchConfig> skillClone, EffectStatusIDs status)
        {
            if (status == EffectStatusIDs.THURISAZ)
            {
                if (autoSwitchMapping.Exists(x => x.skillId == EffectStatusIDs.FIGHTINGSPIRIT))
                {
                    skillClone = skillClone.Where(skill => skill.skillId != EffectStatusIDs.FIGHTINGSPIRIT).ToList();
                }
            }

            if (status == EffectStatusIDs.FIGHTINGSPIRIT)
            {
                if (autoSwitchMapping.Exists(x => x.skillId == EffectStatusIDs.THURISAZ))
                {
                    skillClone = skillClone.Where(skill => skill.skillId != EffectStatusIDs.THURISAZ).ToList();
                }
            }

            return skillClone;
        }

        private bool hasBuff(Client c, EffectStatusIDs buff)
        {
            for (int i = 1; i < Constants.MAX_BUFF_LIST_INDEX_SIZE; i++)
            {
                uint currentStatus = c.CurrentBuffStatusCode(i);
                if (currentStatus == (int)buff) { return true; }
            }
            return false;
        }

        private void preventErrorsPet(ref int contPet, ref bool equipedPet, ref bool procPet, AutoSwitchConfig skill)
        {
            if (contPet > 100)
            {
                contPet = 0;
                equipedPet = false;
                procPet = true;
                var key = autoSwitchMapping.FirstOrDefault(x => x.skillId == skill.skillId).nextItemKey != Key.None ? autoSwitchMapping.FirstOrDefault(x => x.skillId == skill.skillId).nextItemKey : autoSwitchMapping.FirstOrDefault(x => x.skillId == skill.skillId).itemKey;
                this.equipNextItem(key);
                Thread.Sleep(1000);
            }
        }

        public void ClearKeyMapping()
        {
            buffMapping.Clear();
        }

        public void Stop()
        {
            if (this.thread != null)
            {
                _4RThread.Stop(this.thread);
            }
        }

        public string GetConfiguration()
        {
            return JsonConvert.SerializeObject(this);
        }

        public string GetActionName()
        {
            return ACTION_NAME_AUTOSWITCH;
        }

        private void useAutobuff(Key item, Key skill)
        {
            if ((item != Key.None) && !Keyboard.IsKeyDown(Key.LeftAlt) && !Keyboard.IsKeyDown(Key.RightAlt))
                Interop.PostMessage(ClientSingleton.GetClient().process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, FormUtils.ConvertKeyToWinFormsKey(item), 0);
            Thread.Sleep(switchEquipDelay);
            if ((skill != Key.None) && !Keyboard.IsKeyDown(Key.LeftAlt) && !Keyboard.IsKeyDown(Key.RightAlt))
                Interop.PostMessage(ClientSingleton.GetClient().process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, FormUtils.ConvertKeyToWinFormsKey(skill), 0);
        }

        private void equipNextItem(Key next)
        {
            if ((next != Key.None) && !Keyboard.IsKeyDown(Key.LeftAlt) && !Keyboard.IsKeyDown(Key.RightAlt))
                Interop.PostMessage(ClientSingleton.GetClient().process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, FormUtils.ConvertKeyToWinFormsKey(next), 0);
        }

        public void SetAutoSwitchOrder(List<EffectStatusIDs> buffs)
        {
            this.autoSwitchOrder = buffs;
        }

        private void pressKey(Key key)
        {
            if ((key != Key.None) && !Keyboard.IsKeyDown(Key.LeftAlt) && !Keyboard.IsKeyDown(Key.RightAlt))
            {
                Interop.PostMessage(ClientSingleton.GetClient().process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, FormUtils.ConvertKeyToWinFormsKey(key), 0);
            }
        }
        private void switchPet()
        {
            pressKey(ProfileSingleton.GetCurrent().AutoSwitchHeal.itemKey);
            Thread.Sleep(1500);
            foreach (var i in Enumerable.Range(0, ProfileSingleton.GetCurrent().AutoSwitchHeal.qtdSkill))
            {
                pressKey(ProfileSingleton.GetCurrent().AutoSwitchHeal.skillKey);
                Thread.Sleep(ProfileSingleton.GetCurrent().AutoSwitchHeal.switchDelay);
            }
            pressKey(ProfileSingleton.GetCurrent().AutoSwitchHeal.nextItemKey);
            Thread.Sleep(ProfileSingleton.GetCurrent().AutoSwitch.switchEquipDelay);
        }
    }
}
