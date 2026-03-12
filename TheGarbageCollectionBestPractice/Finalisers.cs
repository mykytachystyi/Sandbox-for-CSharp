using System;
using System.Collections.Generic;
// - a finaliser must only process its own object and never other referenced objects

// you cannot make any assymptions about the order in which your objects will be finalised.
// you should never try to use a referenced object in you finaliser, because it might already be finalised.
// you should never add finalisers to objects at the root of an object graph, only to objects at the edge.
// finalisers are not guaranteed to be called
// if the host proces exists, anything remaining in the finalisation queue after 4 seconds is discarded.

// finalisers are called in random order
// Objects with finalisers always end up in gen 1 and somethimes in gen 2
// when a process ends, some finalisers might not get called
// Finalisers are class methods that are called when objects are about to be cleaned up by the garbage collector.
// Many small short-lived objects with finalisers are bad, because the finaliser extends their lifetime into gen:1
// - only add finalisers to objects at the edge of an object graph
// - finalisers should never referene other objects
// - finalisers should be extremely short and run very quickly

namespace TheGarbageCollectionBestPractice;

public class Finalisers
{
    public void Test()
    {
        int count = 0;

        while(!Console.KeyAvailable)
        {
            new MyObject(count++);
        }

        Console.WriteLine("Terminating process...");
    }
}
public class MyObject
{
    private int _index = 0;
    public MyObject(int count)
    {
        _index = count;
        Console.WriteLine("Constructed object {0} in gen {1}", _index, GC.GetGeneration(this));
    }
    ~MyObject()
    {
        Thread.Sleep(500);
        Console.WriteLine("Finalized object {0} in gen {1}", _index, GC.GetGeneration(this));
    }
}
