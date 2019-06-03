using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TownsHolder : PlanetPropsHolder
{
    public TownController GetRandomTown()
    {
        int randIndex = Random.Range(0, PlanetProps.Count - 1);
        return PlanetProps.ElementAt(randIndex).GetComponent<TownController>();
    }
}
