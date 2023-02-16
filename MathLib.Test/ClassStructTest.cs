using System.Runtime.InteropServices.JavaScript;
using FluentAssertions;

namespace MathLib.Test;


[TestClass]
public class ClassStructTest
{
    public void Foo(MyDateTime dt)
    {
        dt.Year = 1;
    }

    [TestMethod]
    public void DateTMyDateTimeime1()
    {
        MyDateTime d = new MyDateTime();
        d.Year = 0;
        Foo(d);
        d.Year.Should().Be(1);
    }

    [TestMethod]
    public void DateTime1()
    {
        var now = DateTime.Now;
        var startOfYear = new DateTime(2023,1,1);

        var ts =  (now - startOfYear);
        ts.Days.Should().BeGreaterOrEqualTo(45);
    }

    [TestMethod]
    public void BasicStruct()
    {
        int x=1; //
        Int32 y=2;
        x = y;
        short s;
        uint unsignedInt, q1=1, q2=2; // 0 -  4B
        unchecked
        {
            (q1 - q2).Should().Be(UInt32.MaxValue);
        }

        bool b;
        float f;
        decimal d; // T-SQL 

        double d1 = 1.0/3, d2=1/3.0;
        d2 = Math.Sqrt(Math.Sqrt(Math.Sqrt(Math.Sqrt(d2))));
        d2 = Math.Pow(Math.Pow(Math.Pow(Math.Pow(d2, 2), 2), 2), 2);

        const double Tolerance = 0.000_001; 
        d1.Should().BeApproximately(d2, Tolerance);

        // check for "equality" for fp

        Assert.IsTrue(Math.Abs(d1-d2) < Tolerance);

        d = 100.18m; // stored precisely
    }

    [TestMethod]
    public void MethodLib()
    {
        MethodLib2.Add(2,3).Should().Be(5);
        int a = 1;

        var myInt = new MyInt() { Value = 1 };
        MethodLib2.SuperSizeMe(myInt);
        myInt.Value.Should().Be(100);

        MethodLib2.SuperSizeMe(ref a);
        a.Should().Be(100);
    }


}