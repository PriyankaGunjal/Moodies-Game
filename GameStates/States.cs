using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace game2
{
    interface IStates
    {
        void Update();
       
       void Render();
        
        void OnNotify(Event ievent);

    }
}
