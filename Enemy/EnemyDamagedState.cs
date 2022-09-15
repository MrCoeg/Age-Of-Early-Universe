using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagedState : State
{
    [SerializeField] private Connectors connectors;
    public override void enterHandleState(StateMachine stateMachine)
    {
        EnemyStateMachine enemy = (EnemyStateMachine)stateMachine;
        enemy.GetComponent<Rigidbody2D>().gravityScale = 0;
        enemy.ChangeAnimation("move");
        enemy.isAttaked = true;
    }

    public override void updateHandleState(StateMachine stateMachine)
    {
        EnemyStateMachine enemy = (EnemyStateMachine)stateMachine;
        if (enemy.isAttaked)
        {
            return;
        }

        if (enemy.AbleToMove())
        {
            return;
        }
    }

    public override void exitHandleState(StateMachine stateMachine)
       
    {
        EnemyStateMachine enemy = (EnemyStateMachine)stateMachine;
        enemy.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
