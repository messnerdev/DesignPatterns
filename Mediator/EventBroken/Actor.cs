using System;

namespace Mediator.EventBroken
{
    public class Actor
    {
        protected EventBroker Broker;

        public Actor(EventBroker broker)
        {
            Broker = broker ?? throw new ArgumentNullException(nameof(broker));
        }
    }
}