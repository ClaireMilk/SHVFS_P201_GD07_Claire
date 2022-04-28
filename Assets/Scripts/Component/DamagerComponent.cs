using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerComponent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DamagableComponent>())
        {
            Evently.Instance.Publish(new DamageEvent(other.GetComponent<DamagableComponent>()));
        }
    }
}
