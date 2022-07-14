using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.FSM2
{
    public class State_Quitting : State
    {

        private BugController _controller;

        public State_Quitting(BaseStateMachine stateMachine) : base("Quitting State", stateMachine)
        {
            _controller = _stateMachine.GetComponent<BugController>();
        }


        public override void Enter()
        {
            base.Enter();
            _controller.StopInPlace();
        }

    }
}
