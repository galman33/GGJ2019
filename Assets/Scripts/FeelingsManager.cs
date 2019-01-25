using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeelingsManager : MonoBehaviour
{

    public GameObject Wet;
    public GameObject Cold;

    [ContextMenu("Stop All")]
    public void StopAll()
    {
        Wet.SetActive(false);
        Cold.SetActive(false);
    }

    [ContextMenu("Start Wet")]
    public void StartWet()
    {
        Wet.SetActive(true);
    }

    [ContextMenu("Start Cold")]
    public void StartCold()
    {
        Cold.SetActive(true);
    }

}
