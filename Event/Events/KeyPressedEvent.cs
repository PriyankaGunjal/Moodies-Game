using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game2
{
    class KeyPressedEvent:Event
    {
      public Keys.key key;
        public KeyPressedEvent(Keys.key key)
        {
            this.key = key;
        }

      
    }
}
