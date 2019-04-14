using Autofac;
using Mediator.ChatRoom;
using Mediator.EventBroken;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            ChatRoomExample();
            EventBrokerExample();
        }

        private static void ChatRoomExample()
        {
            var room = new ChatRoom.ChatRoom();

            var john = new Person("John");
            var jane = new Person("Jane");

            room.Join(john);
            room.Join(jane);

            john.Say("Hi");
            jane.Say("Oh, hey John");

            var simon = new Person("Simon");
            room.Join(simon);
            simon.Say("Hi everyone");

            jane.PrivateMessage(simon, "Please leave");
        }

        private static void EventBrokerExample()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<EventBroker>().SingleInstance();
            cb.RegisterType<FootballCoach>();
            cb.Register((c, p) => new FootballPlayer(c.Resolve<EventBroker>(), p.Named<string>("name")));

            using (var c = cb.Build())
            {
                var coach = c.Resolve<FootballCoach>();
                var player1 = c.Resolve<FootballPlayer>(new NamedParameter("name", "John"));
                var player2 = c.Resolve<FootballPlayer>(new NamedParameter("name", "Chris"));

                player1.Score();
                player1.Score();
                player1.Score();
                player1.AssaultReferee();
                player2.Score();
            }
        }
    }
}
