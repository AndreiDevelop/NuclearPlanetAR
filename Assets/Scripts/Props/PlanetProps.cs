using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetProps : MonoBehaviour
{
    private GameObject _gameObject;

    private void Awake()
    {
        _gameObject = gameObject;
    }

    public virtual void Activate(PlanetController planetController)
    {

    }

    public virtual void Deactivate(PlanetController planetController)
    {

    }

    public virtual void Initialize(PlanetController planetController)
    {
        PositionalManager.PlaceObjectOnPlanet(ref _gameObject, planetController.gameObject);
    }

    public virtual void Destroy(PlanetController planetController)
    {

    }
}
