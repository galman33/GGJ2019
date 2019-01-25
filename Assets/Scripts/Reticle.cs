using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Reticle : MonoBehaviour
{
  public RectTransform rectTransform;
  public Vector2 smallSize = new Vector2(8f, 8f);
  public Vector2 largeSize = new Vector2(16f, 16f);

  private StandaloneFPSInputModule standaloneFPSInputModule;
  private GameObject currentSelectedGameObject;

  void Awake()
  {
    rectTransform = GetComponent<RectTransform>();
  }

  void Start()
  {
    standaloneFPSInputModule = EventSystem.current.GetComponent<StandaloneFPSInputModule>();
  }

  void Update()
  {
    currentSelectedGameObject = standaloneFPSInputModule.GetCurrentHoveredGameObject();
    if (currentSelectedGameObject != null && currentSelectedGameObject.GetComponentInParent<Pickable>())
    {
      rectTransform.sizeDelta = largeSize;
    }
    else
    {
      rectTransform.sizeDelta = smallSize;
    }
  }
}
