using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.FSM2
{
    public class State_InLight : State
    {

        private BugController _controller;

        public State_InLight(BaseStateMachine stateMachine) : base("In Light State", stateMachine)
        {
            _controller = _stateMachine.GetComponent<BugController>();
        }


        public override void Enter()
        {
            base.Enter();
            _controller.PositionOnCurrentLightTarget();
        }


        public override void UpdateLogic()
        {
            base.UpdateLogic();

            float? distance = _controller.DistanceToCurrentLightTarget();

            if (distance.HasValue && distance.Value > 0.05f)
            {
                _stateMachine.ChangeState(_stateMachine.IdleState);
            }

            if (!_controller.CanSeeLight())
            {
                _stateMachine.ChangeState(_stateMachine.IdleState);
            }

        }

    }
}
