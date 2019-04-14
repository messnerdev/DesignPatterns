using System.Collections.Generic;
using System.Linq;

namespace Mediator.ChatRoom
{
    public class ChatRoom
    {
        private List<Person> _people = new List<Person>();

        public void Join(Person p)
        {
            string joinMsg = $"{p.Name} joins the chat";
            _people.Add(p);
            p.Room = this;
            Broadcast(p, joinMsg);
        }

        public void Broadcast(Person source, string message)
        {
            foreach (Person person in _people.Where(x => !x.Equals(source)))
            {
                person.Receive(source, message);
            }
        }

        public void Message(Person source, Person destination, string message)
        {
            _people.FirstOrDefault(x => x.Equals(destination))?.Receive(source, message);
        }
    }
}