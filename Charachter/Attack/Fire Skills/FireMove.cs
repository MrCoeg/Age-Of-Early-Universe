using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMove : State
{
    private State[] skills = { new FireSkillOne(), new FireSkillTwo() , new FireSkillThree(), new FireSkillFour()};
    public override void enterHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        character.animator.Play("FireMove");
    }

    public override void inputHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        PlayerInput playerInput = character.playerInput;

        if (character.ChangeTransform())
        {
            return;
        }

        if (character.UseSkill(skills))
        {
            return;
        }

        if (character.Talking())
        {
            return;
        }

        if (character.Attacking(new FireNormalAttackOne()))
        {
            return;
        }

        if (playerInput.Input.JumpDown || playerInput.Input.X != 0 || character.isMoving)
        {
            return;
        }

        character.ChangeStateHandler(new FireTransformIdle());
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
