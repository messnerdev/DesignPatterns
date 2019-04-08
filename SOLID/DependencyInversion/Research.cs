using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLID.DependencyInversion
{
    public class Research
    {
        //public Research(Relationships relationships)
        //{
        //    var relations = relationships.Relations;
        //    foreach (var valueTuple in relations.Where(x => x.Item1.Name == "John" && x.Item2 == Relationship.Parent))
        //    {
        //        Console.WriteLine($"John has a child called {valueTuple.Item3.Name}");
        //    }
        //}

        public Research(IRelationshipBrowser browser)
        {
            foreach (Person child in browser.FindAllChildrenOf("John"))
            {
                Console.WriteLine($"John has a child called {child.Name}");
            }
        }
    }
}