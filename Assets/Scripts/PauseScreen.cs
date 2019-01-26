using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{

  public GameObject pauseCanvas;

  // Start is called before the first frame update
  void Awake()
  {
    pauseCanvas.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyUp(KeyCode.Escape) &&
      UnityStandardAssets.Characters.FirstPerson.FirstPersonController.instance.enabled)
    {
      pauseCanvas.SetActive(true);
      UnityStandardAssets.Characters.FirstPerson.FirstPersonController.instance.enabled = false;
    }
  }

  public void ContinueGame()
  {
    pauseCanvas.SetActive(false);
    UnityStandardAssets.Characters.FirstPerson.MouseLook.instance.SetCursorLock(true);
    UnityStandardAssets.Characters.FirstPerson.FirstPersonController.instance.enabled = true;
  }

  public void NewGame()
  {
    SceneManager.LoadScene(0);
  }
}
