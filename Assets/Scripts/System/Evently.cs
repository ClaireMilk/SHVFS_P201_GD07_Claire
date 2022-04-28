using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Evently
{
    // private static eventManagerInstance
    // public static Instance => private member

    private static Evently eventManagerInstance;

    // null coalescing assignment c# 8.0
    // if it's null, assign it to a new Evently()
    // otherwise, just return eventManagerInstance ( the right side never gets evaluated)
    // tl;dr just some fancy c# syntax
    public static Evently Instance => eventManagerInstance ??= new Evently();

    private readonly Dictionary<Type, Delegate> delegates = new Dictionary<Type, Delegate>();

    //signatures for these methods

    public void Subscribe<T>(Action<T> del)
    {
        if (delegates.ContainsKey(typeof(T)))
        {
            delegates[typeof(T)] = Delegate.Combine(delegates[typeof(T)], del);
        }
        else
        {
            delegates[typeof(T)] = del;
        }
    }

    public void Unsubscribe<T>(Action<T> del)
    {
        if (delegates.ContainsKey(typeof(T))) return;

        var tempDelegate = Delegate.Remove(delegates[typeof(T)], del);

        if(tempDelegate == null)
        {
            // housekeeping, to keep our dictionary clean
            delegates.Remove(typeof(T));
        }
        else
        {
            delegates[typeof(T)] = tempDelegate;
        }
    }

    public void Publish<T>(T e)
    {
        if(e == null)
        {
            return;
        }

        if (delegates.ContainsKey(e.GetType()))
        {
            delegates[e.GetType()].DynamicInvoke();
        }
    }
}
