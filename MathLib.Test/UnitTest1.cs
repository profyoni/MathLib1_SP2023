

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
            String s = Gender.Male.Clothing();
            Assert.AreEqual("pants", s);
        }
        class Person // trivially simple to store enums in db
        {
            private String firstName, lasteName;
            private Gender g;
        }

        [TestMethod]
        public void EnumLanguageTest()
        {
            Assert.AreEqual(0, (int)T3.CellValue.None);
        }
    }
}