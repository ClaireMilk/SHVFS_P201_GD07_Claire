using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionEvent
{
    public CollectableComponent Collectable;

    public CollectionEvent(CollectorComponent collectable)
    {
        collectable = collectable;
    }
}
