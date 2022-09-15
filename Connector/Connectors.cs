using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connectors : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private SpriteRenderer render;
    [SerializeField] private SceneChanger scene;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {

        Vector3 bar = render.transform.localScale;

        bar.x = (health / maxHealth) * 5;
        render.transform.localScale = bar;
        
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Damaged(float damage)
    {
        health -= damage;
    }

    private void OnDestroy()
    {
        scene.ChangeScene();
    }
}
