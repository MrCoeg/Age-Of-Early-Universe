using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunState : State
{
    [SerializeField] private Connectors connectors;
    public override void enterHandleState(StateMachine stateMachine)
    {
        EnemyStateMachine enemy = (EnemyStateMachine)stateMachine;
        enemy.ChangeAnimation("idle");
        GameObject a = GameObject.FindGameObjectWithTag("Connector");
        
        if (a!= null)connectors = a.GetComponent<Connectors>();


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

        if (connectors != null && enemy.ableToMove)
        {
            enemy.Move(connectors.transform.position * Time.deltaTime * enemy.speed);
        }
    }




}
