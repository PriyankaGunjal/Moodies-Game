using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace game2
{
    class IOManager
    {
        //int _playerXposition, _playerYPosition, _stickXPosition, _stickYPosition;
        private int _listCount;
        private string _deviceColor;
        public string DeviceColor { get { return _deviceColor; } set { _deviceColor = value; } }
        public int ListCount { get { return _listCount; } set { _listCount = value; } }
        static IOManager _iomanager=null;
        IOManager()
        {
           
        }

        public static IOManager GetIOManager()
        {
            if (_iomanager == null)
                _iomanager = new IOManager();
            return _iomanager;
        }

        public void ReadFile()
        {
            string text= System.IO.File.ReadAllText(@"D:\c# projects\GameData.txt");
            string[] temp = text.Split(' ');
            _listCount = Convert.ToInt32(temp[0]);
            string[] temp1 = temp[2].Split('[');
            temp = temp1[1].Split(']');
            DeviceColor = temp[0];

        }

    }
}
