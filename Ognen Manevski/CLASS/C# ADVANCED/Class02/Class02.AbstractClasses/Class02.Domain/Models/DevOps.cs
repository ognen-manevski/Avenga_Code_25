using Class02.Domain.BaseEntity;
using Class02.Domain.Interfaces;

namespace Class02.Domain.Models
{
    public class DevOps : Person, IDeveloper, IOperations
    {        
        public bool AWSCertified { get; set; }
        public bool AzureCertified { get; set; }

        //ctor
        public DevOps
            (
                string firstName,
                string lastName,
                int age,
                string mobileNumber,
                bool awsCertified,
                bool azureCertified
            )
            : base(firstName, lastName, age, mobileNumber)
        {
            AWSCertified = awsCertified;
            AzureCertified = azureCertified;
        }

        public override string GetInfo()
        {
            return @$"{GetFullName()} ({Age}) - Has {(AWSCertified ? "AWS Certificate" : "")}{(AzureCertified ? "Azure Certificate" : "")}{(AWSCertified || AzureCertified ? "" : "No certificates yet")}";
        }

        public void Code()
        {
            Console.WriteLine("tap tap tap...");
            Console.WriteLine("Create pipeline...");
            Console.WriteLine("tap tap tap");
        }

        public bool CheckInfrastructure(int status)
        {
            if (status >=200 || status < 300)
            {
                return true;
            }
            return false;
        }
    }
}

