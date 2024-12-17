using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityVerificationService.IdentityVerificationRecord.Dtos
{
    public class IdentityVerificationRequest
    {
        public string id { get; set; }
        public bool isSubjectConsent { get; set; }
        public bool premiumBVN { get; set; }
        public Metadata metadata { get; set; }
    }

    public class Metadata
    {
        public string requestId { get; set; }
    }
}
