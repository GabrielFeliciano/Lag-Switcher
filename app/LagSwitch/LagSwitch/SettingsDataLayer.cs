using LagSwitch.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WK.Libraries.HotkeyListenerNS;

namespace LagSwitch
{
    public class SettingsDataLayer : IStateful<SettingsState>
    {
        SettingsState _state = new SettingsState();

        public SettingsDataLayer()
        {
            OnStateChanged += SaveToPropertiesOnStateChange;
            LoadProperties();
        }

        override public void AddListener(EventHandler<SettingsState> handler)
        {
            handler(this, _state);
            OnStateChanged += handler;
        }

        public void SetPath(string path)
        {
            _state.path = path;

            EmitOnStateChanged(_state);
        }

        public void SetHotkey(Keys keys)
        {
            _state.hotkey = new Hotkey(keys & Keys.Modifiers, keys & ~Keys.Modifiers);
            var converter = new KeysConverter();
            var str = converter.ConvertToString(keys);
            _state.hotkeyString = str; 

            EmitOnStateChanged(_state);
        }

        public void SetTimeout(decimal time)
        {
            _state.timeout = time;

            EmitOnStateChanged(_state);
        }

        void LoadProperties ()
        {
            _state.path = Properties.Settings.Default.path;
            _state.hotkeyString = Properties.Settings.Default.hotkey;

            try
            {
                var converter = new KeysConverter();
                var keys = (Keys)converter.ConvertFromString(_state.hotkeyString);

                _state.hotkey = new Hotkey(keys & Keys.Modifiers, keys & ~Keys.Modifiers);
            } catch
            {
                _state.hotkey = new Hotkey();
            }

            _state.timeout = Properties.Settings.Default.timer;

            EmitOnStateChanged(_state);
        }

        void SaveToPropertiesOnStateChange (object sender, SettingsState state)
        {
            Properties.Settings.Default.path = state.path;
            Properties.Settings.Default.hotkey = state.hotkeyString;
            Properties.Settings.Default.timer = state.timeout;
            Properties.Settings.Default.Save();
        }
    }
}
