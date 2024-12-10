using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityVerificationService.IdentityVerificationRecord.Services;

namespace IdentityVerificationService.IdentityVerificationRecord
{
    public class IdentityVerificationManager : IIdentityVerificationManager
    {

        private readonly IdentityService _identityVerificationService;

        public IdentityVerificationManager(IdentityService identityVerificationService)
        {
            _identityVerificationService = identityVerificationService;
        }
        public async Task<string> VerifyBvnAsync(string identityId)
        {
            return await _identityVerificationService.VerifyBvnAsync(identityId);
        }
        

        public Task<string> VerifyDriverLicenseAsync(string identityId)
        {
            throw new NotImplementedException();
        }

        public Task<string> VerifyNinAsync(string identityId)
        {
            throw new NotImplementedException();
        }

        public Task<string> VerifyPhoneNo(string identityId)
        {
            throw new NotImplementedException();
        }
    }
}
