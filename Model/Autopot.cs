using System;
using System.ComponentModel;
using _4RTools.Utils;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace _4RTools.Model
{

    public class Autopot : Action
    {

        public static string ACTION_NAME_AUTOPOT = "Autopot";
        public static string ACTION_NAME_AUTOPOT_YGG = "AutopotYgg";
        public const string FIRSTHP = "firstHP";
        public const string FIRSTSP = "firstSP";
        public Key hpKey { get; set; }
        public int hpPercent { get; set; }
        public Key spKey { get; set; }
        public int spPercent { get; set; }
        public int delay { get; set; } = 15;
        public int delayYgg { get; set; } = 50;
        public bool stopWitchFC { get; set; } = false;
        public string firstHeal { get; set; } = FIRSTHP;
        public Key hpEquipBefore { get; set; }
        public Key hpEquipAfter { get; set; }

        public string actionName { get; set; }
        private _4RThread thread;
        [JsonIgnore]
        public List<String> listCities { get; set; }

        public Autopot() { }
        public Autopot(string actionName)
        {
            this.actionName = actionName;
        }

        public Autopot(Key hpKey, int hpPercent, int delay, Key spKey, int spPercent, Key tiKey)
        {
            this.delay = delay;

            // HP
            this.hpKey = hpKey;
            this.hpPercent = hpPercent;

            // SP
            this.spKey = spKey;
            this.spPercent = spPercent;

        }

        public void Start()
        {
            Client roClient = ClientSingleton.GetClient();
            if (roClient != null)
            {
                Stop();
                int hpPotCount = 0;
                if (this.listCities == null || this.listCities.Count == 0) this.listCities = LocalServerManager.GetListCities();
                this.thread = new _4RThread(_ => AutopotThreadExecution(roClient, hpPotCount));
                _4RThread.Start(this.thread);
            }
        }


        private int AutopotThreadExecution(Client roClient, int hpPotCount)
        {
            if (KeyboardHookHelper.HandlePriorityKey())
                return 0;


            if (canHeal(roClient))
            {
                bool hasCriticalWound = hasBuff(roClient, EffectStatusIDs.CRITICALWOUND);
                if (firstHeal.Equals(FIRSTHP))
                {
                    healHP(roClient, hpPotCount, hasCriticalWound);
                }
                else
                {
                    healSP(roClient, hpPotCount, hasCriticalWound);
                }
            }


            Thread.Sleep(this.delay);
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

        private void healHP(Client roClient, int hpPotCount, bool hasCriticalWound)
        {
            bool equipedBefore = false;
            if (roClient.IsHpBelow(hpPercent) && this.actionName == ACTION_NAME_AUTOPOT && ((!this.stopWitchFC && hasCriticalWound) || !hasCriticalWound))
            {
                pressKey(this.hpEquipBefore);
                pressKey(this.hpEquipBefore);
                equipedBefore = true;
            }
            while (roClient.IsHpBelow(hpPercent))
            {
                if (!canHeal(roClient))
                    return;
                if (KeyboardHookHelper.HandlePriorityKey())
                    return;
                if (this.actionName == ACTION_NAME_AUTOPOT_YGG)
                {
                    pressKey(this.hpKey);
                    hpPotCount++;
                }
                else if (this.actionName == ACTION_NAME_AUTOPOT && ((!this.stopWitchFC && hasCriticalWound) || !hasCriticalWound))
                {
                    pressKey(this.hpKey);
                    hpPotCount++;
                }
                if (hpPotCount > 3 && roClient.IsSpBelow(spPercent))
                {
                    hpPotCount = 0;
                    pressKey(this.spKey);
                    return;
                }
                Thread.Sleep(this.delay);
            }
            if (equipedBefore)
            {
                pressKey(this.hpEquipAfter);
                pressKey(this.hpEquipAfter);
            }
            if (roClient.IsSpBelow(spPercent))
            {
                hpPotCount = 0;
                pressKey(this.spKey);
                Thread.Sleep(this.delay);
                return;
            }
        }

        private void healSP(Client roClient, int hpPotCount, bool hasCriticalWound)
        {
            while (roClient.IsSpBelow(spPercent))
            {
                if (!canHeal(roClient))
                    return;  
                if (KeyboardHookHelper.HandlePriorityKey())
                    return;
                pressKey(this.spKey);
                hpPotCount++;

                if (hpPotCount > 3 && roClient.IsHpBelow(hpPercent))
                {
                    if (this.actionName == ACTION_NAME_AUTOPOT_YGG)
                    {
                        pressKey(this.hpKey);
                        hpPotCount++;
                    }
                    else if (this.actionName == ACTION_NAME_AUTOPOT && ((!this.stopWitchFC && hasCriticalWound) || !hasCriticalWound))
                    {
                        pressKey(this.hpKey);
                        hpPotCount++;
                    }
                }
                Thread.Sleep(this.delay);
            }
            if (roClient.IsHpBelow(hpPercent))
            {
                if (this.actionName == ACTION_NAME_AUTOPOT_YGG)
                {
                    pressKey(this.hpKey);
                    hpPotCount++;
                }
                else if (this.actionName == ACTION_NAME_AUTOPOT && ((!this.stopWitchFC && hasCriticalWound) || !hasCriticalWound))
                {
                    pressKey(this.hpKey);
                    hpPotCount++;
                }
            }
        }

        private void pressKey(Key key)
        {
            Keys k = (Keys)Enum.Parse(typeof(Keys), key.ToString());
            if ((k != Keys.None) && !Keyboard.IsKeyDown(Key.LeftAlt) && !Keyboard.IsKeyDown(Key.RightAlt))
            {
                Interop.PostMessage(ClientSingleton.GetClient().process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, k, 0); // keydown
                Interop.PostMessage(ClientSingleton.GetClient().process.MainWindowHandle, Constants.WM_KEYUP_MSG_ID, k, 0); // keyup
            }
        }
        private bool canHeal(Client roClient)
        {
            string currentMap = roClient.ReadCurrentMap();
            bool hasAntiBot = hasBuff(roClient, EffectStatusIDs.ANTI_BOT);
            bool isCompetitive = hasBuff(roClient, EffectStatusIDs.COMPETITIVA);
            bool stopHealCity = ProfileSingleton.GetCurrent().UserPreferences.stopHealCity;
            bool isInCityList = this.listCities.Contains(currentMap);
            bool hasOpenChat = roClient.ReadOpenChat();
            bool stopOpenChat = ProfileSingleton.GetCurrent().UserPreferences.stopWithChat;

            bool canHeal = !hasAntiBot
                && !isCompetitive
                && !(hasOpenChat && stopOpenChat)
                && !(stopHealCity && isInCityList);
            return canHeal;
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
            return this.actionName != null ? this.actionName : ACTION_NAME_AUTOPOT;
        }

    }
}
