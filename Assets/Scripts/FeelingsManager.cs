using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeelingsManager : MonoBehaviour
{

    public GameObject Wet;
    public GameObject Cold;
    public Home Home;

    [ContextMenu("Stop All")]
    public void StopAll()
    {
        Wet.SetActive(false);
        Cold.SetActive(false);
        Home.gameObject.SetActive(false);
        Home.SetLevel(0);
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

    [ContextMenu("Start Home")]
    public void StartHome()
    {
        Home.gameObject.SetActive(true);
    }

    [ContextMenu("Next Home")]
    public void NextHome()
    {
        Home.NextHomeLevel();
    }

}
