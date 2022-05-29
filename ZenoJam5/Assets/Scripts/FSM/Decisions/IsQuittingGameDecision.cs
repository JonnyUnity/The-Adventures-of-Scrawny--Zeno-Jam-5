using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/Quitting Game")]
public class IsQuittingGameDecision : Decision
{
    public override bool Decide(BaseStateMachine machine)
    {
        return GameManager.Instance.State == GameManager.GameState.QUITTING;
    }


}
