using System.Text;

namespace MathLib;

public class ClassStruct
{
    
}


// Java 8 primitive types (VALUE types)  == assign makes a deep copy   , created on stack, destroyed when method returns
// all else are REFERENCE types = classes == assign copies the address , created on heap =  dynamic mem allocation (via "new")

// C#

public class MyDateTime
{
    public int Year { get; set; }
}

// When use structs vs classes
// small footprint vs large footprint

public class MethodLib2
{
    public static int Add(int x, int y)
    {
        return x + y;
    }
    public static int SuperSizeMe(ref int x)
    {
        x *= 100;
        return x;
    }
    public static MyInt SuperSizeMe(MyInt x)
    {
        x.Value *= 100;
        return x;
    }

    public static void Foo(int y)
    {
        y = 4;
    }
    public static void Foo(StringBuilder y)
    {
        y.Append("Q");
    }

    public static void Foo2(StringBuilder y)
    {
        y = new StringBuilder();
    }
    public static void Foo3(ref StringBuilder y)
    {
        y = new StringBuilder();
    }
    public static void Foo3(ref int y)
    {
        y = 4;
    }

    public static void Foo4(out int y)
    {
        y = 4;
    }
    public static void Foo5(in int y)
    {
        Console.WriteLine(y);
        int x = y * y;
    }
    public static (int, string, double) Foo6()
    {
        return (1, "one", 1.0);
    }

    public static dynamic Foo7()
    {
        return new {X=1,Y="one",Z=1.0};
    }

}

public class MyInt
{
    public int Value{ get; set; }
}