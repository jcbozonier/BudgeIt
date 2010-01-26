using System.Linq;
using BudgeIt.MessagingSystem;
using NUnit.Framework;

namespace Specs.Messaging
{
    [TestFixture]
    public class When_aggregating_messages_of_a_certain_type
    {
        MessagingBus TheMessagingBus;
        AggregatorOfType<TestMessage> Aggregator;

        [Test]
        public void Ensure_that_the_test_message_is_received()
        {
            Assert.That(Aggregator.ReceivedMessages.Count, Is.EqualTo(1));
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            TheMessagingBus = new MessagingBus();
            Aggregator = new AggregatorOfType<TestMessage>(TheMessagingBus);

            Because();
        }

        void Because()
        {
            TheMessagingBus.Publish(new TestMessage());
        }
    }
}
