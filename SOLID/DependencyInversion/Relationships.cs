using System.Collections.Generic;
using System.Linq;

namespace SOLID.DependencyInversion
{
    public class Relationships : IRelationshipBrowser
    {
        // This is not a great storage mechanism for relationships. We would like to change this in the future without breaking user code. If users are forced to use IRelationShip browser we can change Relationships at will
        private List<(Person, Relationship, Person)> _relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            _relations.Add((parent, Relationship.Parent, child));
            _relations.Add((child, Relationship.Child, parent));
        }

        // public List<(Person, Relationship, Person)> Relations => _relations;

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return _relations.Where(x => x.Item1.Name == name && x.Item2 == Relationship.Parent).Select(x => x.Item3);
        }
    }
}