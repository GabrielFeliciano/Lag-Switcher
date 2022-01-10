using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFirewallHelper;

namespace LagSwitch
{
    public class LagService
    {
        // props
        Timer timer;
        bool isLagging = false;

        static IFirewall FirewallManager = WindowsFirewallHelper.FirewallManager.Instance;
        IFirewallRule rule;

        // events
        public event EventHandler<bool> OnStatusChange = delegate { };

        public LagService()
        {
            timer = new Timer();
            timer.Tick += OnTimerTriggered;
            OnStatusChange += delegate (object sender, bool value) {
                isLagging = value;
            };
        }

        public void Lag (string path, int time)
        {
            if (isLagging) return;

            // create rule
            rule = WindowsFirewallHelper.FirewallManager.Instance.CreateApplicationRule(
                FirewallProfiles.Domain | FirewallProfiles.Private | FirewallProfiles.Public,
                @"A-LagSwitch",
                FirewallAction.Block,
                path
            );
            rule.Direction = FirewallDirection.Inbound | FirewallDirection.Outbound;

            // add it
            FirewallManager.Rules.Add(rule);

            // sets timer
            timer.Enabled = true;
            timer.Interval = time;

            OnStatusChange(this, true);
        }

        private void OnTimerTriggered (object sender, EventArgs e)
        {
            // sets stuff on timer
            timer.Enabled = false;
            FirewallManager.Rules.Remove(rule);

            OnStatusChange(this, false);
        }
    }
}
