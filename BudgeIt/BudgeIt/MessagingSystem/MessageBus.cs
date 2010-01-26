using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BudgeIt.MessagingSystem
{
    public class MessagingBus
    {
        readonly List<ISubscriber> _Subscribers;

        public MessagingBus()
        {
            _Subscribers = new List<ISubscriber>();
        }

        public void Subscribe(ISubscriber subscriber)
        {
            _Subscribers.Add(subscriber);
        }

        public void Publish(object message)
        {
            foreach (var subscriber in _Subscribers)
                subscriber.Receive(message);
        }
    }

    public interface ISubscriber {
        void Receive(object message);
    }
}
