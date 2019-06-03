using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbitController : MonoBehaviour
{
    [SerializeField] private float _minScale = 0.5f;
    [SerializeField] private float _maxScale = 2f;
    [SerializeField] private float rotateSpeed = 8f;

    private Coroutine _controllCamera;

    private void OnEnable()
    {
        StartControllCamera();
    }

    private void OnDisable()
    {
        StopControllCamera();
    }

    private void StartControllCamera()
    {
        StopControllCamera();
        _controllCamera = StartCoroutine(ControllCamera());
    }

    private void StopControllCamera()
    {
        if (_controllCamera != null)
            StopCoroutine(_controllCamera);
    }

    private IEnumerator ControllCamera()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();

            Rotate();

            Scale();
        }

    }

    private void Rotate()
    {
        if (Input.GetMouseButton(0))
        {
            float h = rotateSpeed * Input.GetAxis("Mouse X");
            float v = rotateSpeed * Input.GetAxis("Mouse Y");

            Vector3 rotationAngle = new Vector3(transform.localRotation.x - v, transform.localRotation.y + h, transform.localRotation.z);
            transform.Rotate(rotationAngle, Space.Self);
        }
    }

    private void Scale()
    {
        float scrollFactor = Input.GetAxis("Mouse ScrollWheel");

        if (scrollFactor != 0)
        {
            Vector3 newScale = transform.localScale * (1f - scrollFactor);

            transform.localScale = newScale.ClampGet(_minScale, _maxScale);
        }
    }
}
