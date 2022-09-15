using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkillThree : State
{
    public override void inputHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine charachter = (CharachterStateMachine)stateMachine;

        if (charachter.Talking())
        {
            return;
        }

        if (charachter.MovementDetected(new FireMove()))
        {
            return;
        }

        if (charachter.Attacking(new FireNormalAttackOne()))
        {
            return;
        }
    }
}
