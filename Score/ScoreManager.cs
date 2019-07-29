using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;



namespace game2
{
    class ScoreManager
    {
        private int _score=0;
        Microsoft.DirectX.Direct3D.Font font;
        private static ScoreManager _scoreManager = null;
        ScoreManager(Device device)
        {
            System.Drawing.Font f = new System.Drawing.Font("Arial Black", 10);
            font = new Microsoft.DirectX.Direct3D.Font(device, f);
        }
       
        public static ScoreManager GetScoreManager()
        {
            if (_scoreManager == null)
                _scoreManager =new ScoreManager(GameAppFramework.GetGameAppFramework().Device);
            return _scoreManager;
        }
        public void Update()
        {
            _score = _score + 1;
        }
        public void RenderScore(Device device)
        {
            using (Sprite drawscore = new Sprite(device))
            {
                drawscore.Begin(SpriteFlags.AlphaBlend);
                font.DrawText(drawscore, "SCORE "+_score, new Point(device.Viewport.Width-100,device.Viewport.Height-100), Color.White);
                drawscore.End();
            }

        }

        public int GetScore()
        {
            return _score;
        }
    }
}
