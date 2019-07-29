using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace game2
{
    class PlayerOnStickState:IStates
    {
        public PlayerOnStickState()
        {
          
            PlayerManager.CreatePlayerManager().CreateNewPlayer();
            StickManager.GetStick().ResetAngle();
            
        }
        public void Update()
        {
            PlayerManager.CreatePlayerManager().setCenterPoints();
        }

        public void Render()
        {
          
            GameAppFramework.GetGameAppFramework().RenderWholeWorld();
           
           
        }
       
        public void OnNotify(Event ievent)
        {
            if(ievent is KeyPressedEvent)
            {
                if(((KeyPressedEvent)ievent).key==Keys.key.Left|| ((KeyPressedEvent)ievent).key == Keys.key.Right)
                {
                    StickManager.GetStick().StickUpdate(((KeyPressedEvent)ievent).key);
                }
                else if(((KeyPressedEvent)ievent).key==Keys.key.Up)
                {
                    EventBroadcaster.GetBroadcaster().ChangeEvent(new PlayerInAirState(), false);
                }
                else if(((KeyPressedEvent)ievent).key==Keys.key.Escape)
                {
                    EventBroadcaster.GetBroadcaster().ChangeEvent(null,false);
                }
            
            }
         
        }

    }
}
