using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDrops : MonoBehaviour
{

    public GameObject RainDrop;

    public float MinDeltaTime;
    public float MaxDeltaTime;

    IEnumerator Start()
    {
        while(true)
        {
            Instantiate(RainDrop, transform);
            yield return new WaitForSeconds(Random.Range(MinDeltaTime, MaxDeltaTime));
        }
    }

}
