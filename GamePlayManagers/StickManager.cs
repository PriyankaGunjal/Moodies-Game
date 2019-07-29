using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Drawing;

namespace game2
{
    class StickManager
    {
        private Texture _stick;
        float _rotationAngle,_x,_y;
        public float rotationAngle
        { get { return _rotationAngle; }
          set { _rotationAngle = value; } }

        public float X { get { return _x; } set { _x = value; } }
        public float Y { get { return _y; } set { _y = value; } }

        static StickManager _stickmanager = null;
        PlayerManager _playermanager;
        StickManager()
        {
            Task<Resource> loadTask = ResourceManager.CreateResource().GetResource("stick2.png");
            _stick = ((TextureResource)loadTask.GetAwaiter().GetResult()).GetTexture();
            _x = (GameAppFramework.GetGameAppFramework().Device.Viewport.Width / 2)-70;
            _y = (GameAppFramework.GetGameAppFramework().Device.Viewport.Height)-130;
            _playermanager= PlayerManager.CreatePlayerManager();
           
        }

        public void ResetAngle()
        {
            _rotationAngle = 0.0f;
        }
        public static StickManager GetStick()
        {
            if (_stickmanager == null)
                _stickmanager = new StickManager();
            return _stickmanager;
        }
        public void  RenderStick()
        {
            using (Sprite drawStick = new Sprite(GameAppFramework.GetGameAppFramework().Device))
            {
               
                drawStick.Begin(SpriteFlags.AlphaBlend);
                Matrix matrix = new Matrix();
                matrix = Matrix.Transformation2D(new Vector2(0, 0), 0f, new Vector2(1.0f, 1.0f), new Vector2(_x+45, _y+100), _rotationAngle, new Vector2(0, 0));
                drawStick.Transform = matrix;
                drawStick.Draw(_stick, new Rectangle(0, 0, 0, 0), new Vector3(0, 0, 0), new Vector3(_x,_y, 0), Color.White);
                drawStick.End();
             }
           
        }

        public void StickUpdate(Keys.key key)
        {
            int radious =(int) (_y + 100) - _playermanager.GetPlayerY();
            if (key == Keys.key.Left && _rotationAngle > -0.9)
            {
                _rotationAngle -= 0.1f;
                if (_playermanager.GetPlayerX() <= _playermanager.Playerstartx)
                {
                    _playermanager.SetPlayerX(_playermanager.GetPlayerX() - 12);
                    _playermanager.SetPlayerY(_playermanager.GetPlayerY() + 4);
                }
                else
                {
                    _playermanager.SetPlayerX(_playermanager.GetPlayerX() - 12);
                    _playermanager.SetPlayerY(_playermanager.GetPlayerY() - 4);
                }
            }
            else if (key == Keys.key.Right && _rotationAngle < 0.9)
            {
                _rotationAngle += 0.1f;
                if (_playermanager.GetPlayerX() >= _playermanager.Playerstartx)
                {
                    _playermanager.SetPlayerX(_playermanager.GetPlayerX() + 12);
                    _playermanager.SetPlayerY(_playermanager.GetPlayerY() + 4);
                }
                else
                {
                    _playermanager.SetPlayerX(_playermanager.GetPlayerX() + 12);
                    _playermanager.SetPlayerY(_playermanager.GetPlayerY() - 4);
                }

            }

          

        }
        
       
    }
}
