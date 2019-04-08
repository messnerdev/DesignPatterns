using System.Collections.Generic;
using Xunit;
using Autofac;

namespace Singleton.Tests
{
    public class SingletonTests
    {
        [Fact]
        public void IsSingletonTest()
        {
            var db1 = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;
            Assert.Equal(db1, db2);
            Assert.Equal(1, SingletonDatabase.ConstructorCallCount);
        }

        // This is bad, this is testing on the "production" database singleton instance
        [Fact]
        public void SingletonTotalPopulationTest()
        {
            var rf = new ProductionRecordFinder();
            IEnumerable<string> names = new[] {"Seoul", "Mexico City"};

            int tp = rf.GetTotalPopulation(names);
            Assert.Equal(17500000 + 17400000, tp);
        }

        // This is better, this tests on a dummy database
        [Fact]
        public void ConfigurableTotalPopulationTest()
        {
            var rf = new ConfigurableRecordFinder(new TestDatabase());
            IEnumerable<string> names = new[] { "alpha", "gamma" };

            int tp = rf.GetTotalPopulation(names);
            Assert.Equal(4, tp);
        }

        // This is best, the database itself is not forced to be singleton
        // The dependency injection framework ensures that it is singleton
        [Fact]
        public void DependencyInjectionPopulationTest()
        {
            var cb = new ContainerBuilder();

            // Provide Singleton of IDatabase as TestDatabase 
            cb.RegisterType<TestDatabase>().As<IDatabase>()
                .SingleInstance();

            // Provide new instance of ConfigurableRecordFinder
            cb.RegisterType<ConfigurableRecordFinder>();

            using (IContainer container = cb.Build())
            {
                var rf = container.Resolve<ConfigurableRecordFinder>();

                IEnumerable<string> names = new[] { "alpha", "gamma" };

                int tp = rf.GetTotalPopulation(names);
                Assert.Equal(4, tp);
            }
        }
    }
}