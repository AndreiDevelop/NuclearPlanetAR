using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(PlanetController))]
public class PlanetController : MonoBehaviour
{
    protected PlanetPropsHolderManager _planetPropsHolderManager;
    protected PlanetRotation _planetRotation;

    protected virtual void Awake()
    {
        _planetPropsHolderManager = GetComponentInChildren<PlanetPropsHolderManager>();
        _planetRotation = GetComponent<PlanetRotation>();

        InitializePlanet();
    }

    public virtual void InitializePlanet()
    {
        _planetPropsHolderManager.InitializePropsHolders(this);
        _planetRotation?.StartRotate();
    }

    public virtual void ClearPlanet()
    {
        _planetPropsHolderManager.ClearPropsHolders(this);
        _planetRotation?.StopRotate();
    }
}
