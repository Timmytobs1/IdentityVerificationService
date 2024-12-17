using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityVerificationService.IdentityVerificationRecord.Dtos
{
    public class IdentityVerificationPhone
    {
        public string mobile { get; set; }
        public bool isSubjectConsent { get; set; }
    }
}
