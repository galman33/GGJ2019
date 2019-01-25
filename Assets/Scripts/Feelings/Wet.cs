using DigitalRuby.RainMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wet : MonoBehaviour
{

    public GameObject RainDrops;
    public RainScript RainScript;

    private void OnEnable()
    {
        RainDrops.SetActive(true);
        RainScript.SetVolume(1);
    }

    private void OnDisable()
    {
        RainDrops.SetActive(false);
        RainScript.SetVolume(0.2f);
    }

}
