using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/State")]
public class State : BaseState
{

    [SerializeField] protected List<FSMAction> Actions = new List<FSMAction>();
    [SerializeField] protected List<Transition> Transitions = new List<Transition>();


    public override void Enter(BaseStateMachine stateMachine)
    {
        base.Enter(stateMachine);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        //foreach(var action in Actions)
        //{
        //    action.Execute(_stateMachine);
        //}
        //foreach(var transition in Transitions)
        //{
        //    transition.Execute(_stateMachine);
        //}

    }


    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        foreach (var action in Actions)
        {
            action.Execute(_stateMachine);
        }
        foreach (var transition in Transitions)
        {
            transition.Execute(_stateMachine);
        }

    }


    public override void Exit()
    {
        base.Exit();
    }


}
