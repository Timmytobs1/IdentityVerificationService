using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityVerificationService.IdentityVerificationRecord.Dtos
{
    public class IdentityVerificationBusiness
    {
        public string registrationNumber { get; set; }
        public bool isConsent { get; set; }
        public string countryCode { get; set; }
    }
}
