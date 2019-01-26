using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnBase : MonoBehaviour
{

    public GameObject ToEnable;


    private bool _firstTime = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Base"))
        {
            ToEnable?.SetActive(true);
            if(_firstTime)
            {
                _firstTime = false;
                if (gameObject.CompareTag("Happy"))
                    NightToDay.Instance.Next();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Base"))
        {
            ToEnable?.SetActive(false);
        }
    }

}
