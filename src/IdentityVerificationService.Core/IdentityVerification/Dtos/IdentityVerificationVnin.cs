using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityVerificationService.IdentityVerificationRecord.Dtos

{
    public class IdentityVerificationVnin
    {
        public string id { get; set; }  // Driver license number
        public bool isSubjectConsent { get; set; }  // Consent from the subject for the verification
    }
}
