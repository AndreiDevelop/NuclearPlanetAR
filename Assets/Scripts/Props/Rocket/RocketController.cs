using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RocketController : MonoBehaviour
{
    [SerializeField] private DOTweenPath _dotWeenPath;

    private  IEnumerator Start()
    {
        _dotWeenPath = GetComponent<DOTweenPath>();

        yield return new WaitForSeconds(1f);
        _dotWeenPath.DORestart();
        
    }

}
