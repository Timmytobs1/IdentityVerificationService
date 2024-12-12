using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace IdentityVerificationService.IdentityVerificationRecord
{
    public class IdentityVerificationManager : DomainService, IIdentityVerificationManager
    {

        private readonly IdentityVerificationRepository _identityVerificationService;

        public IdentityVerificationManager(IdentityVerificationRepository identityVerificationService)
        {
            _identityVerificationService = identityVerificationService;
        }
        public async Task<string> VerifyBvnAsync(string identityId)
        {
            return await _identityVerificationService.VerifyBvnAsync(identityId);
        }
        public async Task<string> VerifyDriverLicenseAsync(string identityId)
        {
            return await _identityVerificationService.VerifyDriverLicenseAsync(identityId);
        }

        public async Task<string> VerifyNinAsync(string identityId)
        {
            return await _identityVerificationService.VerifyNinAsync(identityId);
        }

        public async Task<string> VerifyPhoneNoAsync(string identityId)
        {
            return await _identityVerificationService.VerifyPhoneNoAsync(identityId);
        }

        public async Task<string> VerifyInternationalPassportAsync(string identityId)
        {
            return await _identityVerificationService.VerifyInternationalPassportAsync(identityId);
        }

        public async Task<string> VerifyPvcAsync(string identityId)
        {
            return await _identityVerificationService.VerifyPvcAsync(identityId);
        }
        public async Task<string> VerifyVninAsync(string identityId)
        {
            return await _identityVerificationService.VerifyVninAsync(identityId);
        }

    }
}
