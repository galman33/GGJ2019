using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnBase : MonoBehaviour
{

    public GameObject ToEnable;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Base"))
        {
            ToEnable.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Base"))
        {
            ToEnable.SetActive(false);
        }
    }

}
