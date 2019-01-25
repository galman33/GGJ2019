using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeelingsChanger : MonoBehaviour
{

    public FeelingsManager FeelingsManager;

    public LayerMask WallsLayer;
    public LayerMask PropsLayer;

    public Transform BedRaysStart;

    public Transform BedMustRayChecks;
    public Transform[] BedRaysChecks;
    public int EnoughBedRayHits;

    public float RayCheckDistance;


    private GameObject[] _warmers;

    private void Start()
    {
        _warmers = GameObject.FindGameObjectsWithTag("Warmer");
    }

    private void Update()
    {
        switch(FeelingsManager.Feeling)
        {
            case FeelingsManager.Feelings.Wet:

                if (!Physics.Raycast(BedMustRayChecks.position, BedMustRayChecks.forward, RayCheckDistance, WallsLayer.value))
                    break;

                int rayHitsCount = 0;
                foreach (var t in BedRaysChecks)
                    if (Physics.Raycast(t.position, t.forward, RayCheckDistance, WallsLayer.value))
                        rayHitsCount++;

                if (rayHitsCount >= EnoughBedRayHits)
                    FeelingsManager.StartCold();

                break;
            case FeelingsManager.Feelings.Cold:
                foreach(var warmer in _warmers)
                {
                    float distance = Vector3.Distance(BedRaysStart.position, warmer.transform.position);
                    if (distance <= RayCheckDistance)
                    {
                        if(Physics.Raycast(BedRaysStart.position, warmer.transform.position - BedRaysStart.position, RayCheckDistance, WallsLayer.value))
                        {
                            FeelingsManager.StartHome();
                            break;
                        }
                    }
                }
                break;
            case FeelingsManager.Feelings.Home:
                break;
        }
    }
    
}
