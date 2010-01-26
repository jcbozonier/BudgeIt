using BudgeIt.Registration;
using NUnit.Framework;

namespace Given_a_person_has_not_registered_as_a_user
{
    [TestFixture]
    public class When_creating_two_registration_request_messages_with_differing_content
    {
        string UserName;
        string Password;
        RegistrationRequestMessage MessageA;
        RegistrationRequestMessage MessageB;

        [Test]
        public void Ensure_they_are_NOT_equal()
        {
            Assert.That(MessageA, Is.Not.EqualTo(MessageB));
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            UserName = "UserName";
            Password = "Password";

            MessageA = new RegistrationRequestMessage(UserName + "1", Password);
            MessageB = new RegistrationRequestMessage(UserName, Password);
        }
    }
}