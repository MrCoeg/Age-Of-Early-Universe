using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instancer : MonoBehaviour
{
    public GameObject []instancer;
    public int count;
    public Transform place;

    public void StartRespawn()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        float time = Time.time;
        int a = Random.Range(2, 10);
        float maxtime = time + a;
        while (count > 0)
        {
            time += Time.deltaTime;
            Debug.Log(time + " : " + maxtime);
            if (time > maxtime)
            {
                int b = Random.Range(0, instancer.Length - 1);
                Instantiate(instancer[b], place, false);
                count--;
                maxtime = time + Random.Range(2, 10);
            }
            yield return null;
        }

    }
}
