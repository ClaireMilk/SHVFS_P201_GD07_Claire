using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class DelegatesExample : MonoBehaviour
{
    // the compiler converts this into a class..
    // class MeDelegate{}
    // and since it's a class, we can create a new object from it..

    public delegate void MeDelegate();
    public delegate bool MeDelegateInt(int n);
    public delegate int MeDelegateReturnInt();
    public delegate T MeDelegateGeneric<T>();

    public void OnEnable()
    {
        // we are not invoking foo, we just passing it
        //MeDelegate meDelegate = new MeDelegate(Foo);

        /* this is a reference to a class.. but it's also treated like a method.
        the compiler is helping us here. we can call/invoke it with
        */

        //meDelegate.Invoke();
        // we can also invoke it like this.. the compiler gives us this syntatic sugar
        // if we write it like this, the compiler will turn it into meDelegate.Invoke();
        //meDelegate();

        // meDelegate reference Foo, so it's a reference to an object, and a method...
        // this is some more syntatic sugar.. a shorter way, but gets turned into the full bit in line 16
        //MeDelegate meDelegate2 = Goo;
        //meDelegate2();

        // we are treating methods like first class object
        // wrap your heads around this..
        //InvokeTheDelegate(Goo);

        // delegate are refenrences to object and methods

        // the same reason we parameterize this Square, it why we want to parameterize our code, or reference to code (method)

        //var result = GetAllNumbersLessThanTen(new List<int>() { 3, 5, 3567, 654, 245, 3, 12, 2 });

        //foreach(var number in result)
        //{
        //    Debug.Log(number);
        //}

        // how we can use Delegates to parameterize our GetAllNumbersLessThanFive?
        //var numbers = new List<int>() { 11, 42, 6, 3, 1 };

        // here we'll just change the number
        //var result = GetAllNumbersLessThanTen(numbers);

        // before the different wa just the number.. but now we are changed the exoression. we've change the code


        // var resultlessThanFive = RunNumbersThroughTheGauntlet(numbers, LessThanFive);
        // resultlessThanFive.ForEach(result => Debug.Log("Less than 5: " + result));

        // this is kind of neat. but. there's a problems ,and the problem is
        // we still have to deal with making these methods: LessThanFive, LessThanTen, etc.
        // there's a ton of junk

        // let's go back to lamdas.. we are passing in methods .. so why can't we just PASSTE the method itself?
        //var resultlessThanFive = RunNumbersThroughTheGauntlet(numbers, n => n < 5);
        //var resultlessThanTen = RunNumbersThroughTheGauntlet(numbers, n => n < 10);
        //var resultlessThanThirteen = RunNumbersThroughTheGauntlet(numbers, n => n < 13);

        // Delegate chaining
        // we can add and remove delegates...
        // there are immuntable!
        //MeDelegate meDelegate = Moo;
        //meDelegate = (MeDelegate)Delegate.Combine(meDelegate, (MeDelegate)Boo);
        //meDelegate = meDelegate + Sue;
        //meDelegate += Moo;
        //meDelegate -= Moo;

        //meDelegate.Invoke();

        //foreach(var d in meDelegate.GetInvocationList())
        //{
        //    Debug.Log("");
        //}

        //MeDelegateReturnInt meDelegate = ReturnFive;
        //meDelegate += ReturnTen;
        ////var value = meDelegate();

        //foreach (var d in meDelegate.GetInvocationList())
        //{
        //    Debug.Log(d.DynamicInvoke());
        //}

        //MeDelegateGeneric<int> meDelegate = ReturnFive;
        //meDelegate += ReturnTen;

        //foreach(var value in GetAllReturnValues(meDelegate))
        //{
        //    Debug.Log(value);
        //}

        // In reality .. you will almost never have to make your own delegates..
        // funcs and actions
        // funcs have a return

        //Func<int> meDelegate = ReturnFive;
        //meDelegate += ReturnTen;

        //Func<int, string> meDelegate = MultiplyAndReturnMessage;
        //Func<int, int>;
        //Debug.Log(meDelegate(5, 20));

        // Actions
        // all actions return void
        //Action<int> meDelegate = TakeAnIntAndReturnVoid;
        //meDelegate(234);

        // the difference between delegates and events..
        // an event is a delegate with two restrictions: you can't assign to it directly, and you can't invoke it directly
        Action myAction = ATrainsAComin;
        myAction += ATrainsAComin;
        myAction = null;
        myAction();

        var trainsSignal = new TrainsSignal();
        trainsSignal.TrainsAComing += ATrainsAComin;
        //trainsSignal.TrainsAComing = null;
        //trainsSignal.TrainsAComing.Invoke();
    }

    private void ATrainsAComin()
    {
        Debug.Log("");
    }

    public void TakeAnIntAndReturnVoid(int obj)
    {
        Debug.Log("Invoking our action: " + obj);
    }

    private static IEnumerable<T1> GetAllReturnValues<T1>(MeDelegateGeneric<T1> d)
    {
        foreach(MeDelegateGeneric<T1> del in d.GetInvocationList())
        {
            yield return del();
        }
    }

    private int ReturnFive() { return 5; }
    private int ReturnTen() { return 10; }

    static bool LessThanFive(int n)
    {
        return n < 5;
    }

    private List<int> RunNumbersThroughTheGauntlet(List<int> numbers, MeDelegateInt gauntlet)
    {
        return numbers.Where(number => gauntlet(number)).ToList();
    }

    private static List<int> GetAllNumbersLessThanTen(List<int> numbers)
    {
        return numbers.Where(numbers => numbers < 5).ToList();
    }

    public void InvokeTheDelegate(MeDelegate del)
    {
        del();
    }

    public void Foo()
    {
        Debug.Log("Foo");
    }

    public void Moo()
    {

    }

    public int Square(int x)
    {
        return x * x;
    }

    public void Sue()
    {

    }

    public void Boo()
    {

    }

    public class TrainsSignal
    {
        public event Action TrainsAComing
    }
}
