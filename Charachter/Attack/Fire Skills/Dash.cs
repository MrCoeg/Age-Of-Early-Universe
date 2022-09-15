using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public void DestroyAnimation()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharachterStateMachine>().isAttacking = false;
        if (this.gameObject != null)
        {
            Destroy(this.gameObject);
        }
    }
}
