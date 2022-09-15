using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackTwo : State
{
    public override void enterHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        character.isAttacking = true;
        character.comboCode = 1;
        character.animator.Play("Sword_Attack");

    }
    public override void inputHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        PlayerInput playerInput = character.playerInput;

        if (character.ChangeTransform())
        {
            return;
        }

        if (character.isAttacking || playerInput.Input.NormalAttack)
        {
            return;
        }

        if (character.MovementDetected(new Move()))
        {
            return;
        }

        character.ChangeStateHandler(new NotAttackedState());
    }

    public override void updateHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
    }

    public override void exitHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        character.isAttacking = false;
        character.comboCode = 0;
    }
}
