using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/In Light")]
public class InLightDecision : Decision
{
    public override bool Decide(BaseStateMachine machine)
    {
        var controller = machine.GetComponent<BugController>();
        float? distance = controller.DistanceToCurrentLightTarget();

        if (!distance.HasValue)
        {
            return false;
        }
        else
        {
            //Debug.Log(distance.Value);
            return distance.Value <= 0.05f;
        }

    }
}
