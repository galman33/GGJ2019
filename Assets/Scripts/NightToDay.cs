using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightToDay : MonoBehaviour
{

    public static NightToDay Instance;

    public AudioSource HappyMusic;
    public AudioSource SadMusic;

    public Transform Sun;

    private float _happiness;
    private Vector3 _sunRotation;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _sunRotation = new Vector3(-30, 0, 0);
    }

    void Update()
    {
        _sunRotation.x = Mathf.MoveTowards(_sunRotation.x, Mathf.Lerp(-20, 30, _happiness * _happiness), Time.deltaTime * 2f);
        Sun.eulerAngles = _sunRotation;
        HappyMusic.volume = Mathf.MoveTowards(HappyMusic.volume, _happiness, Time.deltaTime * 0.5f);
        SadMusic.volume = Mathf.MoveTowards(SadMusic.volume, 1 - _happiness, Time.deltaTime * 0.5f);
    }

    public void Next()
    {
        _happiness = Mathf.Clamp01(_happiness + 0.2f);
    }
}
