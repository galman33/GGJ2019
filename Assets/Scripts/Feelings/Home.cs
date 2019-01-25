using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{

    public AudioSource HomeMusic;
    public Transform Sun;

    public float MinVolume;
    public float MaxVolume;

    public float MinSunAngle;
    public float MaxSunAngle;

    public int Levels;

    private float _levelTarget;
    private float _level;

    public void SetLevel(int level)
    {
        _levelTarget = level;
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        _levelTarget = _level = 0;
        UpdateLevel();
    }

    private void Update()
    {
        _levelTarget = Mathf.Clamp(_levelTarget, 0, Levels);
        _level = Mathf.SmoothStep(_level, _levelTarget, Time.deltaTime * 2);
        UpdateLevel();
    }

    private void UpdateLevel()
    {
        HomeMusic.volume = Mathf.Lerp(MinVolume, MaxVolume, _level / Levels);

        var sunAngles = Sun.localEulerAngles;
        sunAngles.x = Mathf.Lerp(MinSunAngle, MaxSunAngle, _level / Levels);
        Sun.localEulerAngles = sunAngles;
    }

    public void NextHomeLevel()
    {
        _levelTarget++;
    }

    internal void SetHomeLevel(int homeLevel)
    {
        throw new NotImplementedException();
    }
}
