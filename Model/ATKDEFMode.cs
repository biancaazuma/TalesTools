using System;
using Newtonsoft.Json;
using _4RTools.Utils;
using System.Threading;
using System.Drawing;
using System.Windows.Input;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace _4RTools.Model
{
    public enum ATKDEFEnum
    {
        ATK,
        DEF,
    }

    public class EquipConfig
    {
        public int id;
        public int ahkDelay { get; set; } = 10;
        public int switchDelay { get; set; } = 50;
        public Key keySpammer { get; set; }
        public bool keySpammerWithClick { get; set; } = true;
        public Dictionary<string, Key> defKeys { get; set; } = new Dictionary<string, Key>();
        public Dictionary<string, Key> atkKeys { get; set; } = new Dictionary<string, Key>();
        public EquipConfig() { }
        public EquipConfig(int id)
        {
            this.id = id;
            this.defKeys = new Dictionary<string, Key>();
            this.atkKeys = new Dictionary<string, Key>();
        }

        public EquipConfig(EquipConfig macro)
        {
            this.id = macro.id;
            this.ahkDelay = macro.ahkDelay;
            this.switchDelay = macro.switchDelay;
            this.keySpammer = macro.keySpammer;
            this.keySpammerWithClick = macro.keySpammerWithClick;
            this.defKeys = new Dictionary<string, Key>(macro.defKeys);
            this.atkKeys = new Dictionary<string, Key>(macro.atkKeys);

        }
        public EquipConfig(int id, Key trigger)
        {
            this.id = id;
            this.keySpammer = trigger;
            this.defKeys = new Dictionary<string, Key>();
            this.atkKeys = new Dictionary<string, Key>();
        }
    }

    public class ATKDEFMode : Action
    {
        public static string ACTION_NAME_ATKDEF = "ATKDEFMode";
        private _4RThread thread;
        public List<EquipConfig> equipConfigs { get; set; } = new List<EquipConfig>();

        public ATKDEFMode(int macroLanes)
        {
            for (int i = 1; i <= macroLanes; i++)
            {
                equipConfigs.Add(new EquipConfig(i, Key.None));

            }
        }

        public string GetActionName()
        {
            return ACTION_NAME_ATKDEF;
        }

        public string GetConfiguration()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void Start()
        {
            Client roClient = ClientSingleton.GetClient();
            if (roClient != null)
            {
                Stop();
                this.thread = new _4RThread(_ => AHKThreadExecution(roClient));
                _4RThread.Start(this.thread);
            }
        }

        private int AHKThreadExecution(Client roClient)
        {
            if (!hasBuff(roClient, EffectStatusIDs.ANTI_BOT) && !(roClient.ReadOpenChat() && ProfileSingleton.GetCurrent().UserPreferences.stopWithChat))
            {
                foreach (EquipConfig equipConfig in this.equipConfigs)
                {
                    bool equipAtkItems = false;
                    bool equipDefItems = false;
                    bool ammo = false;

                    if (equipConfig.keySpammer != Key.None && Keyboard.IsKeyDown(equipConfig.keySpammer)
                       && !Keyboard.IsKeyDown(Key.LeftAlt) && !Keyboard.IsKeyDown(Key.RightAlt))
                    {
                        Keys thisk = toKeys(equipConfig.keySpammer);

                        while (Keyboard.IsKeyDown(equipConfig.keySpammer))
                        {
                            if (hasBuff(roClient, EffectStatusIDs.ANTI_BOT) || (roClient.ReadOpenChat() && ProfileSingleton.GetCurrent().UserPreferences.stopWithChat))
                            {
                                return 0;
                            }
                            if (!equipAtkItems)
                            {
                                foreach (Key key in equipConfig.atkKeys.Values)
                                {
                                    Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, toKeys(key), 0); //Equip ATK Items
                                    Thread.Sleep(equipConfig.switchDelay);
                                }
                                equipAtkItems = true;
                            }

                            getOffRein(roClient);

                            if (equipConfig.keySpammerWithClick)
                            {
                                Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, thisk, 0);
                                Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_LBUTTONDOWN, 0, 0);
                                autoSwitchAmmo(roClient, ref ammo);
                                Thread.Sleep(1);
                                Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_LBUTTONUP, 0, 0);
                                Thread.Sleep(equipConfig.ahkDelay);
                            }
                            else
                            {
                                Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, thisk, 0);
                                Thread.Sleep(equipConfig.ahkDelay);
                            }
                        }
                        if (!equipDefItems)
                        {
                            foreach (Key key in equipConfig.defKeys.Values)
                            {
                                Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, toKeys(key), 0); //Equip DEF Items
                                Thread.Sleep(equipConfig.switchDelay);
                            }
                            equipDefItems = true;
                        }
                    }
                }
            }
            return 0;
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

        private void autoSwitchAmmo(Client roClient, ref bool ammo)
        {
            if (ProfileSingleton.GetCurrent().UserPreferences.switchAmmo)
            {
                if (ProfileSingleton.GetCurrent().UserPreferences.ammo1Key.ToString() != String.Empty
                    && ProfileSingleton.GetCurrent().UserPreferences.ammo2Key.ToString() != String.Empty)
                {
                    if (ammo == false)
                    {
                        Key key = ProfileSingleton.GetCurrent().UserPreferences.ammo1Key;
                        Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, toKeys(key), 0);
                        ammo = true;
                    }
                    else
                    {
                        Key key = ProfileSingleton.GetCurrent().UserPreferences.ammo2Key;
                        Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, toKeys(key), 0);
                        ammo = false;
                    }

                }
            }
        }

        public void getOffRein(Client c)
        {
            if (ProfileSingleton.GetCurrent().UserPreferences.getOffRein && isRidding(c))
            {
                if (ProfileSingleton.GetCurrent().UserPreferences.getOffReinKey.ToString() != String.Empty)
                {
                    Key key = ProfileSingleton.GetCurrent().UserPreferences.getOffReinKey;
                    Interop.PostMessage(c.process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, toKeys(key), 0);
                }
            }
        }

        public bool isRidding(Client c)
        {
            for (int i = 1; i < Constants.MAX_BUFF_LIST_INDEX_SIZE; i++)
            {
                uint currentStatus = c.CurrentBuffStatusCode(i);
                if (currentStatus == (int)EffectStatusIDs.RIDDING) { return true; }
            }
            return false;
        }

        public void AddSwitchItem(int id, string dictKey, Key k, string type)
        {
            var equips = equipConfigs.FirstOrDefault(x => x.id == id);

            Dictionary<string, Key> copy = type == "DEF" ? equips.defKeys : equips.atkKeys;

            if (copy.ContainsKey(dictKey))
            {
                RemoveSwitchEntry(id, dictKey, type);
            }

            if (k != Key.None)
            {
                copy.Add(dictKey, k);
            }

        }

        public void RemoveSwitchEntry(int id, string dictKey, string type)
        {
            var equips = equipConfigs.FirstOrDefault(x => x.id == id);
            Dictionary<string, Key> copy = type == "DEF" ? equips.defKeys : equips.atkKeys;
            copy.Remove(dictKey);
        }

        private Keys toKeys(Key k)
        {
            return FormUtils.ConvertKeyToWinFormsKey(k);
        }

        public void Stop()
        {
            if (this.thread != null)
            {
                _4RThread.Stop(this.thread);
            }
        }
    }
}
