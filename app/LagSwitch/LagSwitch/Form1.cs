using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using WK.Libraries.HotkeyListenerNS;
using System.Security.Principal;
using LagSwitch.States;

namespace LagSwitch
{
    public partial class MainForm : Form
    {
        SettingsDataLayer _settingsDataLayer;
        HotkeyService _hotkeyService;
        LagService _lagService;

        AlwaysOnTop _alwaysOnTopWindow;

        SettingsState latestSettings = new SettingsState();

        public MainForm(
            SettingsDataLayer settingsDataLayer,
            HotkeyService hotkeyService,
            LagService lagService,
            AlwaysOnTop alwaysOnTop
        )
        {
            _lagService = lagService;
            _settingsDataLayer = settingsDataLayer;
            _hotkeyService = hotkeyService;
            _alwaysOnTopWindow = alwaysOnTop;

            // check if user has admin privileges
            if (!Utils.isAdmin())
            {
                while (
                    MessageBox.Show(
                        "This program needs admin privileges! :(", 
                        "", 
                        MessageBoxButtons.OK
                    ) != DialogResult.OK
                );
                System.Environment.Exit(0);
            }

            // init
            InitializeComponent();
            InitDependecies();
        }

        private void InitDependecies()
        {
            _lagService.OnStatusChange += OnLagStatusChanged;
            _hotkeyService.HotkeyListeners += HotkeyPressed;
            _settingsDataLayer.AddListener(OnSettingsChanged);
        }

        private void OnSettingsChanged(object sender, SettingsState status)
        {
            latestSettings = status;

            pathShow.Text = status.path;
            timeInput.Value = status.timeout;
            shortcutInput.Text = status.hotkeyString;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var path = openFileDialog.FileName;
            _settingsDataLayer.SetPath(path);
        }

        private void lagBtn_Click(object sender, EventArgs e)
        {
            _lagService.Lag(pathShow.Text, (int)timeInput.Value);
        }

        public void shortcutInput_KeyDown(object sender, KeyEventArgs eventArgs)
        {
            eventArgs.Handled = true;
            eventArgs.SuppressKeyPress = true;

            //remove modifier keys
            Keys pressedKey = eventArgs.KeyData ^ eventArgs.Modifiers; 

            // check if pressed key is not esc nor enter
            if (pressedKey != Keys.Escape && pressedKey != Keys.Enter && pressedKey != Keys.Return)
            {
                _settingsDataLayer.SetHotkey(eventArgs.KeyData);
            } else
            {
                // remove focus
                ActiveControl = null;
            }
        }

        private void HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            if (!shortcutInput.Focused)
            {
                _lagService.Lag(pathShow.Text, (int)timeInput.Value);
            }
        }

        public void timeInput_ValueChanged(object sender, EventArgs e)
        {
            _settingsDataLayer.SetTimeout(timeInput.Value);
        }

        void OnLagStatusChanged (object sender, bool isLagging)
        {
            lagBtn.Enabled = !isLagging;
        }

        private void AlwaysOnTopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (alwaysOnTopCheckBox.Checked)
            {
                _alwaysOnTopWindow.Show();
            } else
            {
                _alwaysOnTopWindow.Hide();
            }
        }
    }
}
