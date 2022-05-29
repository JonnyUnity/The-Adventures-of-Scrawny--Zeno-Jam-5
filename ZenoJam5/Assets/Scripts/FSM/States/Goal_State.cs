using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_State : State
{

    public override void Enter(BaseStateMachine stateMachine)
    {
        base.Enter(stateMachine);

        var controller = stateMachine.GetComponent<BugController>();
        controller.StopInPlace();

    }

}
