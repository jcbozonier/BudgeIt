using BudgeIt;
using BudgeIt.MessagingSystem;
using BudgeIt.Registration;

namespace Given_a_person_has_not_registered_as_a_user
{
    public class TestingNotificationSystem : ISubscriber
    {
        public bool UserNotifiedThatTheyWereRegistered;

        public TestingNotificationSystem(MessagingBus messageSystem)
        {
            messageSystem.Subscribe(this);
        }

        public void Receive(object message)
        {
            if(message is RegistrationRequestMessage)
                UserNotifiedThatTheyWereRegistered = true;
        }
    }
}