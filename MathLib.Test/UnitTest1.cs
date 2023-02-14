

using FluentAssertions;
using Humanizer;

namespace MathLib.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // AAA
            bool actual = ClassLibraryUnitTest1.MathLib.IsOdd(5);
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void TestMethod2()
        {
            // AAA
            bool actual = ClassLibraryUnitTest1.MathLib.IsOdd(-5);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void HumanizerLanguageTest()
        {
            String s = 100.ToWords();
            Assert.AreEqual(s, "one hundred");
        }

        
        [TestMethod]
        public void ExtTests()
        {
            String s = ExtensionMethods.Clothing(Gender.Male);
            Assert.AreEqual("pants", s);
            Gender.Male.Clothing().Should().Be("pants");
        }


        [TestMethod]
        public void ExtTests2()
        {
            String s = Gender.Male.Clothing();
            Assert.AreEqual("pants", s);
            Gender.Male.Clothing().Should().Be("pants");
        }

        [TestMethod]
        public void F1()
        {
            var f = new Fraction();
            Assert.AreEqual(0, f.Numerator);
            Assert.AreEqual(1, f.Denominator);
        }

        [TestMethod]
        public void F2()
        {
            var f = new Fraction { Numerator = 8 };
            Assert.AreEqual(8, f.Numerator);
            Assert.AreEqual(1, f.Denominator);
        }

        [TestMethod]
        public void AnonymousType()
        {
            var guy = new
            {
                Name = "Bob",
                Age = 23
            };
            guy.ToString().Should().Be("{ Name = Bob, Age = 23 }");
        }

        [TestMethod]
        public void OperatorOverloading()
        {
            Fraction f1 = new Fraction(3, 4),
                f2 = new Fraction(1, 2);

            var f3 = f1 * f2;
            f3.Should().Be(new Fraction(3, 8));
            var f4 = -f1;
            f4.Should().Be(new Fraction(3, -4));
        }

        [TestMethod]
        public void CastOperatorOverloading()
        {
            Fraction f1 = new Fraction(3, 4);
            f1 = 8;
            f1.Numerator.Should().Be(8);
            f1.Denominator.Should().Be(1);
        }

        [TestMethod]
        public void FloatCastOperatorOverloading()
        {
            const float PI_FLOAT = (float)Math.PI;
            Fraction f1 = (Fraction) PI_FLOAT;
            f1.Numerator.Should().Be(3_141_592);
            f1.Denominator.Should().Be(1_000_000);
            ((float)f1).Should().NotBe((float)Math.PI);
        }

        [TestMethod]
        public void OperatorOverloading2()
        {
            Fraction f = 1 + 3;
            f = f * 7;
            f = 5 * f * f;
        }

        [TestMethod]
        public void Props()
        {
            Person p = new Person(){FirstName = "Bill", LastName = "Gold"};
            p.FirstName = "Bob";
            p.LastName = "Smith";
            p.Initials.Should().Be("BS");
        }


        [TestMethod]
        public void EnumLanguageTest()
        {
            Assert.AreEqual(0, (int)T3.CellValue.None);
        }
    }
}