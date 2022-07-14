using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.FSM2
{
    public class State
    {

        public string Name { get; private set; }

        
        protected BaseStateMachine _stateMachine;

        public State(string name, BaseStateMachine stateMachine)
        {
            Name = name;
            _stateMachine = stateMachine;
        }


        public virtual void Enter() { }
        public virtual void UpdateLogic() 
        {
            if (GameManager.Instance.State == GameManager.GameState.QUITTING)
            {
                _stateMachine.ChangeState(_stateMachine.QuittingState);
            }

        }
        public virtual void UpdatePhysics() { }
        public virtual void Exit() { }

    }
}