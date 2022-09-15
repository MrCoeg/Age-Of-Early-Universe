using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slasher : MonoBehaviour
{
    public string stateName;
    private CharachterStateMachine charachter;
    private List<EnemyStateMachine> enemies;
    private bool activated;
    [SerializeField]private bool destorySelf;

    [SerializeField] private float timeToDestroy;

    private void Start()
    {
        enemies = new List<EnemyStateMachine>();
        if (destorySelf)
        {
            Destroy(this.gameObject, timeToDestroy);
        }
        charachter = GameObject.FindGameObjectWithTag("Player").GetComponent<CharachterStateMachine>();
    }
    public void DestroyAnimation()
    {
        if (this.gameObject != null)
        {
            Destroy(this.gameObject);
        }
    }

    public void ResetAttack()
    {
        charachter = GameObject.FindGameObjectWithTag("Player").GetComponent<CharachterStateMachine>();
        if (charachter.currentState.nameState == stateName)
        {
            charachter.isAttacking = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy") return;
        if (activated)
        {
            activated = false;
            enemies.Add(collision.gameObject.GetComponent<EnemyStateMachine>());
            for(int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] == null) continue;
                enemies[i].Damaged(charachter.damage, false, 0);
            }
            enemies.RemoveRange(0, enemies.Count-1);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag != "Enemy") return;
        if (activated)
        {
            activated = false;
            enemies.Add(collision.collider.gameObject.GetComponent<EnemyStateMachine>());
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] == null) continue;
                enemies[i].Damaged(charachter.damage, false, 0);
            }
            enemies.RemoveRange(0, enemies.Count - 1);
        }
    }

    public void Activate()
    {
        activated = true;
    }

}
