using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.FSM2
{
    public class State_Moving : State
    {

        private BugController _controller;

        public State_Moving(BaseStateMachine stateMachine) : base("Moving State", stateMachine)
        {
            _controller = _stateMachine.GetComponent<BugController>();
        }


        public override void Enter()
        {
            base.Enter();

            _controller.StartWalking();
        }


        public override void UpdateLogic()
        {
            base.UpdateLogic();

            if (!_controller.CanSeeLight())
            {
                _stateMachine.ChangeState(_stateMachine.IdleState);
            }

            float? distance = _controller.DistanceToCurrentLightTarget();

            if (distance.HasValue && distance.Value <= 0.05f)
            {
                _stateMachine.ChangeState(_stateMachine.InLightState);
            }


        }

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();

            _controller.MoveTowardsTarget();

        }

    }
}
