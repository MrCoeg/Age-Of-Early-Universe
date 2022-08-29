using UnityEngine;
public class Move : State
{
    public override void inputHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        PlayerInput playerInput = character.playerInput;

        if (character.Talking())
        {
            return;
        }

        if (character.Attacking())
        {
            return;
        }

        if (playerInput.Input.JumpDown || playerInput.Input.X != 0 || character.isMoving)
        {
            return;
        }

        character.ChangeStateHandler(new NotAttackedState());
    }

    public override void updateHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        character.MoveUpdateHandle();
    }

    public override void exitHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        character.EndMove();
    }
}
