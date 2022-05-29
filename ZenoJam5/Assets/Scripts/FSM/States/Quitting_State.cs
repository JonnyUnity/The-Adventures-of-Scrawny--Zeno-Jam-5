using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/States/Quitting State")]
public class Quitting_State : State
{

    public override void Enter(BaseStateMachine stateMachine)
    {
        base.Enter(stateMachine);

        var controller = stateMachine.GetComponent<BugController>();
        controller.StopInPlace();

    }

}
