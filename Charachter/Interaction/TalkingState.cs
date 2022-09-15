using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingState : State
{
    DialogLoader loader;

    public TalkingState(DialogLoader newLoader)
    {
        loader = newLoader;
    }

    public override void enterHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        character.ChangeAnimation("FireTransform");
        loader.Talk();
    }

    public override void inputHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        PlayerInput playerInput = character.playerInput;

        if (playerInput.Input.Talking || character.ableToTalk)
        {
            return;
        }


        character.ChangeStateHandler(new FireTransformIdle());
    }

    public override void updateHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        PlayerInput playerInput = character.playerInput;

        if (playerInput.Input.NormalAttack)
        {
            loader.Talk();
        }
    }
}
