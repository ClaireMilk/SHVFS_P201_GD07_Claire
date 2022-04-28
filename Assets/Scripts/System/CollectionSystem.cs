using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionSystem : MonoBehaviour
{
    public void OnEnable()
    {
        Evently.Instance.Subscribe<CollectionEvent>(OnCollected);
    }

    public void OnDisable()
    {
        Evently.Instance.Ubsubscribe<CollectionEvent>(OnCollected);
    }

    private void OnCollected(CollectionEvent evt)
    {
        Destroy(evt.Collectable.gameObject);
    }
}
