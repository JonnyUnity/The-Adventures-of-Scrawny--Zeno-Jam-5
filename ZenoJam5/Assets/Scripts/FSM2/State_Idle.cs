using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.FSM2
{
    public class State_Idle : State
    {

        private BugController _controller;

        public State_Idle(BaseStateMachine stateMachine) : base("Idle State", stateMachine)
        {
            _controller = _stateMachine.GetComponent<BugController>();
        }

        public override void Enter()
        {
            base.Enter();

            _controller.ResetTarget();
        }


        public override void UpdateLogic()
        {
            base.UpdateLogic();

            if (_controller.CanSeeLight())
            {
                _stateMachine.ChangeState(_stateMachine.MovingState);
            }


        }

    }
}
