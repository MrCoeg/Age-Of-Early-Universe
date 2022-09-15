using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : State
{
    [SerializeField] private Connectors connectors;
    public override void enterHandleState(StateMachine stateMachine)
    {
        EnemyStateMachine enemy = (EnemyStateMachine)stateMachine;
        enemy.ChangeAnimation("attack");
    }

    public override void updateHandleState(StateMachine stateMachine)
    {
        EnemyStateMachine enemy = (EnemyStateMachine)stateMachine;
        if (enemy.Hitted())
        {
            return;
        }

        if (enemy.AbleToAttack())
        {
            return;
        }

        if (enemy.AbleToMove())
        {
            Debug.Log("OK");
            return;
        }
    }
}
