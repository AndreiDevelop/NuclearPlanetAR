using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPropsHolder : MonoBehaviour
{
    [SerializeField] protected PlanetProps _prefab;

    [SerializeField] protected int _count;
    public int Count => _count;

    [SerializeField] protected List<PlanetProps> _planetProps = new List<PlanetProps>();
    public List<PlanetProps> PlanetProps => _planetProps;

    public virtual void Initialize(PlanetController planetController)
    {
        StopAllCoroutines();
        StartCoroutine(InitializeWithDelay(planetController));
    }

    public virtual void Clear(PlanetController planetController)
    {
        StopAllCoroutines();
        StartCoroutine(ClearWithDelay(planetController));
    }

    protected virtual PlanetProps InstantiatePlanetProps()
    {
        return Instantiate(_prefab, transform);
    }

    private IEnumerator InitializeWithDelay(PlanetController planetController)
    {
        for (int i = 0; i < Count; i++)
        {
            PlanetProps planetProps = InstantiatePlanetProps();
            planetProps.Initialize(planetController);
            _planetProps.Add(planetProps);

            yield return null;
        }
    }

    private IEnumerator ClearWithDelay(PlanetController planetController)
    {
        if (_planetProps != null && _planetProps.Count > 0)
        {
            foreach (PlanetProps planetProps in _planetProps)
            {
                planetProps.Destroy(planetController);

                yield return null;
            }
        }

        _planetProps.Clear();
    }
}
