using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericsExample : MonoBehaviour
{
    public void OnEnable()
    {
        // GetComponent is a generic method...
        // We can have generic methods And generic classes
        var animator = gameObject.GetComponent<Animator>();

        //var pairIntInt = new PairIntInt() { First = 5, Second = 65 };
        //Debug.Log("Type: " + pairIntInt.GetType());

        //MyClass<string>.value = 10;
        //MyClass<int>.value = 23;
        //MyClass<float>.value = 23454235;

        var numbers = new List<int>() { 123, 45, 6, 2, 7, 88 };
        PrintTheNumbers(numbers);
        
        //with generic methods, the compiler is SMART enough to know the type
    }

    //we can have generic classes, and we can also have generic Methods
    private void PrintTheNumbers(List<int> numbers)
    {
        foreach(var number in numbers)
        {
            Debug.Log(number);
        }
    }

    private void PrintTheThings<T>(List<T> things)
    {
        foreach (var thing in things)
        {
            Debug.Log(thing);
        }
    }
}

// Constaints are useful, and somtimes necessary, but the more u use, the less your generic method, is a generic method

public class PairIntInt
{
    public int First;
    public int Second;
}

public class PairStringString
{
    public string First;
    public string Second;
}

public class Pair<T1, T2>
{
    public T1 First;
    public T2 Second;
}

public class MyClass<T>
{
    public static int value;

    static MyClass()
    {
        Debug.Log(typeof(MyClass<T>));
    }
}

public class ClassOne
{
    public void Setup()
    {
        Debug.Log("fu");
    }
}
