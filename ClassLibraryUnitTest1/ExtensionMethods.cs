using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib
{
    /// <summary>
    /// An Immutable Fraction
    /// </summary>
    public class Fraction
    {
        // Prefer readonly to const
        // readonly is a var stored in RAM, but the compiler will not let your code change it (like Java final)
        private readonly int num, den; // const is replaced at compile time with its value

        public Fraction(int num = 0, int den = 1) // default args
        {
            if (den == 0)
                throw new ArgumentOutOfRangeException("den must not be 0");
            this.num = num;
            this.den = den;
        }
        //public Fraction(int num) : this(num, 1)
        //{
        //}
        //public Fraction(): this(0)
        //{
        //}

        public int Numerator
        {
            init // setter for ctor / initlizer 
            {
                num = value;
            }
            get
            {
                return num;
            }

            
        }
        public int Denominator
        {
            init
            {
                den = value;
            }
            get
            {
                {
                    return den;
                }
            }
        }
        public override bool Equals(Object that)
        {
            return this == (Fraction)that;
        }
        public static bool operator==(Fraction a, Fraction b)
        {
            return a.Denominator * b.Numerator ==
                   a.Numerator * b.Denominator;
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Numerator,
                a.Denominator * b.Denominator);
        }

        public static Fraction operator-(Fraction a)
        {
            return new Fraction(-a.Numerator,
                a.Denominator);
        }

        public static implicit operator Fraction(int x)
        {
            return new Fraction(x);
        }

        //lossy op
        public static explicit operator Fraction(float x)
        {
            const int accuracy = 1_000_000;
            return new Fraction(
                (int)(x * accuracy), accuracy);
        }
        public static implicit operator float(Fraction x)
        {
            return (float)x.Numerator / x.Denominator;
        }
    }

    // properties are methods disguised as Fields
    public class Person // trivially simple to store enums in db
    {
        private String firstName, lastName;
        private Gender g;

        public String Initials
        {
            get { return "" + FirstName[0] + LastName[0]; }
        }
        public String FirstName
        {
            get { return firstName; }
            set
            {
                if (value == null || value.Length <= 1)
                    throw new ArgumentException("Whoah youi have no name?");
                firstName = value;
            }

        }
        public String LastName
        {
            get { return lastName; }
            set
            {
                if (value == null || value.Length <= 1)
                    throw new ArgumentException("Whoah youi have no name?");
                lastName = value;
            }

        }
    }

    public enum Gender { Unknown, Male, Female } // no enhanced enums

    public static class ExtensionMethods
    {
        public static String Clothing(this Gender g)
        {
            if (g == Gender.Male)
            {
                return "pants";
            }
            else return "";
        }
    }
}
