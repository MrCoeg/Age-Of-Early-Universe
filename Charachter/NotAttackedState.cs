using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotAttackedState : State
{

    public override void enterHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        character.animator.Play("Idle");
        nameState = character.IDLE_STATE;
    }

    public override void inputHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        Debug.Log("Outside");

        if (character.ChangeTransform())
        {
            return;
        }

        if (character.Talking())
        {
            Debug.Log("T");
            return;
        }

        if (character.Attacking())
        {
            Debug.Log("A");

            return;
        }

        if (character.MovementDetected())
        {
            Debug.Log("M");

            return;
        }
    }
}
