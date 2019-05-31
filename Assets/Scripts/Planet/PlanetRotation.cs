using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour, IPlanetRotation
{
    [SerializeField] private float _rotateTime = 5f;
    public float RotateTime { get => _rotateTime; set => _rotateTime = value; }

    public void StartRotate()
    {
        StartCoroutine(Rotation());
    }

    public void StopRotate()
    {
        StopCoroutine(Rotation());
    }

    // Update is called once per frame
    private IEnumerator Rotation()
    {
        while(true)
        {
            float rotateByX = 0f;
            float rotateByY = (360 / (_rotateTime * 60 * 60)) * Time.deltaTime;
            float rotateByZ = 0f;

            transform.Rotate(rotateByX, rotateByY, rotateByZ, Space.Self);

            yield return new WaitForEndOfFrame();
        }
        
    }
}
