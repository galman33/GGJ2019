using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelFire : MonoBehaviour
{
    private void OnEnable()
    {
        Cold.Instance.Stop();
    }

}
