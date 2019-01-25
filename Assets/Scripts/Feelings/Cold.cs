using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cold : MonoBehaviour
{
    public FrostEffect FrostEffect;
    public AudioSource Breath;
    public AudioSource Cough;

    public float MinCoughDelta;
    public float MaxCoughDelta;

    private void OnEnable()
    {
        FrostEffect.enabled = true;
    }

    private void OnDisable()
    {
        FrostEffect.enabled = false;
    }

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(MinCoughDelta, MaxCoughDelta));
            Cough.Play();
        }
    }

    void Update()
    {
        FrostEffect.FrostAmount = Mathf.Sin(Time.time) * 0.05f + 0.425f;
    }
}
