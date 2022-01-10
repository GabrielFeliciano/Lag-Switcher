using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagSwitch
{
    class SettingsController
    {
        IFirewallRule rule;
        HotkeyListener hkl = new HotkeyListener();
        Hotkey hotkey;

        AlwaysOnTop alwaysOnTopWindow;

        public bool isLagging = false;
    }
}
