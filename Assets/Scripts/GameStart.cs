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
        if (!Application.isEditor)
        {
            float f = 1f;

            Reticle.SetActive(false);

            while (f >= 0)
            {
                f -= Time.deltaTime;
                Black.color = new Color(0, 0, 0, f);
                yield return null;
            }

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            FeelingsManager.Instance.StartCold();
            //Cold.Instance.Go();


            f = 0;
            while (f <= 1)
            {
                f += Time.deltaTime * (1 / 3f);

                Camera.main.fieldOfView = Mathf.Lerp(15, 50, 1 - ((1 - f) * (1 - f)));

                yield return null;
            }

            FirstPersonController.enabled = true;
            Reticle.SetActive(true);
        }
        else
        {
            FeelingsManager.Instance.StartCold();
            FirstPersonController.enabled = true;
            Camera.main.fieldOfView = 50;
        }
    }


}
