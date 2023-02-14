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
        ts.Days.Should().Be(43);
    }
    
}