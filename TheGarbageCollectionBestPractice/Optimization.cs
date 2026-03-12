using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGarbageCollectionBestPractice
{
    internal class Optimization
    {
    }
}
/*

wrong, beacuse a lot of .toString() memory allocated
stringbuilder s  = new stringbuilder();
for (int i=0; i < 1000000; i++)
{
    s.Append(i.toString() + "KB");
}

right
stringbuilder s  = new stringbuilder();
for (int i=0; i < 1000000; i++)
{
    s.Append(i);
    s.Append("KB");
} 

wrong, because a lot of boxing/unboxing
ArrayList list = new ArrayList()
for (int i=0; i < 1000000; i++)
{
    list.Add(i);
}

right
List<int> list = new List<int>();
for (int i=0; i < 1000000; i++)
{
    list.Add(i);
}

wrong 
public static MyObject obj = new MyObject();
...
// lots of other code 
...
UseTheObject(obj);

right - using object just in moment we need
MyObject obj = new MyObject();
UseTheObject(obj);
obj = null; // dereference the object



// Re-use objects. Object pooling

// wrong
ArrayList list = new ArrayList();
UseTheList(list);
...
list = new ArrayList();
UseTheList(list);

// right
ArrayList list = new ArrayList();
UseTheList(list);
...
list.Clear();
UseTheList(list);

// wrong
ArrayList list = new ArrayList()
for (int i=0; i < 1000000; i++)
{
  list.Add(new Pair(i, i+1));
}

// right, because int is value type that store in stack
int[] list = new int[1000000];
int[] list2 = new int[1000000];
for (int i=0; i < 1000000; i++)
{
  list[i] = i;
  list2[i] = i+1;
}


//Spit objects into smaller objects or Reduce footprint
// wrong
int[] buffer = new int[32768];
for (int i=0; i < 32768; i++)
{
    buffer[i] = GetByte(i);
}

// right, already in byte
byte[] buffer = new byte[32768];
for (int i=0; i < 32768; i++)
{
  buffer[i] = GetByte(i);
}

// merge object together or resize lists
// wrong
public static ArrayList list = new ArrayList();
...
// lots of other code
...
UseTheList(list);

// right
public static ArrayList list = new ArrayList(85190);
...
// lots of other code
...
UseTheList(list);


- limit the number of objects created
- allocatem use, and discard small object as fast as possible
- re-use large object

- use only small short-lived, and large long-lived objects

- increase lifetime or descrease size of large short-live objects
- descrease lifetime or increase size of small long-lived objects






 */