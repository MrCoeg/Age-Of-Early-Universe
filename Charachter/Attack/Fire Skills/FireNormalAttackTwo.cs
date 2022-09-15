using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireNormalAttackTwo : State
{
    public override void enterHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine charachter = (CharachterStateMachine)stateMachine;
        charachter.isAttacking = true;
        charachter.comboCode = 1;
        nameState = charachter.FIRE_ATTACK_TWO;
        charachter.animator.Play("Fire_NC2");
        charachter.AddAnimationPrefab(Resources.Load("Fire/Slash_1") as GameObject, new Vector3(3, 0, 0), false);
    }

    public override void inputHandleState(StateMachine stateMachine)
    {

        CharachterStateMachine charachter = (CharachterStateMachine)stateMachine;
        PlayerInput playerInput = charachter.playerInput;

        if (charachter.comboCode == 2 && playerInput.Input.NormalAttack)
        {
            return;
        }

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
    }
}
