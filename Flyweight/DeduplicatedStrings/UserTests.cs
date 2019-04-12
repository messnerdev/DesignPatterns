using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;

namespace Flyweight.DeduplicatedStrings
{
    [TestFixture]
    public class UserTests
    {
        private readonly Random _rand = new Random(42);

        [Test]
        public void TestUser()
        {
            var users = new List<User>();
            foreach (string fullName in GenerateRandomFullNames(100, 10))
            {
                users.Add(new User(fullName));
            }

            ForceGC();
            dotMemory.Check(memory => Console.WriteLine(memory.SizeInBytes));
        }

        [Test]
        public void TestFlyweightUser()
        {
            var users = new List<FlyweightUser>();
            foreach (string fullName in GenerateRandomFullNames(100, 10))
            {
                users.Add(new FlyweightUser(fullName));
            }

            ForceGC();
            dotMemory.Check(memory => Console.WriteLine(memory.SizeInBytes));
        }

        private IEnumerable<string> GenerateRandomFullNames(int count, int length)
        {
            var firstNames = Enumerable.Range(0, count).Select(_ => RandomString(length));
            var lastNames = Enumerable.Range(0, count).Select(_ => RandomString(length));

            foreach (string firstName in firstNames)
            foreach (string lastName in lastNames)
            {
                yield return $"{firstName} {lastName}";
            }
        }

        private string RandomString(int length)
        {
            return new string(Enumerable.Repeat(0, length).Select(i => (char)('a' + _rand.Next(26))).ToArray());
        }

        private void ForceGC()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}