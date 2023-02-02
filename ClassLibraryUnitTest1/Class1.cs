namespace ClassLibraryUnitTest1
{
    public class MathLib
    {
        public static bool IsOdd(int n)
        {
            if (n < 0)
            {
                return n % 2 == -1;
            }
            return n % 2 == 1;
        } 
    }

    public class Foo { }
}