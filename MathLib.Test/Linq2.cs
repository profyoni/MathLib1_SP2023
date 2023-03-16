using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace MathLib.Test
{
    [TestClass]
    public class Linq2
    {
        [TestMethod]
        public void Aggregate()
        {
            var sum = Enumerable.Range(1, 10).Select(x => Math.Sqrt(x)).Sum();
            sum.Should().BeApproximately(22.468, .001);

            double avg = Enumerable.Range(1, 10).Average();
            avg.Should().Be(5.5);

            sum = Enumerable.Range(1, 10).Aggregate(0, (total, newVal) => total + newVal);
            sum.Should().Be(55);

            var prod =
                sum = Enumerable.Range(1, 4).Aggregate(1, (total, newVal) => total * newVal);
            sum.Should().Be(24);

            // String Aggregate
            var strAgg =
                Enumerable.Range(1, 4).Aggregate(
                    String.Empty, (total, newVal) => total + newVal + ",", t => t.Substring(0,t.Length-1));
            strAgg.Should().Be("1,2,3,4");
        }
        List<String> nameList = new List<String> { "Akiva", "AKiVAH", "ahron", "Shlomo", "Jim", "Geoff", "Bob", "Bill", "Jeff" };
        List<Person> PersonList = new List<Person>
        {
            new Person{FirstName = "Akiva", LastName = "Skaist"},
            new Person{FirstName = "Aaron", LastName = "Liff"}
        };

        [TestMethod]
        public void GroupBy()
        {
            
            // GOAL: PhoneBook with Alhabetical names and by Letter
            // use CANONICAL form - UpperCase
            var letterGroups =
                nameList.OrderBy(n => n.ToUpper())
                       .GroupBy(n => Char.ToUpper(n[0]));
            letterGroups.Count().Should().Be(5);
            var Agrp = letterGroups.First();
            Agrp.Key.Should().Be('A');
            Agrp.Count().Should().Be(3);
            Agrp.First().Should().Be("ahron");
           
            // TODO indexer == overloading [] operator
            Dictionary<String, String> dic = new Dictionary<string, string>();
            dic["Bob"] = "5551212";
            dic["Bob"].Should().Be("5551212");

        }

        [TestMethod]
        public void FlatteningLists()
        {
            Enumerable.Range(1, 10).First().Should().Be(1);
            Enumerable.Range(1, 10).First(x => x % 3 ==0).Should().Be(3);
            Enumerable.Range(1, 10).All(x => x % 100 == x).Should().BeTrue();
            Enumerable.Range(1, 10).Any(x => x % 100 == 98).Should().BeFalse();

            PersonList.First(p => p.FirstName == "Aaron").LastName.Should().Be("Liff");
            PersonList.FirstOrDefault(p => p.FirstName == "AAron").Should().BeNull();

            PersonList.Add( new Person(){FirstName = "Aaron"});
            // throws Exception PersonList.Single(p => p.FirstName == "Aaron")).
            PersonList.SingleOrDefault(p => p.FirstName == "AAron").Should().BeNull();

            Enumerable.Range(1, 10).Except(Enumerable.Range(3, 4)).Contains(9).Should().BeTrue();
            Enumerable.Range(1, 10).Intersect(Enumerable.Range(9, 4)).Contains(9).Should().BeTrue();

            Enumerable.Range(1, 10).Intersect(Enumerable.Range(9, 4)).Contains(8).Should().BeFalse();
        }

        void SpellingBee()
        {
            char center = 'P';
            // contain center letter
            var stages = nameList.Where(w => w.Contains(center));
            char[] allLetters = { 'A', 'W' }; 
            // ONLY contains any letter
            //stages = stages.Where(w => w.Contains());
        }
    }
}
