using System.Collections.Generic;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
namespace game2
{
    public class HangingMoodie
    {
        private List<Moodie> hangingMoodies;
        private static HangingMoodie _hMoodie=null;

        HangingMoodie()
        {
            hangingMoodies=new List<Moodie>();
        }

        public static HangingMoodie CreatehHangingMoodie()
        {
            if(_hMoodie==null)
                _hMoodie=new HangingMoodie();
            return _hMoodie;
        }


        public void AddHangingMoodie(Moodie moodie)
        {
            hangingMoodies.Add(moodie);
        }

        public void Render()
        {
            Device device = GameAppFramework.GetGameAppFramework().Device;
        
            foreach (var moodie in hangingMoodies)
            {
                if (moodie.GetYCoordinate() < device.Viewport.Height)
                {
                    moodie.SetYCoordinate(moodie.GetYCoordinate()-1);
                    moodie.DrawMoodie();
                }
                else
                {
                    hangingMoodies.Remove(moodie);
                }
            }
        } 
    }
}