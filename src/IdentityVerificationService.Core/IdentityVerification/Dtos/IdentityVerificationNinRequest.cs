using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityVerificationService.IdentityVerificationRecord.Dtos
{
    public class IdentityVerificationNinRequest
    {
        public string id { get; set; }
        public bool premiumNin { get; set; }
        public bool isSubjectConsent { get; set; }
    }
}
