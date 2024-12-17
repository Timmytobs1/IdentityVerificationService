using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityVerificationService.IdentityVerificationRecord.Dtos
{
    public class IdentityVerificationResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public string data { get; set; }
    }
}
