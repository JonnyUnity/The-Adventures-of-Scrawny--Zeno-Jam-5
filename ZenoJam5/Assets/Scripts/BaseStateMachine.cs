using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachine : MonoBehaviour
{
    [SerializeField] private BaseState _initialState;


    public BaseState CurrentState { get; set; }


    private void Awake()
    {
        CurrentState = _initialState;
    }


    private void Start()
    {
        if (CurrentState != null)
        {
            CurrentState.Enter(this);
        }
    }


    void Update()
    {
        CurrentState.UpdateLogic();
    }

    private void FixedUpdate()
    {
        CurrentState.UpdatePhysics();
    }


    public void ChangeState(BaseState newState)
    {
        Debug.Log("Old State = " + CurrentState.name + ", New = " + newState.name);
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter(this);
    }


    //private void OnGUI()
    //{
    //    string content = CurrentState != null ? CurrentState.name : "(no current state)";
    //    GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
    //}

}
