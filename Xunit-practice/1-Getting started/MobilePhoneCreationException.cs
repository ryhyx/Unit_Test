using System;

namespace MobileReview
{
    public class MobilePhoneCreationException : Exception
    {
        public MobilePhoneCreationException(string message, string mobilePhoneName) : base(message)
        {
            RequestedMobilePhoneName = mobilePhoneName;
        }

        public string RequestedMobilePhoneName { get; private set; }
    }
}
