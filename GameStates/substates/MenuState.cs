using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace game2
{
    class MenuState:IStates
    {

        Texture background;
        Microsoft.DirectX.Direct3D.Font font;
        public MenuState()
        {
           init();
        }

       
        public  void Update()
        {
           
        }
        public  void Render()
        {
          
          
            try
            {
                Microsoft.DirectX.Direct3D.Device device = GameAppFramework.GetGameAppFramework().Device;
                device.Clear(ClearFlags.Target, Color.HotPink, 0, 1);
                device.BeginScene();
                using (Sprite MenuSprite = new Sprite(device))
                {
                    MenuSprite.Begin(SpriteFlags.AlphaBlend);
                    MenuSprite.Draw2D(background, new Rectangle(0, 0, 0, 0), new Rectangle(0, 0, device.Viewport.Width, device.Viewport.Height), new Point(0, 0), 0f, new Point(0, 0), Color.White);
                    font.DrawText(MenuSprite, "Press Space to START", new Point((device.Viewport.Width / 2) - 200, device.Viewport.Height / 2), Color.White);
                    font.DrawText(MenuSprite, "Press Escape to END", new Point((device.Viewport.Width / 2) - 200, (device.Viewport.Height / 2) + 100), Color.White);
                    MenuSprite.End();
                }

                device.EndScene();
                device.Present();
            }
            catch (Exception e) { };

        }
      
        public void OnNotify(Event ievent)
        {
           
            if ((ievent as KeyPressedEvent)?.key == Keys.key.Space)
            {
                EventBroadcaster.GetBroadcaster().ChangeEvent(new RunningState(), true);
            }
            else if ((ievent as KeyPressedEvent).key == Keys.key.Escape)
            {
                EventBroadcaster.GetBroadcaster().ChangeEvent(new EndState(), false);
            }
        }
        private void init()
        {
            Task<Resource> loadTask = ResourceManager.CreateResource().GetResource("back.jpg");
            background = ((TextureResource)loadTask.GetAwaiter().GetResult()).GetTexture();
            System.Drawing.Font f = new System.Drawing.Font("Arial Black", 50);
            font = new Microsoft.DirectX.Direct3D.Font(GameAppFramework.GetGameAppFramework().Device, f);
        }
    }
}
