using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTransformIdle : State
{
    public override void enterHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine charachter = (CharachterStateMachine)stateMachine;
        charachter.ChangeAnimation("FireTransform");
        nameState = charachter.FIRE_TRANSFORMATION_STATE;
    }

    public override void inputHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine charachter = (CharachterStateMachine)stateMachine;

        if (charachter.MovementDetected())
        {
            return;
        }
    }
}
