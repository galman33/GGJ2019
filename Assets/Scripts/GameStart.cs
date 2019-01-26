using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameStart : MonoBehaviour
{
    public FirstPersonController FirstPersonController;
    public Image Black;
    public GameObject Reticle;


    private IEnumerator Start()
    {
        float f = 1f;

        Reticle.SetActive(false);

        while (f >= 0)
        {
            f -= Time.deltaTime;
            Black.color = new Color(0, 0, 0, f);
            yield return null;
        } 

        yield return new WaitForSeconds(3f);

        f = 0;
        while (f <= 1)
        {
            f += Time.deltaTime;
            Black.color = new Color(0, 0, 0, f);
            yield return null;
        } 

        FirstPersonController.enabled = true;
        FeelingsManager.Instance.StartCold();
        Reticle.SetActive(true);

        f = 1;
        while (f >= 0)
        {
            f -= Time.deltaTime;
            Black.color = new Color(0, 0, 0, f);
            yield return null;
        }

        Black.color = new Color(0, 0, 0, 0);
    }


}
