using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagSwitch.States
{
    public abstract class IStateful<State>
    {
        protected event EventHandler<State> OnStateChanged = delegate { };
        protected void EmitOnStateChanged (State state)
        {
            OnStateChanged(this, state);
        }

        abstract public void AddListener(EventHandler<State> handler);
    }
}
