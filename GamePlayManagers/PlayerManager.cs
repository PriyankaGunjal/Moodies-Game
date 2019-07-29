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
   
    class PlayerManager
    {
        Moodie _player;
        int _playerXCenter, _playerYCenter;
        float _playerRotationAngle;
        private bool _wall = false;
        public int Playerstartx, Playerstarty;
        static PlayerManager _playermanager;
       
        PlayerManager(Device device)
         {
            Task<Resource> loadTask = ResourceManager.CreateResource().GetResource("image5.png");
            _player = new Moodie(((TextureResource)loadTask.GetAwaiter().GetResult()).GetTexture(), (device.Viewport.Width / 2) - 60, device.Viewport.Height - 185, 5);
            Playerstartx = GetPlayerX();

        }

        public void CreateNewPlayer()
        {
            _player = null;
            Random r = new Random();
            int randomMoodie = 1;
            randomMoodie = r.Next(1, 5);
            string image = "image" + randomMoodie + ".png";
            Task<Resource> loadTask = ResourceManager.CreateResource().GetResource(image);
            _player = new Moodie(((TextureResource)loadTask.GetAwaiter().GetResult()).GetTexture(),
                (GameAppFramework.GetGameAppFramework().Device.Viewport.Width / 2) - 60,
                GameAppFramework.GetGameAppFramework().Device.Viewport.Height - 185,randomMoodie);
            Playerstartx = GetPlayerX();
            _wall = false;
           
        }
        public static PlayerManager CreatePlayerManager()
        {
            if (_playermanager == null)
                _playermanager = new PlayerManager(GameAppFramework.GetGameAppFramework().Device);
            return _playermanager;
        } 
        public static void DestroyPlayer()
        {
            _playermanager = null;
        }

        public void SetPlayerX(int x)
        {
            _player.SetXCoordinate(x);
        }
        public void SetPlayerY(int x)
        {
            _player.SetYCoordinate(x);
        }
        public int GetPlayerX()
        {
            return _player.GetXCoordinate();

        }
        public int GetPlayerY()
        {
            return _player.GetYCoordinate();

        }

        public int GetType()
        {
            return  _player.GetType();
        }
        public void PlayerUpdate()
        {
            var targets = TargetsManager.CreateTargets().MoodieList;
            StickManager stick =StickManager.GetStick();
            double yAngle = Math.Sin(stick.rotationAngle - Math.PI / 2);
            double xAngle = Math.Cos(stick.rotationAngle - Math.PI / 2);
         
            if (!isWall() &&! _wall)
            {
               SetPlayerX((int)((GetPlayerX()) + (25 * xAngle)));
               SetPlayerY((int)((GetPlayerY()) + (25 * yAngle)));
            }
            else
            {
                SetPlayerX((int)((GetPlayerX()) - (25 * xAngle)));
                SetPlayerY((int)((GetPlayerY()) + (25 * yAngle)));
            }
            if(targets[targets.Count-1][0].GetYCoordinate()>=GetPlayerY()-36)
                CollisionManager.GetCollisionManager().HandleCollision();
        }
     

        private bool isWall()
        {
        
            GameAppFramework framework = GameAppFramework.GetGameAppFramework();
            bool result=false;
            if (GetPlayerX() <= 0)
            {
                _wall = true;
                result = true;
            }

            else if (GetPlayerX()+50 >= framework.Device.Viewport.Width)
            {
                _wall = true;
                result = true;
            }
            else if (GetPlayerY() <=0)
            {
                _wall = true;
                result = true;
            }
            else if (GetPlayerY() >= framework.Device.Viewport.Height)
            {
                _wall = true;
                result = true;
            }
            return result;
        }

        public void setCenterPoints()
        {
            StickManager stick = StickManager.GetStick();
            _playerXCenter = (int)stick.X + 45;
            _playerYCenter = (int)stick.Y + 100;
            _playerRotationAngle = (int)stick.rotationAngle;
        }

        public void PlayerRender(Device device)
        {
            StickManager stick = StickManager.GetStick();
            using (Sprite DrawPlayer = new Sprite(device))
            {
                try
                {

                    DrawPlayer.Begin(SpriteFlags.AlphaBlend);
                    Matrix matrix = new Matrix();
                    matrix = Matrix.Transformation2D(new Vector2(0, 0), 0f, new Vector2(1.0f, 1.0f), new Vector2(GetPlayerX()+25, GetPlayerY()+25),0.1f, new Vector2(0, 0));//(float)(Math.PI - playerRotationAngle), new Vector2(0,0));
                    DrawPlayer.Transform = matrix;
                    DrawPlayer.Draw(_player.getTexture(), new Rectangle(0, 0, 0, 0), new Vector3(0, 0, 0), new Vector3(GetPlayerX(), GetPlayerY(), 0), Color.White);
                    DrawPlayer.End();
                }
                catch (Exception e) { }
            }
        }
        
    }
}
