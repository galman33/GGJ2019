using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeelingsChanger : MonoBehaviour
{

    public FeelingsManager FeelingsManager;

    public Transform BedMustRayChecks;
    public Transform[] BedRaysChecks;
    public float BedRayCheckDistance;
    public int EnoughBedRayHits;


    private void Update()
    {
        switch(FeelingsManager.Feeling)
        {
            case FeelingsManager.Feelings.Wet:

                if (!Physics.Raycast(BedMustRayChecks.position, BedMustRayChecks.forward, BedRayCheckDistance))
                    break;

                int rayHitsCount = 0;
                foreach (var t in BedRaysChecks)
                    if (Physics.Raycast(t.position, t.forward, BedRayCheckDistance))
                        rayHitsCount++;

                if (rayHitsCount >= EnoughBedRayHits)
                    FeelingsManager.StartCold();

                break;
            case FeelingsManager.Feelings.Cold:
                break;
            case FeelingsManager.Feelings.Home:
                break;
        }
    }
    
}
