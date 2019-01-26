using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cold : MonoBehaviour
{
    public static Cold Instance;

    public FrostEffect FrostEffect;

    public void Stop()
    {
        if (gameObject.activeInHierarchy)
        {
            StopAllCoroutines();
            StartCoroutine(StopFrost());
        }
    }

    private IEnumerator StopFrost()
    {
        while(FrostEffect.FrostAmount > 0)
        {
            FrostEffect.FrostAmount -= Time.deltaTime * 0.25f;
            yield return null;
        }
        FrostEffect.enabled = false;
        FeelingsManager.Instance.StopAll();
    }

    public AudioSource Breath;
    public AudioSource Cough;

    public float MinCoughDelta;
    public float MaxCoughDelta;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        StartCoroutine(FrostLoop());
        StartCoroutine(Coughing());
    }

    private IEnumerator FrostLoop()
    {
        FrostEffect.enabled = true;
        FrostEffect.FrostAmount = 0;
        while (FrostEffect.FrostAmount < 0.425f)
        {
            FrostEffect.FrostAmount += Time.deltaTime * (1 / 3f) * 0.425f;
            yield return null;
        }

        float t = 0;

        while(true)
        {
            t += Time.deltaTime;
            FrostEffect.FrostAmount = Mathf.Sin(t) * 0.05f + 0.425f;
            yield return null;
        }


    }

    private IEnumerator Coughing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(MinCoughDelta, MaxCoughDelta));
            Cough.Play();
        }
    }

}
