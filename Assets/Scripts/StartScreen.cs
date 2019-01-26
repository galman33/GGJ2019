using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
  public GameObject startCanvas;
  public GameObject startText;
  private bool gameStart = false;

  void Awake()
  {
    startCanvas.SetActive(true);
  }

  public void StartGame()
  {
    if (gameStart)
    {
      return;
    }
    gameStart = true;
    startText.SetActive(false);
    StartCoroutine(StartGameCoroutine());
  }

  private IEnumerator StartGameCoroutine()
  {
    yield return new WaitForSeconds(0.5f);
    GameStart.instance.StartGame();
    startCanvas.SetActive(false);
  }
}
