using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorComponent : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<CollectableComponent>() != null)
        {
            Evently.Instance.Publish(new CollectionEvent(col.GetComponent))
        }
    }
}
