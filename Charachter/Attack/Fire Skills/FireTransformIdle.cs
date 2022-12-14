using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTransformIdle : State
{
    private State []skills = { new FireSkillOne(), new FireSkillTwo(), new FireSkillThree(), new FireSkillFour()};
    public override void enterHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine charachter = (CharachterStateMachine)stateMachine;
        charachter.ChangeAnimation("FireTransform");
        nameState = charachter.FIRE_TRANSFORMATION_STATE;
    }

    public override void inputHandleState(StateMachine stateMachine)
    {
        CharachterStateMachine charachter = (CharachterStateMachine)stateMachine;

        if (charachter.UseSkill(skills))
        {
            return;
        }

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
