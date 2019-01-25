using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeelingsManager : MonoBehaviour
{

    public enum Feelings
    {
        Wet,
        Cold,
        Home
    }

    public GameObject Wet;
    public GameObject Cold;
    public Home Home;

    public Feelings Feeling { get; private set; }

    private void Start()
    {
        StartWet();
    }

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
        StopAll();
        Feeling = Feelings.Wet;
        Wet.SetActive(true);
    }

    [ContextMenu("Start Cold")]
    public void StartCold()
    {
        StopAll();
        Feeling = Feelings.Cold;
        Cold.SetActive(true);
    }

    [ContextMenu("Start Home")]
    public void StartHome()
    {
        StopAll();
        Feeling = Feelings.Home;
        Home.gameObject.SetActive(true);
    }

    [ContextMenu("Next Home")]
    public void NextHome()
    {
        Home.NextHomeLevel();
    }

    public void SetHomeLevel(int homeLevel)
    {
        Home.SetHomeLevel(homeLevel);
    }

}
