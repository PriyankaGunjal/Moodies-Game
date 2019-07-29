using System;
using System.Windows.Forms;
using System.Threading;
namespace game2
{
    public partial class GameApp : Form
    {
        Thread _thread;
        public int Fps { get; private set; } = 0;
        public int Frames { get; private set; } = 0;
        public long Timestarted { get; private set; } = Environment.TickCount;
        static GameApp _gameapp=null;
       GameApp()
        {
            InitializeComponent();
            GameAppFramework.GetGameAppFramework().InitializeFormSize();
            var afmeAppFrameWork = GameAppFramework.GetGameAppFramework();
            afmeAppFrameWork.InitializeDevice(this);
            IOManager.GetIOManager().ReadFile();
            GameAppFramework.GetGameAppFramework().DeviceColor =
                System.Drawing.Color.FromName(IOManager.GetIOManager().DeviceColor);
           // MessageBox.Show(IOManager.GetIOManager().DeviceColor);
        }
        public static GameApp GetGameApp()
        {
            if (_gameapp == null)
                _gameapp = new GameApp();
            return _gameapp;
        }
       
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
          StartThread();
        }
        private void GameLoop()
        {
            while (true)
            {
                GameAppFramework.GetGameAppFramework().Render();
                GameAppFramework.GetGameAppFramework().Update(this);

                if(Environment.TickCount>Timestarted+60)
                {
                    Fps = Frames;
                    Frames = 0;
                    Timestarted = Environment.TickCount;
                }
                Frames++;
              
            }
         }
    
        private void StartThread()
        {
            _thread = new Thread(GameLoop);
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
        }
        private void StopThread()
        {
            _thread.Abort();
        }

        private void GameApp_Load(object sender, EventArgs e)
        {
           
        }

        private void GameApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopThread();
        }

        private void GameApp_SizeChanged(object sender, EventArgs e)
        {
           

        }

       
        
    }
}

  