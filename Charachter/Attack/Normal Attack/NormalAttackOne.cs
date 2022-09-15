using UnityEngine;
public class NormalAttackOne : State
{
    public override void enterHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        character.isAttacking = true;
        character.animator.Play("Shield_Attack");
    }
    public override void inputHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        PlayerInput playerInput = character.playerInput;

        if (character.ChangeTransform())
        {
            return;
        }
        
        if(character.comboCode == 1 && playerInput.Input.NormalAttack)
        {
            character.ChangeStateHandler(new NormalAttackTwo());
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

    public override void exitHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        character.isAttacking = false;
        character.comboCode = 0;
    }
}
