using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/States/Idle State")]
public class Idle_State : State
{

    public override void Enter(BaseStateMachine stateMachine)
    {
        base.Enter(stateMachine);

        var rigidBody = _stateMachine.GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.zero;
    }

}
