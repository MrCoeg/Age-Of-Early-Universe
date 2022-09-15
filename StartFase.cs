using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFase : MonoBehaviour
{
    public Instancer[] instancer;
    public Animator animator;
    public SpriteRenderer button;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        for(int i = 0; i < instancer.Length; i++)
        {
            if(instancer[i].count > 0)
            {
                return;
            }
        }

        Debug.Log("Win");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.Play("entrance");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;
        if (Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < instancer.Length; i++)
            {
                instancer[i].StartRespawn();
            }
            Destroy(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.Play("outrance");
        }
    }
}
