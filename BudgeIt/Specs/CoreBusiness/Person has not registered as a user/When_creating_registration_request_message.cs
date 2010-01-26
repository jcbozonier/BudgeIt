using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgeIt.Registration;
using NUnit.Framework;

namespace Given_a_person_has_not_registered_as_a_user
{
    [TestFixture]
    public class When_creating_two_registration_request_messages_with_same_content
    {
        string UserName;
        string Password;
        RegistrationRequestMessage MessageA;
        RegistrationRequestMessage MessageB;

        [Test]
        public void Ensure_they_are_equal()
        {
            Assert.That(MessageA, Is.EqualTo(MessageB));
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            UserName = "UserName";
            Password = "Password";

            MessageA = new RegistrationRequestMessage(UserName, Password);
            MessageB = new RegistrationRequestMessage(UserName, Password);
        }
    }
}
