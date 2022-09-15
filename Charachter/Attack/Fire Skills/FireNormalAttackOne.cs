using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireNormalAttackOne : State
{
    public override void enterHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine charachter = (CharachterStateMachine)stateMachine;
        charachter.isAttacking = true;
        charachter.comboCode = 0;
        nameState = charachter.FIRE_ATTACK_ONE;
        charachter.animator.Play("Fire_NC1");
        charachter.AddAnimationPrefab(Resources.Load("Fire/Slash_0") as GameObject, new Vector3(1,0,0), false);
        charachter.Hit();
    }

    public override void inputHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine charachter = (CharachterStateMachine)stateMachine;
        PlayerInput playerInput = charachter.playerInput;

        if (charachter.comboCode == 1 && playerInput.Input.NormalAttack)
        {
            charachter.ChangeStateHandler(new FireNormalAttackTwo());
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
