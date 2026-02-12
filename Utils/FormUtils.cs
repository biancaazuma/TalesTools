using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;

namespace _4RTools.Utils
{
    public class FormUtils
    {

        public static void OnKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                TextBox textBox = (TextBox)sender;
                Key thisk;

                thisk = (Key)Enum.Parse(typeof(Key), e.KeyCode.ToString());

                switch (thisk)
                {
                    case Key.Escape:
                    case Key.Back:
                        textBox.Text = Key.None.ToString();
                        break;
                    default:
                        textBox.Text = thisk.ToString();
                        break;
                }
                textBox.Parent.Focus();
                e.Handled = true;
            }
            catch { }
        }

        public static bool IsValidKey(Key key)
        {
            return (key != Key.Back && key != Key.Escape && key != Key.None);
        }

        public static void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        public static IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        private static void resetForm(Control control)
        {
            IEnumerable<Control> texts = GetAll(control, typeof(TextBox));
            IEnumerable<Control> checks = GetAll(control, typeof(CheckBox));
            IEnumerable<Control> combos = GetAll(control, typeof(ComboBox));
            IEnumerable<Control> numericUpDown = GetAll(control, typeof(NumericUpDown));

            foreach (Control c in texts)
            {
                TextBox textBox = (TextBox)c;
                textBox.Text = Key.None.ToString();
            }

            foreach (Control c in checks)
            {
                CheckBox checkBox = (CheckBox)c;
                checkBox.Checked = false;
                checkBox.CheckState = 0;
            }

            foreach (Control c in combos)
            {
                ComboBox comboBox = (ComboBox)c;
                if (comboBox.Items.Count > 0)
                    comboBox.SelectedIndex = 0;
            }

            foreach (Control n in numericUpDown)
            {
                NumericUpDown numeric = (NumericUpDown)n;
                numeric.Value = numeric.Minimum;
            }
        }

        private static void resetCheckboxForm(Control control)
        {

            IEnumerable<Control> checks = GetAll(control, typeof(CheckBox));
            IEnumerable<Control> combos = GetAll(control, typeof(ComboBox));

            foreach (Control c in checks)
            {
                CheckBox checkBox = (CheckBox)c;
                checkBox.Checked = false;
            }

            foreach (Control c in combos)
            {
                ComboBox comboBox = (ComboBox)c;
                if (comboBox.Items.Count > 0)
                    comboBox.SelectedIndex = 0;
            }
        }

        public static void ResetCheckboxForm(Form form)
        {
            resetCheckboxForm(form);
        }

        public static void ResetForm(Form form)
        {
            resetForm(form);
        }

        public static void ResetForm(Control form)
        {
            resetForm(form);
        }

        public static void ResetForm(Panel panel)
        {
            resetForm(panel);
        }

        public static void ResetForm(GroupBox group)
        {
            resetForm(group);
        }

        public static int EnsureMinimumDelay(NumericUpDown control, int configuredDelay, Action<int> persistAction = null)
        {
            int min = (int)control.Minimum;
            if (configuredDelay < min)
            {
                configuredDelay = min;
                persistAction?.Invoke(configuredDelay);
            }

            if (control.InvokeRequired)
            {
                control.Invoke((Action)(() => control.Value = configuredDelay));
            }
            else
            {
                control.Value = configuredDelay;
            }

            return configuredDelay;
        }

    }
    public static class EnumExtensions
    {
        public static string ToDescriptionString(this EffectStatusIDs val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }

        public static EffectStatusIDs ToEffectStatusId(this String val)
        {

            EffectStatusIDs t = Enum.GetValues(typeof(EffectStatusIDs))
                .Cast<EffectStatusIDs>()
                .FirstOrDefault(v => v.GetDescription() == val);
            return t;
        }


    }
    public static class KeyboardHookHelper
    {
        public static Key PriorityKey { get; set; } = Key.None;
        public static IntPtr GameWindowHandle { get; set; }
        public static int PriorityDelay { get; set; }
        private static DateTime _lastSent = DateTime.MinValue;
        private static bool _wasPressed = false;
        private static readonly object _lock = new object();


        public static bool HandlePriorityKey()
        {
            bool isDown = PriorityKey != Key.None && Keyboard.IsKeyDown(PriorityKey);
            lock (_lock)
            {
                if (isDown && !_wasPressed)
                {
                    _wasPressed = true;
                    _lastSent = DateTime.Now;
                    Keys winKey = (Keys)Enum.Parse(typeof(Keys), PriorityKey.ToString());
                    Thread.Sleep(PriorityDelay);
                    Interop.PostMessage(GameWindowHandle, Constants.WM_KEYDOWN_MSG_ID, winKey, 0);
                    Thread.Sleep(1);
                    Interop.PostMessage(GameWindowHandle, Constants.WM_KEYUP_MSG_ID, winKey, 0);
                    return true;
                }
                else if (!isDown)
                {
                    // Reseta o estado quando a tecla é solta
                    _wasPressed = false;
                }
            }
            return isDown;
        }
    }
    public static class GlobalVariablesHelper
    {
        public static List<String> CityList { get; set; }

    }
}
