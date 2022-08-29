using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotAttackedState : State
{
    public override void inputHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;

        if (character.Talking())
        {
            return;
        }

        if (character.Attacking())
        {
            return;
        }

        if (character.MovementDetected())
        {
            return;
        }
    }
}
