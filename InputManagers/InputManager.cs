using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Input;

namespace game2
{

    class InputManager
    {
       
     
        static InputManager _inputmanager=null;
        InputManager()
        {
         
        }

        public static InputManager GetInputManager()
        {
            if (_inputmanager == null)
                _inputmanager = new InputManager();
           return _inputmanager;
        }

        public void GetKey()
        {
            Event ievent;

            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Space))
            {
                ievent = new KeyPressedEvent(Keys.key.Space);
                EventBroadcaster.GetBroadcaster().BroadcastEvent(ievent);
            }
            else if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Escape))
            {
                ievent = new KeyPressedEvent(Keys.key.Escape);
                EventBroadcaster.GetBroadcaster().BroadcastEvent(ievent);
            }
            else if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Left))
            {
                ievent = new KeyPressedEvent(Keys.key.Left);
                EventBroadcaster.GetBroadcaster().BroadcastEvent(ievent);
            }
            else if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Right))
            {
                ievent = new KeyPressedEvent(Keys.key.Right);
                EventBroadcaster.GetBroadcaster().BroadcastEvent(ievent);
            }
            else if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Up))
            {
                ievent = new KeyPressedEvent(Keys.key.Up);
                EventBroadcaster.GetBroadcaster().BroadcastEvent(ievent);
            }
            else if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Escape) )
            {
                if (System.Windows.Input.Keyboard.IsKeyUp(System.Windows.Input.Key.Escape))
                {
                    ievent = new KeyReleasedEvent(Keys.key.Escape);
                    EventBroadcaster.GetBroadcaster().BroadcastEvent(ievent);
                }
            }
        }

    }
}
