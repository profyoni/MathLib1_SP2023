using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using DateTime = System.DateTime;

namespace MathLib.Test
{
    [TestClass]
    internal class LINQ
    {
        [TestMethod]
        public void Where()
        {
            var list = new int[] { 8, 4, 81 };
            IEnumerable<int> odds = list.Where(x => x % 2 == 1); // java Iterable
            odds.Should().Contain(81);
            odds.Count().Should().Be(1);

            var people = new List<Person2>
            {
                new Person2()
                {
                    FirstName = "Akiva",
                    LastName = "Liff",
                    Birthday = DateTime.MaxValue
                },
                new Person2()
                {
                    FirstName = "Ahron",
                    LastName = "Skaist",
                    Birthday = DateTime.MinValue
                },
            };
            people.Where(p => p.LastName[0] == 'L').Should().Contain(people[0]);

            // Projection = sequence of Type A => sequence of Type B

            var names = people.Select(p => 
                new {Name = p.LastName + ", " + p.FirstName, Age = p.Age/90.0});
            names.First().Name.Should().Be("Liff, Akiva");
        }

        [TestMethod]
        public void Range()
        {
            var nums = Enumerable.Range(1, 2_000_000_000);
            nums.Count().Should().Be(2_000_000_000);

            var nums2 = Enumerable.Range(1, 200_000_000).ToList();
            nums2.Count().Should().Be(200_000_000);
        }

        [TestMethod]
        public void MyRange()
        {
            var nums = MyEnumerable.Range(1, 2);
            foreach (var i in nums)
                i.Should().Be(i);
        }

    }

    class Person2
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public int Age => (int)((DateTime.Today - Birthday).TotalDays / 365.25);

        public DateTime Birthday { get; set; }
    }
    class MyEnumerable
    {
        public static IEnumerable<int> Range(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                yield return i;
            }
        }
    }
}
