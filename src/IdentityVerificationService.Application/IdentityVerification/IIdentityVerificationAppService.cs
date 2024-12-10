using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityVerificationService.IdentityVerification
{
    public interface IIdentityVerificationAppService
    {
        Task<string> VerifyBvnAsync(string identityId);
        Task<string> VerifyNinAsync(string identityId);
        Task<string> VerifyDriverLicenseAsync(string identityId);
        Task<string> VerifyPhoneNoAsync(string identityId);
    }
}
