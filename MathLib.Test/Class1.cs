using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Humanizer;
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

           
        }

        class NumberInfo
        {
            public int Number { get; set; }
            public string English { get; set; }
            public string RomanNumeral { get; set; }

        }

        [TestMethod]
        public void Select()
        {
            var nums = Enumerable.Range(1, 10).ToList();
            var romanNums = nums.Select(x => x.ToRoman());

            nums.Count().Should().Be(10);
            romanNums.Count().Should().Be(10);

            var numInfos = nums.Select(x => new NumberInfo
            {
                Number = x,
                English = x.ToWords(),
                RomanNumeral = x.ToRoman()
            });
            numInfos.First().English.Should().Be("one");

            // SELECT CHAR(FirstName) + CHAR(LastName) AS Initials, SSN FROM Names
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
                new { Initials = p.FirstName[0].ToString() + p.LastName[0], Age = p.Age / 90.0 });
            names.First().Initials.Should().Be("AL");


        }

        [TestMethod]
        public void OrderBy()
        {
            var numInfos = Enumerable.Range(1,10).Select(x => new NumberInfo
            {
                Number = x,
                English = x.ToWords(),
                RomanNumeral = x.ToRoman()
            });
            numInfos = numInfos.OrderBy(x => x.English)
                               .ThenBy(x=>x.RomanNumeral);
            numInfos.First().Number.Should().Be(8); 
            numInfos.Last().Number.Should().Be(2);

            numInfos.Take(3).Last().Number.Should().Be(4);
            numInfos.TakeLast(10).Sum(ni => ni.Number).Should().Be(55);
            Enumerable.Range(1, 10).Sum().Should().Be(55);
            Enumerable.Range(1, 10).Average().Should().Be(5.5);
            Enumerable.Range(1, 10).TakeWhile(x => x.ToWords() != "three")
                .Count().Should().Be(2);

            numInfos.Where(ni => !ni.RomanNumeral.Contains("I")).Count().Should().Be(2);
            numInfos.Count(ni => !ni.RomanNumeral.Contains("I")).Should().Be(2);

            // SELECT TOP 1000
            Enumerable.Range(1, 1_000_000).Skip(100).Take(10).First().Should().Be(101);
            Enumerable.Range(1, 1_000_000).Skip(100).Take(10).Last().Should().Be(110);
            Enumerable.Range(1, 1_000_000).Skip(12).First().Should().Be(13);

        }

        [TestMethod]
        public void GroupBy()
        {
            var groups = Enumerable.Range(1, 10).GroupBy(x => x % 3);
            var group1 = groups.First(g => g.Key == 1);
            group1.Count().Should().Be(4);
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
