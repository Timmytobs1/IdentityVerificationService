using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityVerificationService.IdentityVerification
{
    public interface IIdentityVerificationAppService
    {

        Task<string> VerifyBvnAsync(string bvn);
        Task<string> VerifyNinAsync(string nin);
        Task<string> VerifyDriverLicenseAsync(string driverLicenseNo);
        Task<string> VerifyPhoneNoAsync(string phoneNo);
        Task<string> VerifyInternationalPassportAsync(string passportNo);
        Task<string> VerifyPvcAsync(string pvc);
        Task<string> VerifyVninAsync(string Vnin);
    }
}
