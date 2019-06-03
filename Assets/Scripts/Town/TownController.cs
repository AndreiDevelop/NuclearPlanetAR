using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownController : PlanetProps
{
    [SerializeField] private Enemy _enemy;

    public override void Initialize(PlanetController planetController)
    {

    }

    public override void Destroy(PlanetController planetController)
    {

    }

    public virtual void Fire()
    {
       // _enemy.MoveTo(_planetController.);
    }
}
