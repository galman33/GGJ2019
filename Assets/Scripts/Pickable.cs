using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[@RequireComponent(typeof(Rigidbody))]
public class Pickable : MonoBehaviour, IPointerDownHandler
{
  private Transform cameraTransform;
  private Rigidbody _rigidbody;

  private void Awake()
  {
    _rigidbody = GetComponent<Rigidbody>();
  }

  private void Update()
  {
    if (cameraTransform != null)
    {
      if (Input.GetMouseButtonUp(0))
      {
        cameraTransform = null;
        _rigidbody.useGravity = true;
        _rigidbody.isKinematic = false;
      }
    }
  }

  private void FixedUpdate()
  {
    if (cameraTransform != null)
    {
      _rigidbody.velocity = Vector3.zero;
      _rigidbody.angularVelocity = Vector3.zero;
      _rigidbody.MovePosition(cameraTransform.position + (cameraTransform.forward * 2f));
      _rigidbody.MoveRotation(cameraTransform.rotation);
    }
  }

  public void OnPointerDown(PointerEventData eventData)
  {
    cameraTransform = eventData.pressEventCamera.transform;
    _rigidbody.useGravity = false;
    _rigidbody.isKinematic = true;
  }
}
