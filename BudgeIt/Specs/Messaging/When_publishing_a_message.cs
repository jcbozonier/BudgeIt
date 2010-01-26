using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgeIt.MessagingSystem;
using NUnit.Framework;

namespace Specs.Messaging
{
    [TestFixture]
    public class When_publishing_a_message
    {
        MessagingBus MessagingSystem;
        TestSubscriber Subscriber1;
        TestSubscriber Subscriber2;

        [Test]
        public void Ensure_that_each_subscriber_receives_the_message()
        {
            Assert.That(Subscriber1.MessageReceived, Is.Not.Null);
            Assert.That(Subscriber2.MessageReceived, Is.Not.Null);
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            MessagingSystem = new MessagingBus();

            Subscriber1 = new TestSubscriber(MessagingSystem);
            Subscriber2 = new TestSubscriber(MessagingSystem);

            MessagingSystem.Publish(new TestMessage());
        }
    }

    public class TestMessage {}

    public class TestSubscriber : ISubscriber
    {
        public object MessageReceived;

        public TestSubscriber(MessagingBus messagingSystem)
        {
            messagingSystem.Subscribe(this);
        }

        public void Receive(object message)
        {
            MessageReceived = message;
        }
    }
}
