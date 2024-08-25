using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;

    private void Start()
    {
       sprite =  GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        
    }
}
