using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game2
{
    class EventBroadcaster
    {
        static EventBroadcaster broadcaster=null;
        List<IListener> listeners;
      EventBroadcaster()
        {
            listeners = new List<IListener>();
        }
        public void RegisterListener(IListener listener)
        {
            listeners.Add(listener);
        }

        public void ReleaseListener(IListener listener)
        {
            listeners.Remove(listener);
              
        }
       public static EventBroadcaster GetBroadcaster()
        {
            if (broadcaster == null)
                broadcaster = new EventBroadcaster();
            return broadcaster;
        }
        public void BroadcastEvent(Event ievent)
        {
           foreach( IListener listener in  listeners)
            {
                listener.OnNotify(ievent);
            }

        }
       
        public void ChangeEvent(IStates state,bool PreviousState)
        {
            StateManager.GetStateManager().UpdateState(state, PreviousState);
        }

    
    }
}
