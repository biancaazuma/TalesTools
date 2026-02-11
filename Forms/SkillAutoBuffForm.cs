using System;
using System.Windows.Forms;
using _4RTools.Utils;
using _4RTools.Model;
using System.Windows.Input;
using System.Collections.Generic;

namespace _4RTools.Forms
{
    public partial class SkillAutoBuffForm : Form, IObserver
    {

        private List<BuffContainer> skillContainers =  new List<BuffContainer>();

        public SkillAutoBuffForm(Subject subject)
        {
            this.KeyPreview = true;
            InitializeComponent();

            skillContainers.Add(new BuffContainer(this.ArcherSkillsGP, Buff.GetArcherSkills()));
            skillContainers.Add(new BuffContainer(this.SwordmanSkillGP, Buff.GetSwordmanSkill()));
            skillContainers.Add(new BuffContainer(this.MageSkillGP, Buff.GetMageSkills()));
            skillContainers.Add(new BuffContainer(this.MerchantSkillsGP, Buff.GetMerchantSkills()));
            skillContainers.Add(new BuffContainer(this.ThiefSkillsGP, Buff.GetThiefSkills()));
            skillContainers.Add(new BuffContainer(this.AcolyteSkillsGP, Buff.GetAcolyteSkills()));
            skillContainers.Add(new BuffContainer(this.TKSkillGroupBox, Buff.GetTaekwonSkills()));
            skillContainers.Add(new BuffContainer(this.NinjaSkillsGP, Buff.GetNinjaSkills()));
            skillContainers.Add(new BuffContainer(this.GunsSkillsGP, Buff.GetGunsSkills()));

            new BuffRenderer(skillContainers, toolTip1, ProfileSingleton.GetCurrent().AutobuffSkill.actionName, subject).doRender();
            subject.Attach(this);

        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.PROFILE_CHANGED:
                    BuffRenderer.doUpdate(new Dictionary<EffectStatusIDs, Key>(ProfileSingleton.GetCurrent().AutobuffSkill.buffMapping), this);
                    ConfigureDelay();
                    break;
                case MessageCode.TURN_OFF:
                    ProfileSingleton.GetCurrent().AutobuffSkill.Stop();
                    break;
                case MessageCode.TURN_ON:
                    ProfileSingleton.GetCurrent().AutobuffSkill.Start();
                    break;
            }
        }

        private void ConfigureDelay()
        {
            int configuredDelay = ProfileSingleton.GetCurrent().AutobuffSkill.delay;
            int minDelay = (int)this.numericDelay.Minimum;
            if (configuredDelay < minDelay)
            {
                configuredDelay = minDelay;
                ProfileSingleton.GetCurrent().AutobuffSkill.delay = configuredDelay;
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutobuffSkill);
            }
            this.numericDelay.Value = configuredDelay;
        }
        private void btnResetAutobuff_Click(object sender, EventArgs e)
        {
            ProfileSingleton.GetCurrent().AutobuffSkill.ClearKeyMapping();
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutobuffSkill);
            BuffRenderer.doUpdate(new Dictionary<EffectStatusIDs, Key>(ProfileSingleton.GetCurrent().AutobuffSkill.buffMapping), this);
            this.numericDelay.Value = 100;
        }

        private void numericDelay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ProfileSingleton.GetCurrent().AutobuffSkill.delay = Convert.ToInt16(this.numericDelay.Value);
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutobuffSkill);
                this.ActiveControl = null;
            }
            catch { }
        }
    }
}
