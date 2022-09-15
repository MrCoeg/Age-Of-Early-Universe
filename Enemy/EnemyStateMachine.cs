using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    [SerializeField] Animator animator;
    public bool isAttaked;
    public bool ableToMove;
    public bool ableToAttack;
    public float speed;

    [SerializeField] Connectors connectors;

    [Header("Stats")]
    [SerializeField] private float health;
    [SerializeField] private float damage;
    private void Start()
    {
        currentState = new EnemyRunState();
        animator = GetComponent<Animator>();
        connectors = GameObject.FindGameObjectWithTag("Connector").GetComponent<Connectors>();

        if(connectors.transform.position.x > this.transform.position.x)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
        }
        currentState.enterHandleState(this);
        
    }
    private void Update()
    {
        currentState.inputHandleState(this);
        currentState.updateHandleState(this);
    }

    public void ChangeStateHandler(State newState)
    {
        currentState.exitHandleState(this);
        ChangeStates(newState);
        currentState.enterHandleState(this);
    }

    public void ChangeAnimation(string newAnimation)
    {
        animator.Play(newAnimation);
    }

    public void Damaged(float damage, bool lifted, float speed)
    {

        ChangeStateHandler(new EnemyDamagedState());

        this.health -= damage;

        if (Random.Range(0,50) > 20)
        {
            GetComponent<AudioSource>().Play();
        }

        if (health <= 0)
        {
            currentState.exitHandleState(this);
            Destroy(this.gameObject);
        }

        if (lifted)
        {
            StartCoroutine(Lifted(speed));
        }


    }

    public IEnumerator Lifted(float speed)
    {
        float time = Time.time;
        float maxLifted = time + 2;
        while (time < maxLifted)
        {
            Debug.Log("Lifted");
            time += Time.deltaTime;
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            yield return null;
        }
    }

    IEnumerator stopMove()
    {
        float time = Time.time;
        float maxtime = time + 1;
        while(time < maxtime)
        {

            yield return null;
            ableToMove = true;
            isAttaked = false;
        }

    }

    public void Move(Vector3 target)
    {
        transform.Translate(target * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Connector")
        {
            ableToAttack = true;
            ableToMove = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Connector")
        {
            ableToAttack = false;
            ableToMove = true;
        }
    }

    public void AbleToAttackAndMove()
    {
        isAttaked = false;
    }

    public bool AbleToAttack()
    {
        if (ableToAttack && !isAttaked)
        {
            ChangeStateHandler(new EnemyAttackState());
            return true;
        }
        return false;
        
    }

    public bool AbleToMove()
    {
        if (ableToMove && !isAttaked)
        {
            ChangeStateHandler(new EnemyRunState());
            return true;
        }
        return false;
    }

    public void mymove()
    {
        isAttaked = false;
    }

    public void nomv()
    {
        isAttaked = true;
    }

    public bool Hitted()
    {
        if (isAttaked)
        {
            ChangeStateHandler(new EnemyDamagedState());
            return true;
        }
        return false;
    }

    public void AttackConnector()
    {
        connectors.Damaged(this.damage);
    }
}
