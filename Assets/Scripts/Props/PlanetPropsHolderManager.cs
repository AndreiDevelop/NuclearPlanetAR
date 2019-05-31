using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlanetPropsHolderManager : MonoBehaviour
{
    [SerializeField] private List<PlanetPropsHolder> _propsHolderList;

    private Coroutine _initializePropsCoroutine;
    private Coroutine _clearPropsCoroutine;

    public virtual void Awake()
    {
        _propsHolderList = GetComponentsInChildren<PlanetPropsHolder>().ToList();
    }

    public virtual void InitializePropsHolders(PlanetController planetController)
    {
        if (_initializePropsCoroutine != null)
            StopCoroutine(_initializePropsCoroutine);

        _initializePropsCoroutine = StartCoroutine(InitializePropsHoldersWithDelay(planetController));
    }

    public virtual void ClearPropsHolders(PlanetController planetController)
    {
        if (_clearPropsCoroutine != null)
            StopCoroutine(_clearPropsCoroutine);

        _clearPropsCoroutine = StartCoroutine(ClearPropsHoldersWithDelay(planetController));
    }

    private IEnumerator InitializePropsHoldersWithDelay(PlanetController planetController)
    {
        if (_propsHolderList != null && _propsHolderList.Count > 0)
        {
            foreach (PlanetPropsHolder bufPlanetHolder in _propsHolderList)
            {
                bufPlanetHolder.Initialize(planetController);

                yield return null;
            }
        }
    }

    private IEnumerator ClearPropsHoldersWithDelay(PlanetController planetController)
    {
        if (_propsHolderList != null && _propsHolderList.Count > 0)
        {
            foreach (PlanetPropsHolder bufPlanetHolder in _propsHolderList)
            {
                bufPlanetHolder.Clear(planetController);

                yield return null;
            }
        }
    }
}
