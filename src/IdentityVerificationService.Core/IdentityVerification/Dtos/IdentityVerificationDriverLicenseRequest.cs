

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityVerificationService.IdentityVerificationRecord.Dtos
{
    public class IdentityVerificationDriverLicenseRequest
    {
        public string id { get; set; }  // Driver license number
        public bool isSubjectConsent { get; set; }  // Consent from the subject for the verification
        public Metadata metadata { get; set; }  // Metadata containing the request ID
    }
}


