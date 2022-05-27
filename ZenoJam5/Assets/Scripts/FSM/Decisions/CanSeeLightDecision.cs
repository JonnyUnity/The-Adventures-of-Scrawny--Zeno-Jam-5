using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/Can See Light")]
public class CanSeeLightDecision : Decision
{
    public override bool Decide(BaseStateMachine machine)
    {
        var controller = machine.GetComponent<BugController>();

        return controller.CanSeeLight();
    }

}
