using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.FSM2
{
    public class State_Goal : State
    {
        private BugController _controller;

        public State_Goal(BaseStateMachine stateMachine) : base("Goal State", stateMachine)
        {
            _controller = _stateMachine.GetComponent<BugController>();
        }


        public override void Enter()
        {
            base.Enter();
            _controller.StopInPlace();
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
        }

    }
}
