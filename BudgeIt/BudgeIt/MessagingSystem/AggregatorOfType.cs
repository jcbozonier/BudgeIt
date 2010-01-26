using System;
using System.Collections.Generic;

namespace BudgeIt.MessagingSystem
{
    public class AggregatorOfType<T> : ISubscriber
    {
        public readonly List<T> ReceivedMessages;

        public AggregatorOfType(MessagingBus messageSystem)
        {
            ReceivedMessages = new List<T>();
            messageSystem.Subscribe(this);
        }

        public void Receive(object message)
        {
            if(message is T)
                ReceivedMessages.Add((T)message);
        }
    }
}