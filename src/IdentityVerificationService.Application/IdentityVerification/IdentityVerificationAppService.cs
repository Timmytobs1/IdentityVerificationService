using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Runtime.Session;
using Abp.Web.Models;
using IdentityVerificationService.IdentityVerificationRecord;
using Microsoft.AspNetCore.Mvc;

namespace IdentityVerificationService.IdentityVerification
{
    [RemoteService(true)]
    [WrapResult(WrapOnSuccess = true, WrapOnError = true)]
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
        [Route("api/identity-verification/verify/bvn/{identityId}")]
        public async Task<string> VerifyBvnAsync(string identityId)
        {
            try
            {
                return await _identityVerificationManager.VerifyBvnAsync(identityId);
            }
            catch (System.Exception ex)
            {
                Logger.Error($"Error verifying BVN for IdentityId: {identityId}", ex);
                throw new Abp.UI.UserFriendlyException("An error occurred while verifying BVN. Please try again.");
            }
        }

        // Method to verify NIN
        [HttpPost]
        [Route("api/identity-verification/verify/nin/{identityId}")]
        public async Task<string> VerifyNinAsync(string identityId)
        {
            try
            {
                return await _identityVerificationManager.VerifyNinAsync(identityId);
            }
            catch (System.Exception ex)
            {
                Logger.Error($"Error verifying NIN for IdentityId: {identityId}", ex);
                throw new Abp.UI.UserFriendlyException("An error occurred while verifying NIN. Please try again.");
            }
        }

        // Method to verify Driver's License
        [HttpPost]
        [Route("api/identity-verification/verify/driver-license/{identityId}")]
        public async Task<string> VerifyDriverLicenseAsync(string identityId)
        {
            try
            {
                return await _identityVerificationManager.VerifyDriverLicenseAsync(identityId);
            }
            catch (System.Exception ex)
            {
                Logger.Error($"Error verifying Driver's License for IdentityId: {identityId}", ex);
                throw new Abp.UI.UserFriendlyException("An error occurred while verifying Driver's License. Please try again.");
            }
        }

        // Method to verify Phone Number
        [HttpPost]
        [Route("api/identity-verification/verify/phone-no/{identityId}")]
        public async Task<string> VerifyPhoneNoAsync(string identityId)
        {
            try
            {
                return await _identityVerificationManager.VerifyPhoneNo(identityId);
            }
            catch (System.Exception ex)
            {
                Logger.Error($"Error verifying Phone Number for IdentityId: {identityId}", ex);
                throw new Abp.UI.UserFriendlyException("An error occurred while verifying Phone Number. Please try again.");
            }
        }
    }
}
