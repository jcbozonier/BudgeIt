using System;

namespace BudgeIt.Registration
{
    public class RegistrationRequestMessage {
        readonly string PersonUserName;
        readonly string PersonPassword;

        public RegistrationRequestMessage(string personUserName,
                                          string personPassword)
        {
            PersonUserName = personUserName;
            PersonPassword = personPassword;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != typeof (RegistrationRequestMessage))
                return false;
            return Equals((RegistrationRequestMessage) obj);
        }

        public override string ToString()
        {
            return String.Format("RegistrationRequestMessage: {0}, {1}", PersonUserName, PersonPassword);
        }

        public bool Equals(RegistrationRequestMessage other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Equals(other.PersonUserName, PersonUserName) && Equals(other.PersonPassword, PersonPassword);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (PersonUserName.GetHashCode()*397) ^ PersonPassword.GetHashCode();
            }
        }
    }
}


