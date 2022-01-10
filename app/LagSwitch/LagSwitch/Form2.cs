using LagSwitch.States;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LagSwitch
{
    public partial class AlwaysOnTop : Form
    {
        SettingsState latestSettings = new SettingsState();

        SettingsDataLayer _settingsDataLayer;
        HotkeyService _hotkeyService;
        LagService _lagService;

        public AlwaysOnTop(
            SettingsDataLayer settingsDataLayer,
            HotkeyService hotkeyService,
            LagService lagService
        )
        {
            _settingsDataLayer = settingsDataLayer;
            _hotkeyService = hotkeyService;
            _lagService = lagService;

            InitializeComponent();
            InitDependecies();
        }

        private void InitDependecies()
        {
            _settingsDataLayer.AddListener(OnSettingsChanged);
            _lagService.OnStatusChange += OnLagStatusChanged;
        }

        private void OnSettingsChanged(object sender, SettingsState status)
        {
            latestSettings = status;

            timeInput.Value = status.timeout;
            shortcutInput.Text = status.hotkeyString;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs eventArgs)
        {
            eventArgs.Handled = true;
            eventArgs.SuppressKeyPress = true;

            //remove modifier keys
            Keys pressedKey = eventArgs.KeyData ^ eventArgs.Modifiers;

            // check if pressed key is not esc nor enter
            if (pressedKey != Keys.Escape && pressedKey != Keys.Enter && pressedKey != Keys.Return)
            {
                _settingsDataLayer.SetHotkey(eventArgs.KeyData);
            }
            else
            {
                // remove focus
                ActiveControl = null;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _settingsDataLayer.SetTimeout(timeInput.Value);
        }

        private void OnLagStatusChanged(object sender, bool isLagging)
        {
            checker.BackColor = isLagging ? Color.DarkGreen : Color.Gray;
        }

        // makes window moveable because of the bordeless effect
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
    }
}
