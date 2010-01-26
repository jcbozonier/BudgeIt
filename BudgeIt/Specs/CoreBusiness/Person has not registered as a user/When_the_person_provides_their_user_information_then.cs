using System.Linq;
using BudgeIt.MessagingSystem;
using BudgeIt.Registration;
using NUnit.Framework;

namespace Given_a_person_has_not_registered_as_a_user
{
    [TestFixture]
    public class When_the_person_provides_their_user_information_then
    {
        MessagingBus MessageSystem;
        PersonRegistrationViewModel ThePersonRegistrationViewModel;
        TestingNotificationSystem NotificationService;
        AggregatorOfType<RegistrationRequestMessage> TheRegistrationRequestAggregator;
        RegistrationRequestMessage ActualUserRegistrationRequestMessage;
        RegistrationRequestMessage ExpectedUserRegistrationRequestMessage;
        string PersonUserName;
        string PersonPassword;

        [Test]
        public void Ensure_the_user_is_notified_that_their_credentials_have_been_saved()
        {
            Assert.That(NotificationService.UserNotifiedThatTheyWereRegistered, Is.True);
        }

        [Test]
        public void Ensure_that_the_user_registration_message_is_correct()
        {
            Assert.That(ActualUserRegistrationRequestMessage, Is.EqualTo(ExpectedUserRegistrationRequestMessage));
        }

        void Context()
        {

            ExpectedUserRegistrationRequestMessage = new RegistrationRequestMessage(PersonUserName, PersonPassword);
        }

        void Because()
        {
            ThePersonRegistrationViewModel.ReceiveUserRequestFromPerson(PersonUserName, PersonPassword);
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            PersonUserName = "PersonUserName";
            PersonPassword = "PersonPassword";

            MessageSystem = new MessagingBus();
            NotificationService = new TestingNotificationSystem(MessageSystem);
            ThePersonRegistrationViewModel = new PersonRegistrationViewModel(MessageSystem);
            TheRegistrationRequestAggregator = new AggregatorOfType<RegistrationRequestMessage>(MessageSystem);

            Context();
            Because();

            ActualUserRegistrationRequestMessage = TheRegistrationRequestAggregator.ReceivedMessages.First();
        }
    }
}
