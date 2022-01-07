using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFirewallHelper;
using System.Windows.Input;
using WK.Libraries.HotkeyListenerNS;
using System.Security.Principal;

namespace LagSwitch
{
    public partial class Form1 : Form
    {
        IFirewallRule rule;
        HotkeyListener hkl = new HotkeyListener();
        Hotkey hotkey;

        public Form1()
        {
            if (!isAdmin())
            {
                while(MessageBox.Show("This program needs admin privileges! :(", "", MessageBoxButtons.OK) != DialogResult.OK) { 

                }

                System.Environment.Exit(0);
            }

            InitializeComponent();
            hkl.HotkeyPressed += Hkl_HotkeyPressed;

            // load settings
            pathShow.Text = Properties.Settings.Default.path;
            timeInput.Value = Properties.Settings.Default.timer;
            try
            {
                KeysConverter kc = new KeysConverter();
                Keys key = (Keys)kc.ConvertFromString(Properties.Settings.Default.hotkey);
                SetGlobalHotkey(key);
            } catch { }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var path = openFileDialog.FileName;
            pathShow.Text = path;

            Properties.Settings.Default.Upgrade();

            // save path
            Properties.Settings.Default.path = path;
            Properties.Settings.Default.Save();
        }

        private void lagBtn_Click(object sender, EventArgs e)
        {
            Lag();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            FirewallManager.Instance.Rules.Remove(rule);
            lagBtn.Enabled = true;
        }

        private void shortcutInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void shortcutInput_KeyDown(object sender, KeyEventArgs e)
        {
            Keys modifierKeys = e.Modifiers;

            Keys pressedKey = e.KeyData ^ modifierKeys; //remove modifier keys

            if (pressedKey != Keys.Escape)
            {
                //do stuff with pressed and modifier keys
                var converter = new KeysConverter();
                var keysString = converter.ConvertToString(e.KeyData);

                SetGlobalHotkey(e.KeyData);

                // save hotkey
                Properties.Settings.Default.hotkey = keysString;
                Properties.Settings.Default.Save();
            } else
            {
                // remove focus
                ActiveControl = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Hkl_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            if (e.Hotkey == hotkey)
            {
                Lag();
            }
        }

        private void SetGlobalHotkey (Keys keys)
        {
            // hotkey
            hkl.Remove(hotkey);
            hotkey = new Hotkey(keys & Keys.Modifiers, keys & ~Keys.Modifiers);
            hkl.Add(hotkey);

            var converter = new KeysConverter();
            var keysString = converter.ConvertToString(keys);
            shortcutInput.Text = keysString;
        }

        private void Lag ()
        {
            if (shortcutInput.Focused) return;

            rule = FirewallManager.Instance.CreateApplicationRule(
                FirewallProfiles.Domain | FirewallProfiles.Private | FirewallProfiles.Public,
                @"A-LagSwitch",
                FirewallAction.Block,
                pathShow.Text
            );
            rule.Direction = FirewallDirection.Inbound | FirewallDirection.Outbound;
            FirewallManager.Instance.Rules.Add(rule);
            timer.Enabled = true;
            lagBtn.Enabled = false;
        }

        private void timeInput_ValueChanged(object sender, EventArgs e)
        {
            // set timer
            timer.Interval = ((int)timeInput.Value);

            // save timer
            Properties.Settings.Default.timer = timeInput.Value;
            Properties.Settings.Default.Save();
        }

        bool isAdmin()
        {
            bool isAdmin;
            try
            {
                //get the currently logged in user
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch
            {
                isAdmin = false;
            }

            return isAdmin;
        }
    }
}
