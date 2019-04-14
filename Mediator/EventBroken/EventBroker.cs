using System;
using System.Reactive.Subjects;

namespace Mediator.EventBroken
{
    public class EventBroker : IObservable<PlayerEvent>
    {
        Subject<PlayerEvent> subscriptions = new Subject<PlayerEvent>();

        public IDisposable Subscribe(IObserver<PlayerEvent> observer)
        {
            return subscriptions.Subscribe(observer);
        }

        public void Publish(PlayerEvent playerEvent)
        {
            subscriptions.OnNext(playerEvent);
        }
    }
}