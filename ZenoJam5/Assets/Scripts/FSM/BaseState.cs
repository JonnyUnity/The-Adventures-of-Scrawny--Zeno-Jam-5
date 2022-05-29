using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : ScriptableObject
{

    protected BaseStateMachine _stateMachine;

    public virtual void Enter(BaseStateMachine stateMachine) 
    {
        _stateMachine = stateMachine;    
    }

    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }

    public virtual void Exit() { }
}
