

using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Runtime.Session;
using Abp.UI;
using Abp.Web.Models;
using IdentityVerificationService.IdentityVerificationRecord;
using Microsoft.AspNetCore.Mvc;

namespace IdentityVerificationService.IdentityVerification
{
    [RemoteService(true)]
    [WrapResult(WrapOnSuccess = false, WrapOnError = false)]
    [AbpAuthorize]

    public class IdentityVerificationAppService : ApplicationService, IIdentityVerificationAppService
    {
        private readonly IIdentityVerificationManager _identityVerificationManager;
        private readonly IAbpSession _abpSession;

        public IdentityVerificationAppService(
            IIdentityVerificationManager identityVerificationManager,
            IAbpSession abpSession)
        {
            _identityVerificationManager = identityVerificationManager;
            _abpSession = abpSession;
        }

        // Method to verify BVN
        [HttpPost]
        [Route("api/identity-verification/verify/bvn/{bvn}")]
        public async Task<string> VerifyBvnAsync(string bvn)
        {

            // Logger.Debug($"hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");

            Console.WriteLine("hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
            try
            {
                if (bvn.Length != 11)
                {
                    return "BVN is not valid";
                }
                return await _identityVerificationManager.VerifyBvnAsync(bvn);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error verifying BVN for IdentityId: {bvn}", ex);
                throw new Exception("An error occurred while verifying BVN. Please try again.", ex.InnerException);
            }
        }

        // Method to verify NIN
        [HttpPost]
        [Route("api/identity-verification/verify/nin/{nin}")]
        public async Task<string> VerifyNinAsync(string nin)
        {
            try
            {
                if (nin.Length != 11)
                {
                    return "Nin is not valid";
                }

                return await _identityVerificationManager.VerifyNinAsync(nin);
            }
            catch (System.Exception ex)
            {
                Logger.Error($"Error verifying NIN for IdentityId: {nin}", ex);
                throw new Abp.UI.UserFriendlyException("An error occurred while verifying NIN. Please try again.", ex.InnerException);
            }
        }

        // Method to verify Driver's License
        [HttpPost]
        [Route("api/identity-verification/verify/driver-license/{driverLicenseNo}")]
        public async Task<string> VerifyDriverLicenseAsync(string driverLicenseNo)
        {
            try
            {
                if (driverLicenseNo.Length != 12)
                {
                    return "Driver License No is not valid";
                }
                return await _identityVerificationManager.VerifyDriverLicenseAsync(driverLicenseNo);
            }
            catch (System.Exception ex)
            {
                Logger.Error($"Error verifying Driver's License for IdentityId: {driverLicenseNo}", ex);
                throw new Abp.UI.UserFriendlyException("An error occurred while verifying Driver's License. Please try again.", ex.InnerException);
            }
        }

        // Method to verify Phone Number
        [HttpPost]
        [Route("api/identity-verification/verify/phone-no/{phoneNo}")]
        public async Task<string> VerifyPhoneNoAsync(string phoneNo)
        {
            try
            {
                if (phoneNo.Length != 11)
                {
                    return "Phone No is not valid";
                }
                return await _identityVerificationManager.VerifyPhoneNoAsync(phoneNo);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error verifying Phone Number for IdentityId: {phoneNo}", ex);
                throw new UserFriendlyException("An error occurred while verifying Phone Number. Please try again.", ex.InnerException);
            }
        }

        [HttpPost]
        [Route("api/identity-verification/verify/international-passport/{passportNo}")]
        public async Task<string> VerifyInternationalPassportAsync(string passportNo)
        {
            try
            {
                if (passportNo.Length != 9)
                {
                    return "Passport No is not valid";
                }
                return await _identityVerificationManager.VerifyInternationalPassportAsync(passportNo);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error verifying International passport for IdentityId: {passportNo}", ex);
                throw new UserFriendlyException("An error occurred while verifying international passport. Please try again.", ex.InnerException);
            }
        }


        [HttpPost]
        [Route("api/identity-verification/verify/pvc/{pvc}")]
        public async Task<string> VerifyPvcAsync(string pvc)
        {
            try
            {
                if (pvc.Length != 19)
                {
                    return "PVC is not valid";
                }
                return await _identityVerificationManager.VerifyPvcAsync(pvc);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error verifying pvc for IdentityId: {pvc}", ex);
                throw new UserFriendlyException("An error occurred while verifying Pvc. Please try again.", ex.InnerException);
            }
        }


        [HttpPost]
        [Route("api/identity-verification/verify/Vnin/{Vnin}")]
        public async Task<string> VerifyVninAsync(string Vnin)
        {
            try
            {
                if (Vnin.Length != 16)
                {
                    return "Vnin is not valid";
                }
                return await _identityVerificationManager.VerifyVninAsync(Vnin);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error verifying pvc for IdentityId: {Vnin}", ex);
                throw new UserFriendlyException("An error occurred while verifying Pvc. Please try again.", ex.InnerException);
            }
        }


    }
}




/*using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Runtime.Session;
using Abp.UI;
using Abp.Web.Models;
using IdentityVerificationService.IdentityVerificationRecord;
using Microsoft.AspNetCore.Mvc;

namespace IdentityVerificationService.IdentityVerification
{
    [RemoteService(true)]
    [WrapResult(WrapOnSuccess = false, WrapOnError = false)]
    [AbpAuthorize]
    public class IdentityVerificationAppService : ApplicationService, IIdentityVerificationAppService
    {
        private readonly IIdentityVerificationManager _identityVerificationManager;
        private readonly IAbpSession _abpSession;

        public IdentityVerificationAppService(
            IIdentityVerificationManager identityVerificationManager,
            IAbpSession abpSession)
        {
            _identityVerificationManager = identityVerificationManager;
            _abpSession = abpSession;
        }

        // Method to verify BVN
        [HttpPost]
        [Route("api/identity-verification/verify/bvn/{bvn}")]
        public async Task<string> VerifyBvnAsync(string bvn)
        {
            try
            {
                if (bvn.Length != 11)
                {
                    return "BVN is not valid";
                }

                // Simulate Payment Required (402) error
                if (bvn == "12345678901") // Example for insufficient funds
                {
                    return "HTTP/1.1 402 Payment Required - Insufficient funds";
                }

                return await _identityVerificationManager.VerifyBvnAsync(bvn);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error verifying BVN for IdentityId: {bvn}", ex);
                return "HTTP/1.1 500 Internal Server Error - Service unavailable";
            }
        }

        // Method to verify NIN
        [HttpPost]
        [Route("api/identity-verification/verify/nin/{nin}")]
        public async Task<string> VerifyNinAsync(string nin)
        {
            try
            {
                if (nin.Length != 11)
                {
                    return "NIN is not valid";
                }

                // Simulate Forbidden (403) error
                if (nin == "11122233344") // Example for permission denied
                {
                    return "HTTP/1.1 403 Forbidden - Permission denied";
                }

                return await _identityVerificationManager.VerifyNinAsync(nin);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error verifying NIN for IdentityId: {nin}", ex);
                return "HTTP/1.1 500 Internal Server Error - Service unavailable";
            }
        }

        // Method to verify Driver's License
        [HttpPost]
        [Route("api/identity-verification/verify/driver-license/{driverLicenseNo}")]
        public async Task<string> VerifyDriverLicenseAsync(string driverLicenseNo)
        {
            try
            {
                if (driverLicenseNo.Length != 12)
                {
                    return "Driver License No is not valid";
                }

                // Simulate Payment Required (402) error
                if (driverLicenseNo == "000000000000") // Example for insufficient funds
                {
                    return "HTTP/1.1 402 Payment Required - Insufficient funds";
                }

                return await _identityVerificationManager.VerifyDriverLicenseAsync(driverLicenseNo);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error verifying Driver's License for IdentityId: {driverLicenseNo}", ex);
                return "HTTP/1.1 500 Internal Server Error - Service unavailable";
            }
        }

        // Method to verify Phone Number
        [HttpPost]
        [Route("api/identity-verification/verify/phone-no/{phoneNo}")]
        public async Task<string> VerifyPhoneNoAsync(string phoneNo)
        {
            try
            {
                if (phoneNo.Length != 11)
                {
                    return "Phone No is not valid";
                }

                // Simulate Payment Required (402) error
                if (phoneNo == "09012345678") // Example for insufficient funds
                {
                    return "HTTP/1.1 402 Payment Required - Insufficient funds";
                }

                return await _identityVerificationManager.VerifyPhoneNoAsync(phoneNo);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error verifying Phone Number for IdentityId: {phoneNo}", ex);
                return "HTTP/1.1 500 Internal Server Error - Service unavailable";
            }
        }

        [HttpPost]
        [Route("api/identity-verification/verify/international-passport/{passportNo}")]
        public async Task<string> VerifyInternationalPassportAsync(string passportNo)
        {
            try
            {
                if (passportNo.Length != 9)
                {
                    return "Passport No is not valid";
                }

                return await _identityVerificationManager.VerifyInternationalPassportAsync(passportNo);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error verifying International passport for IdentityId: {passportNo}", ex);
                return "HTTP/1.1 500 Internal Server Error - Service unavailable";
            }
        }

        [HttpPost]
        [Route("api/identity-verification/verify/pvc/{pvc}")]
        public async Task<string> VerifyPvcAsync(string pvc)
        {
            try
            {
                if (pvc.Length != 19)
                {
                    return "PVC is not valid";
                }

                // Simulate Payment Required (402) error
                if (pvc == "0000000000000000000") // Example for insufficient funds
                {
                    return "HTTP/1.1 402 Payment Required - Insufficient funds";
                }

                return await _identityVerificationManager.VerifyPvcAsync(pvc);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error verifying PVC for IdentityId: {pvc}", ex);
                return "HTTP/1.1 500 Internal Server Error - Service unavailable";
            }
        }

        [HttpPost]
        [Route("api/identity-verification/verify/Vnin/{Vnin}")]
        public async Task<string> VerifyVninAsync(string Vnin)
        {
            try
            {
                if (Vnin.Length != 16)
                {
                    return "Vnin is not valid";
                }

                return await _identityVerificationManager.VerifyVninAsync(Vnin);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error verifying Vnin for IdentityId: {Vnin}", ex);
                return "HTTP/1.1 500 Internal Server Error - Service unavailable";
            }
        }
    }
}


*/

























