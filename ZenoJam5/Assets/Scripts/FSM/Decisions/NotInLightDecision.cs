using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/Not In Light")]
public class NotInLightDecision : InLightDecision
{
    public override bool Decide(BaseStateMachine machine)
    {
        return !base.Decide(machine);
    }
}
