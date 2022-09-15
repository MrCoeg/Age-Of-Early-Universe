using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRingState : State
{
    public override void enterHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine charachter = (CharachterStateMachine)stateMachine;
        nameState = charachter.FIRE_ATTACK_ONE;
        charachter.AddAnimationPrefab(Resources.Load("Fire/RingOfFire") as GameObject, new Vector3(2, 0, 0), true);
    }

    public override void inputHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine charachter = (CharachterStateMachine)stateMachine;
        PlayerInput playerInput = charachter.playerInput;

        if (charachter.MovementDetected(new FireMove()))
        {
            return;
        }

        charachter.ChangeStateHandler(new FireTransformIdle());
    }
}
