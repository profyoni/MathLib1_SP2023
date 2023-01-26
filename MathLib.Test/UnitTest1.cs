

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
    }
}