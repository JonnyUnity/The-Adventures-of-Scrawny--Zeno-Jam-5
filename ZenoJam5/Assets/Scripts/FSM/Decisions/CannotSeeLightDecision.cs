using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/Cannot See Light")]
public class CannotSeeLightDecision : CanSeeLightDecision
{
    public override bool Decide(BaseStateMachine machine)
    {
        return !base.Decide(machine);
    }
}
