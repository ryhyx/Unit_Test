using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MobileReview
{
    public class MobilePhoneSpecification
    {
        
        public string CompanyName { get ; set; }
        public string ModelName { get; set; }
        public string FullName => $"{CompanyName} {ModelName}";
        public string OperatingSystem { get; set; }
        public int BatteryCharge { get; set; }

        public bool IsFastCharge { get; set; }
        public List<string> Networks { get; set; } 


        public MobilePhoneSpecification()
        {
            CompanyName = GenerateRandomCompanyName();

            OperatingSystem = string.Empty;

            ModelName = string.Empty;

            IsFastCharge = true;

            Networks = CreateNetworks();
        }

        private string GenerateRandomCompanyName()
        {
            var possibleRandomStartingNames = new[]
            {
                "Samsung",
                "Apple",
                "Nokia",
                "Xiaomi",
                "Huawei"
            };

            return possibleRandomStartingNames[
                new Random().Next(0, possibleRandomStartingNames.Length)];
        }

        private List<string> CreateNetworks()
        {
            return new List<string>
            {
                "2G",
                "3G",
                "4G",
                "5G",
            };
        }
    
    }
}