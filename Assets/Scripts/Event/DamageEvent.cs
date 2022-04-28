using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEvent
{
    public DamagableComponent Damagable;

    public DamageEvent(DamagableComponent damagable)
    {
        Damagable = damagable;
    }
}
