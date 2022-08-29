using UnityEngine;
public class NormalAttackOne : State
{
    public override void enterHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        character.isAttacking = true;
    }
    public override void inputHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        PlayerInput playerInput = character.playerInput;
        
        if(character.comboCode == 1 && playerInput.Input.NormalAttack)
        {
            character.ChangeStateHandler(new NormalAttackTwo());
            return;
        }
        
        if (character.isAttacking || playerInput.Input.NormalAttack)
        {
            return;
        }

        if (character.MovementDetected())
        {
            return;
        }

        character.ChangeStateHandler(new NotAttackedState());
    }

    public override void updateHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        character.animator.SetBool("NC_1", character.isAttacking);
    }

    public override void exitHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine character = (CharachterStateMachine)stateMachine;
        character.isAttacking = false;
        character.comboCode = 0;
        character.animator.SetBool("NC_1", character.isAttacking);
    }
}
