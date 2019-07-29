using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game2
{
    class PlayerInAirState:IStates
    {
        public PlayerInAirState()
        {
        }
        public void Update()
        {

            PlayerManager.CreatePlayerManager().PlayerUpdate();
        }

        public void Render()
        {
          
            GameAppFramework.GetGameAppFramework().RenderWholeWorld();
        }
      
        public void OnNotify(Event ievent)
        {
             if (((KeyPressedEvent)ievent).key == Keys.key.Escape)
            {
                EventBroadcaster.GetBroadcaster().ChangeEvent(null, false);
            }
        }

    }
}
