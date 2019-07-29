using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
namespace game2
{

    class StateManager:IListener
    {
        Stack<IStates> _StateStack;
        static StateManager _statemanager;
        StateManager()
        {

            _StateStack = new Stack<IStates>();
            _StateStack.Push(new MenuState());
          
           
        }

        public static StateManager GetStateManager()
        {
            if (_statemanager == null)
            {
                _statemanager = new StateManager();
                EventBroadcaster.GetBroadcaster().RegisterListener(_statemanager);
            }
            return _statemanager;
        }
        public void RemoveState()
        {
            _StateStack.Pop();
        }
        public void SetState(IStates state)
        {
            _StateStack.Push(state);

        }
        public IStates GetCurrentState()
        {
            return _StateStack.Peek();
        }
        public void UpdateState(IStates state,bool PreviousState)
        {
            IStates PopedState;
            if (state == null)
            {
                _StateStack.Pop();
            }
            else if (PreviousState == false)
            {
                PopedState = _StateStack.Pop();
                Delete(PopedState);
                _StateStack.Push(state);
            }
            else if(PreviousState==true)
            {
               _StateStack.Push(state);
            }

           
        }
       public void OnNotify(Event ievent)
        {
           _StateStack.Peek().OnNotify(ievent);
        }
      void Delete(IStates State)
        {
            GC.SuppressFinalize(State);
        }
            
    }
}
