﻿using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using FluentAssertions;
using Humanizer;

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

    [TestMethod]
    public void CultureInfo()
    {
        CultureInfo ci = new CultureInfo("en-US");
        var s = 5.ToWords(ci);
        s.Should().Be("five");


        CultureInfo ci2 = new CultureInfo("he-IL");
        var s2 = 5.ToWords(ci2);
        s2.Should().Be("חמש");
    }

    // Pass A Value vs Pass A Reference
    // identical to assignment

    [TestMethod]
    public void PassAndAssignment()
    {
        int x = 3, y = x;
        y = 4;
        x.Should().Be(3);

        MethodLib2.Foo(x);
        x.Should().Be(3);

        StringBuilder sb1 = new StringBuilder(), sb2 = sb1;
        sb2.Append("Q");
        sb1.ToString().Should().Be("Q");

        MethodLib2.Foo(sb1);
        sb1.ToString().Should().Be("QQ");

        MethodLib2.Foo2(sb1);
        sb1.ToString().Should().Be("QQ");


    }

    [TestMethod]
    public void Bar()
    {
        StringBuilder sb1 = new StringBuilder(), sb2 = sb1;
        sb2.Append("Q");

        MethodLib2.Foo3(ref sb1);
        sb1.ToString().Should().Be("");

        int x = 3;
        MethodLib2.Foo3(ref x);
        x.Should().Be(4);

        ref int z = ref x;
        z = 9;
        x.Should().Be(9);

        MethodLib2.Foo3(ref x);
    }

    [TestMethod]
    public void Out()
    {
        int z = 9;
        MethodLib2.Foo4(out z);
        z.Should().Be(4);

        String s = "99";
        int v;
        bool success = Int32.TryParse(s, out v);
        if (success)
        {
            v.Should().Be(99);
        }

        var q = MethodLib2.Foo6();
        q.Item2.Should().Be("one");
    }

    [TestMethod]
        public void Dynamic()
        {
        dynamic q2 = MethodLib2.Foo7();
        string p1 = q2.Y;
        p1.Should().Be("one");
    }

    [TestMethod]
    public void Coalesce()
    {
        string firstName = null,
            lastName = "Jones",
            address1 = null,
            address2 = "Flushing, NY 11367";

        //string labelledAddress = (firstName ?? "") + 
        //                         (lastName ?? "") + "\n" 
        //                         + (address1 ?? "") + (address2 ?? "");
        //labelledAddress.Should().Be("");

        // string interpoltaion
        int age = 87;
        decimal salary = 50_000;
        var sentence = $"{lastName} who is {age} years old, has a salary of {salary:C}";
        sentence.Should().Be("Jones who is 87 years old, has a salary of $50,000.00");
        
        // verbatim string
        var directory = "C:\\Home\\John\\Photos";
        directory.Length.Should().Be(19);
        string url = "http:\\\\www.example.com\\Folder1\\Folder2\\doc.html";

        directory = @"C:\Home\John\Photos";
        url = @"http:\\www.example.com\Folder1\Folder2\doc.html
line 2
line 3";
        url.Should().Contain("\n");
        //string salutation = "Dear {(firstName ?? "" + lastName)}" + ;

        // ?? ??=
        lastName ??= firstName;
        lastName.Should().NotBeNull();
    }

    // Java Checked Exceptions = IOException, cannot protect against (do not inherit from RunTimeException
    // Catch or Declare "throws"
    // Unchecked = you can check for and they really shouldnt be in good code (do inherit from RunTimeException

    // C# you can and should catch all kinds of excdeptions (no distinction between 
    [TestMethod]
    public void delegates()
    {
        // nullables
        int? x = 9;
        x = null;

        MethodLib2.executeManyTimes(100, Console.WriteLine);

    }
    public delegate double MathFunction(double a);

    [TestMethod]
    public void MathFuncs()
    {
        MathFunction g = Math.Sin;
        g(Math.PI/4).Should().BeApproximately(.7071, .001);
        g = Math.Asin;
        g(.7071).Should().BeApproximately(Math.PI / 4, .0001);

        g =  d => d*d; 
        g(9).Should().BeApproximately(81, .0001);
    }
    
    bool IsEvenLength(string a)
    {
        //throw new ArgumentOutOfRangeException();
        return a.Length % 2 == 0;

    }
    bool IsEven(int a)
    {
        return a % 2 == 0;

    }

    [TestMethod]
    public void LINQ() // Language integrated Queries
    {
        var list = new []{ 7, 3, 9, 23, 96 };

        var evenNumbers = list.Where(IsEven);

        evenNumbers.Should().Contain(96);


        var list2 = new[] { "erte", "iiu", "opoy"};

        var evenStrings = list2.Where(IsEvenLength);

        evenStrings.Should().Contain("erte");
        evenStrings.Should().Contain("erte");

        evenStrings = list2.Where(s => s.Length%2 == 0);

        evenStrings.Should().Contain("erte");
    }

    // LINQ uses "deferred execution" ; nothing gets executed until it is ACTUALLY needed
    // AND Repeatedly executed each time 
    [TestMethod]
    public void LINQ2()
    {
        var list2 = new[] { "erte", "iiu", "opoy" };

        var evenStrings = list2.Where(IsEvenLength);


    }


}

