using System;

namespace MobileReview
{
    public class MobilePhoneFactory
    {
        public MobilePhone Create(string name, bool isFlagship = false)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            
            if (isFlagship)
            {
                if (!IsValidFlagshipName(name))
                {
                    throw new MobilePhoneCreationException(
                        $"{name} is not a valid name for a flagship mobile phone, flagship mobile phone names must contain 'Ultra' or 'Pro'",
                        name);
                }

                return new FlagshipMobilePhone {Name = name};
            }

            return new MidRangeMobilePhone { Name = name };
        }

        private bool IsValidFlagshipName(string name) => name.Contains("Ultra") || name.Contains("Pro");
    }
}
