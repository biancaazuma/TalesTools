using System;
using System.Threading;
using System.Windows.Input;
using System.Windows.Forms;
using Newtonsoft.Json;
using _4RTools.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace _4RTools.Model
{
    public class AutoRefreshSpammer : Action
    {
        private string ACTION_NAME = "AutoRefreshSpammer";

        public Dictionary<int, MacroKey> skillTimer = new Dictionary<int, MacroKey>();
        [JsonIgnore]
        public List<String> listCities { get; set; }

        private _4RThread thread1;
        private _4RThread thread2;
        private _4RThread thread3;
        private _4RThread thread4;

        public void Start()
        {
            Client roClient = ClientSingleton.GetClient();
            if (roClient != null)
            {
                Stop();

                if (this.listCities == null || this.listCities.Count == 0) this.listCities = LocalServerManager.GetListCities();

                this.thread1 = new _4RThread((_) => AutoRefreshThreadExecution(roClient, skillTimer[1].delay, skillTimer[1].key));
                this.thread2 = new _4RThread((_) => AutoRefreshThreadExecution(roClient, skillTimer[2].delay, skillTimer[2].key));
                this.thread3 = new _4RThread((_) => AutoRefreshThreadExecution(roClient, skillTimer[3].delay, skillTimer[3].key));
                this.thread4 = new _4RThread((_) => AutoRefreshThreadExecution(roClient, skillTimer[4].delay, skillTimer[4].key));

                _4RThread.Start(this.thread1);
                _4RThread.Start(this.thread2);
                _4RThread.Start(this.thread3);
                _4RThread.Start(this.thread4);
            }
        }

        private int AutoRefreshThreadExecution(Client roClient, int delay, Key rKey)
        {
            if (!hasBuff(roClient, EffectStatusIDs.ANTI_BOT) && !(roClient.ReadOpenChat() && ProfileSingleton.GetCurrent().UserPreferences.stopWithChat))
            {
                string currentMap = roClient.ReadCurrentMap();
                if (!ProfileSingleton.GetCurrent().UserPreferences.stopBuffsCity || this.listCities.Contains(currentMap) == false)
                {
                    if (rKey != Key.None)
                    {
                        Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, FormUtils.ConvertKeyToWinFormsKey(rKey), 0);
                    }
                }
            }
            Thread.Sleep(delay * 1000);
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

        public void Stop()
        {
            if (this.thread1 != null)
            {
                _4RThread.Stop(this.thread1);
            }
            if (this.thread2 != null)
            {
                _4RThread.Stop(this.thread2);
            }
            if (this.thread3 != null)
            {
                _4RThread.Stop(this.thread3);
            }
            if (this.thread4 != null)
            {
                _4RThread.Stop(this.thread4);
            }
        }

        public string GetConfiguration()
        {
            return JsonConvert.SerializeObject(this);
        }

        public string GetActionName()
        {
            return ACTION_NAME;
        }
    }
}
