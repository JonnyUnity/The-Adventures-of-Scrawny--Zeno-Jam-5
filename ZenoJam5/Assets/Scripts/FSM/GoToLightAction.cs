using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Actions/Go To Light")]
public class GoToLightAction : FSMAction
{
    
    public override void Execute(BaseStateMachine machine)
    {
        //var lightSensor = machine.GetComponent<LightSensor>();
        //Vector2 lightSource = lightSensor.Ping();

        var controller = machine.GetComponent<BugController>();

        controller.MoveTowardsTarget();


    }
}
