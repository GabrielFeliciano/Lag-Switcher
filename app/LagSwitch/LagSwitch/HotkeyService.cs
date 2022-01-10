using LagSwitch.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WK.Libraries.HotkeyListenerNS;
using static WK.Libraries.HotkeyListenerNS.HotkeyListener;

namespace LagSwitch
{
    public class HotkeyService
    {
        Hotkey _lagHotkey;

        HotkeyListener _hkl;
        SettingsDataLayer _sdl;

        public HotkeyEventHandler HotkeyListeners = delegate { };

        public HotkeyService(SettingsDataLayer sdl)
        {
            _hkl = new HotkeyListener();
            _sdl = sdl;

            _sdl.AddListener(OnConfigChanged);
            _hkl.HotkeyPressed += (sender, e) => HotkeyListeners(sender, e);
        }

        public void OnConfigChanged(object sender, SettingsState state)
        {
            _hkl.Remove(_lagHotkey);
            _lagHotkey = state.hotkey;
            _hkl.Add(_lagHotkey);
        }
    }
}
