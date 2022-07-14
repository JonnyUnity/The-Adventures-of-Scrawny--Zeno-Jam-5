using Assets.Scripts.FSM2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachine : MonoBehaviour
{

    public State CurrentState { get; set; }


    public State_Idle IdleState;
    public State_Moving MovingState;
    public State_InLight InLightState;
    public State_Quitting QuittingState;
    public State_Goal GoalState;


    private void Awake()
    {
        IdleState = new State_Idle(this);
        MovingState = new State_Moving(this);
        InLightState = new State_InLight(this);
        QuittingState = new State_Quitting(this);
        GoalState = new State_Goal(this);

        CurrentState = IdleState;
    }


    private void Start()
    {
        if (CurrentState != null)
        {
            CurrentState.Enter();
        }
    }


    // Update is called once per frame
    void Update()
    {
        CurrentState.UpdateLogic();
    }

    private void FixedUpdate()
    {
        CurrentState.UpdatePhysics();
    }


    public void ChangeState(State newState)
    {
        Debug.Log("Old State = " + CurrentState.Name + ", New = " + newState.Name);
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }


    private void OnGUI()
    {
        string content = CurrentState != null ? CurrentState.Name : "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
    }

}
