using BudgeIt.MessagingSystem;

namespace BudgeIt.Registration
{
    public class PersonRegistrationViewModel : ISubscriber
    {
        readonly MessagingBus MessagingSystem;

        public PersonRegistrationViewModel(MessagingBus messagingSystem)
        {
            MessagingSystem = messagingSystem;
            messagingSystem.Subscribe(this);
        }

        public void ReceiveUserRequestFromPerson(string personUserName,
                                                 string personPassword)
        {
            MessagingSystem.Publish(new RegistrationRequestMessage(personUserName, personPassword));
        }

        public void Receive(object message)
        {
            
        }
    }
}