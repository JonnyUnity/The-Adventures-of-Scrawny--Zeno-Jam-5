using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Transition")]
public class Transition : ScriptableObject
{
    [SerializeField] private Decision _decision;
    [SerializeField] private BaseState _trueState;
    [SerializeField] private BaseState _falseState;


    public void Execute(BaseStateMachine machine)
    {
        if (_decision.Decide(machine) && !(_trueState is RemainInState))
        {
            Debug.Log("True " + _trueState.name);
            //machine.CurrentState = _trueState;
            machine.ChangeState(_trueState);
        }
        else if (!(_falseState is RemainInState))
        {
            Debug.Log("False " + _falseState.name);
            //machine.CurrentState = _falseState;
            machine.ChangeState(_falseState);
        }
    }



}
