using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game2
{
    class RunningState:IStates
    {
        public  RunningState()
        {
           
        }
        public  void Update()
        {
        }
        public void Render()
        {
         
            GameAppFramework.GetGameAppFramework().RenderWholeWorld();
        }
     
        public void OnNotify(Event ievent)
        {
            if (ievent is KeyPressedEvent)
            {
                if(((KeyPressedEvent)ievent).key==Keys.key.Escape)
                    EventBroadcaster.GetBroadcaster().ChangeEvent(null,false);
                else
                {
                    EventBroadcaster.GetBroadcaster().ChangeEvent(new PlayerOnStickState(), true);
                }
            }
               
          
        }
    }
}
