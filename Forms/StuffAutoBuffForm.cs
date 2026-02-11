using System;
using System.Windows.Forms;
using System.Windows.Input;
using System.Collections.Generic;
using _4RTools.Utils;
using _4RTools.Model;

namespace _4RTools.Forms
{
    public partial class StuffAutoBuffForm : Form, IObserver
    {
        private List<BuffContainer> stuffContainers = new List<BuffContainer>();

        public StuffAutoBuffForm(Subject subject)
        {
            InitializeComponent();
            stuffContainers.Add(new BuffContainer(this.PotionsGP, Buff.GetPotionsBuffs()));
            stuffContainers.Add(new BuffContainer(this.ElementalsGP, Buff.GetElementalsBuffs()));
            stuffContainers.Add(new BuffContainer(this.BoxesGP, Buff.GetBoxesBuffs()));
            stuffContainers.Add(new BuffContainer(this.FoodsGP, Buff.GetFoodBuffs()));
            stuffContainers.Add(new BuffContainer(this.ScrollBuffsGP, Buff.GetScrollBuffs()));
            stuffContainers.Add(new BuffContainer(this.EtcGP, Buff.GetETCBuffs()));

            new BuffRenderer(stuffContainers, toolTip1, ProfileSingleton.GetCurrent().AutobuffStuff.actionName, subject).doRender();

            subject.Attach(this);
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.PROFILE_CHANGED:
                    BuffRenderer.doUpdate(new Dictionary<EffectStatusIDs, Key>(ProfileSingleton.GetCurrent().AutobuffStuff.buffMapping), this);
                    ConfigureDelay();
                    break;
                case MessageCode.TURN_OFF:
                    ProfileSingleton.GetCurrent().AutobuffStuff.Stop();
                    break;
                case MessageCode.TURN_ON:
                    ProfileSingleton.GetCurrent().AutobuffStuff.Start();
                    break;
            }
        }

        private void ConfigureDelay()
        {
            int configuredDelay = ProfileSingleton.GetCurrent().AutobuffStuff.delay;
            int minDelay = (int)this.numericDelay.Minimum;
            if (configuredDelay < minDelay)
            {
                configuredDelay = minDelay;
                ProfileSingleton.GetCurrent().AutobuffStuff.delay = configuredDelay;
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutobuffStuff);
            }
            this.numericDelay.Value = configuredDelay;
        }

        private void btnResetAutobuff_Click(object sender, EventArgs e)
        {
            ProfileSingleton.GetCurrent().AutobuffStuff.ClearKeyMapping();
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutobuffStuff);
            BuffRenderer.doUpdate(new Dictionary<EffectStatusIDs, Key>(ProfileSingleton.GetCurrent().AutobuffStuff.buffMapping), this);
            this.numericDelay.Value = 100;
        }

        private void numericDelay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ProfileSingleton.GetCurrent().AutobuffStuff.delay = Convert.ToInt16(this.numericDelay.Value);
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutobuffStuff);
            }
            catch { }
        }
    }
}
