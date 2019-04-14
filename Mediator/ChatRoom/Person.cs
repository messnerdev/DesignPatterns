using System;
using System.Collections.Generic;

namespace Mediator.ChatRoom
{
    public class Person
    {
        public string Name;
        public Mediator.ChatRoom.ChatRoom Room;
        private readonly List<string> _chatLog = new List<string>();

        public Person(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void Say(string message)
        {
            Room.Broadcast(this, message);
        }

        public void PrivateMessage(Person destination, string message)
        {
            Room.Message(this, destination, message);
        }

        public void Receive(Person sender, string message)
        {
            string s = $"{sender.Name}: '{message}'";
            _chatLog.Add(s);
            Console.WriteLine($"[{Name}'s chat session] {s}");
        }
    }
}