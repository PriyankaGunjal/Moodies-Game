using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Drawing;
using System.Runtime.CompilerServices;
using game2.Annotations;

namespace game2
{
    class GameAppFramework : INotifyPropertyChanged
    {

        private Device _device;
        private Color _deviceColor;

        public Color DeviceColor { get { return _deviceColor; } set { _deviceColor = value; } }
        public Device Device
        {
            get { return _device; }
            set
            {
                _device = value;
                OnPropertyChanged(nameof(Device));
            }
        }

        GameApp _gameapp;
        static GameAppFramework _gameframework = null;

        GameAppFramework(){ }
        public void InitializeDevice(GameApp gameapp)
        {
            PresentParameters presentparameter = new PresentParameters();
            presentparameter.Windowed = true;
            presentparameter.SwapEffect = SwapEffect.Discard;
            Device = new Device(0, DeviceType.Hardware, gameapp, CreateFlags.HardwareVertexProcessing, presentparameter);
            

        }
        public static GameAppFramework GetGameAppFramework()
        {
            if (_gameframework == null)
                _gameframework = new GameAppFramework();
            return _gameframework;
        } 
        public void Update(GameApp gameapp)
        {
            InputManager.GetInputManager().GetKey();
            StateManager.GetStateManager().GetCurrentState().Update();
        }
        public void Render()
        {          
            StateManager.GetStateManager().GetCurrentState().Render();
        }
        public GameApp GetGameApp()
        {
            return _gameapp;
        }
        public void InitializeFormSize()
        {
         
        }
       
        public void RenderWholeWorld()
        {
            try {
                Device.Clear(ClearFlags.Target,DeviceColor, 0, 1);
                Device.BeginScene();
                TargetsManager.CreateTargets().RenderTarget();
                StickManager.GetStick().RenderStick();
                PlayerManager.CreatePlayerManager().PlayerRender(Device);
                ScoreManager.GetScoreManager().RenderScore(Device);
                HangingMoodie.CreatehHangingMoodie().Render();
                Device.EndScene();
                Device.Present();
            }catch(Exception) { };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
