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
    class TextureResource:Resource
    {
        Texture _texture;
        public TextureResource()
        {

        }
        public  void LoadResource(string path)
        {
            _texture= TextureLoader.FromFile(GameAppFramework.GetGameAppFramework().Device, path);
        }

        public Texture GetTexture()
        {
            return _texture;
        }

    }
}
