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

}

public class MyInt
{
    public int Value{ get; set; }
}