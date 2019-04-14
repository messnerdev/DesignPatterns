using System;
using System.Reactive.Linq;

namespace Mediator.EventBroken
{
    public class FootballPlayer : Actor
    {
        public string Name { get; set; }
        public int GoalsScored { get; set; } = 0;

        public FootballPlayer(EventBroker broker, string name) : base(broker)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));

            broker.OfType<PlayerScoredEvent>()
                .Where(ps => !Name.Equals(ps.Name))
                .Subscribe(pe =>
                {
                    Console.WriteLine($"{Name}: nicely done, {pe.Name}! It's your {pe.GoalsScored} goal.");
                });

            broker.OfType<PlayerSentOffEvent>()
                .Where(ps => !Name.Equals(ps.Name))
                .Subscribe(pe =>
                {
                    Console.WriteLine($"{Name}: see you in the lockers, {pe.Name}");
                });
        }

        public void Score()
        {
            GoalsScored++;
            Broker.Publish(new PlayerScoredEvent(){GoalsScored = GoalsScored, Name = Name});
        }

        public void AssaultReferee()
        {
            Broker.Publish(new PlayerSentOffEvent() { Name = Name, Reason = "violence"});
        }
    }
}