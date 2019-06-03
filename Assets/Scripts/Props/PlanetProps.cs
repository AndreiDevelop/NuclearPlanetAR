using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetProps : MonoBehaviour
{
    public const string TAG_NAME = "Planet Props";

    private GameObject _gameObject;
    public GameObject GameObject => _gameObject;

    protected PlanetController _planetController;

    private void Awake()
    {
        _gameObject = gameObject;
    }

    public virtual void Initialize(PlanetController planetController)
    {
        _planetController = planetController;
        ReplaceTheObject();
    }

    protected virtual void ReplaceTheObject()
    {
        PositionalManager.PlaceObjectOnPlanet(ref _gameObject, _planetController.gameObject);
    }

    public virtual void Destroy(PlanetController planetController)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(string.Equals(other.tag, TAG_NAME))
        {
            ReplaceTheObject();
        }
    }
}
