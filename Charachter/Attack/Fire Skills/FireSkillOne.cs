using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkillOne : State
{
    public override void enterHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine charachter = (CharachterStateMachine)stateMachine;
        charachter.AddAnimationPrefab(Resources.Load("Fire/DashStarter") as GameObject, new Vector3(0, 0, 0), true);
        charachter.isDashing = true ;
        charachter.isAttacking = true;
        charachter.ForceToMove(30);
    }

    public override void inputHandleState(StateMachine stateMachine)
    {

        CharachterStateMachine charachter = (CharachterStateMachine)stateMachine;
        PlayerInput playerInput = charachter.playerInput;

        if (charachter.comboCode == 0 && playerInput.Input.NormalAttack)
        {
            charachter.ChangeStateHandler(new FireNormalAttackTwo());
            return;
        }

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
        character.isDashing = false;
    }
}
