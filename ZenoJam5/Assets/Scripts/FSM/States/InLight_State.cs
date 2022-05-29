using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/States/In Light State")]
public class InLight_State : State
{

    public override void Enter(BaseStateMachine stateMachine)
    {
        base.Enter(stateMachine);

        var controller = stateMachine.GetComponent<BugController>();
        controller.PositionOnCurrentLightTarget();

        //var rigidBody = _stateMachine.GetComponent<Rigidbody2D>();
        
        //rigidBody.velocity = Vector2.zero;
        //var controller = stateMachine.GetComponent<BugController>();
        //controller.ResetTarget();
    }

}
