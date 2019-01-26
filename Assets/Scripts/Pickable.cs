using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[@RequireComponent(typeof(Rigidbody))]
public class Pickable : MonoBehaviour, IPointerDownHandler
{
  private Transform cameraTransform;
  private Collider cameraCollider;
  private Rigidbody _rigidbody;
  private Collider _collider;
  private float holdDistance = 2f;
  private float maxSize = 1f;

  private void Awake()
  {
    _rigidbody = GetComponent<Rigidbody>();
    _collider = GetComponentInChildren<Collider>();
    var size = _collider.bounds.size;
    maxSize = Mathf.Max(size.x, Mathf.Max(size.y, size.z));
    holdDistance = maxSize * 2f;
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
        Physics.IgnoreCollision(_collider, cameraCollider, false);
      }
      else
      {
        Vector3 newPose = cameraTransform.position + (cameraTransform.forward * holdDistance);
        newPose.y = Mathf.Max(0.25f, newPose.y);
        transform.position = newPose;
        transform.rotation = Quaternion.Euler(0f, cameraTransform.eulerAngles.y, 0f);
      }
    }
  }

  private void FixedUpdate()
  {
    if (cameraTransform != null)
    {
      _rigidbody.velocity = Vector3.zero;
      _rigidbody.angularVelocity = Vector3.zero;
    }

        if (!_rigidbody.isKinematic && _rigidbody.IsSleeping())
            _rigidbody.isKinematic = true;
  }

  public void OnPointerDown(PointerEventData eventData)
  {
    cameraTransform = eventData.pressEventCamera.transform;
    cameraCollider = cameraTransform.GetComponentInParent<Collider>();
    Physics.IgnoreCollision(_collider, cameraCollider, true);
    _rigidbody.useGravity = false;
    _rigidbody.isKinematic = true;
  }
}
