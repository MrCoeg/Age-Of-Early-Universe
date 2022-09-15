using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkillFour : State
{
    public override void enterHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine charachter = (CharachterStateMachine)stateMachine;
        charachter.ChangeAnimation("Ultimate");
        charachter.isAttacking = true;
    }
    public override void inputHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine charachter = (CharachterStateMachine)stateMachine;
        PlayerInput playerInput = charachter.playerInput;

        if (charachter.isAttacking || playerInput.Input.NormalAttack)
        {
            return;
        }

        if (charachter.MovementDetected(new FireMove()))
        {
            return;
        }

        charachter.ChangeStateHandler(new FireTransformIdle());
    }

    public override void exitHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        character.isAttacking = false;
        character.comboCode = 0;
        character.isDashing = false;
    }

}
