using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game2
{
    class KeyReleasedEvent : Event
    {
        public Keys.key key;
        public KeyReleasedEvent(Keys.key key)
        {
            this.key = key;
        }
    }
}
