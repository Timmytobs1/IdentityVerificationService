using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Services;
using Castle.Core.Logging;
using IdentityVerificationService.IdentityVerificationRecord.Dtos;
using Microsoft.Extensions.Configuration;



namespace IdentityVerificationService.IdentityVerificationRecord
{
    public class IdentityVerificationManager : ITransientDependency
    {
        private readonly YouVerifyIdentityVerificationRepository _identityVerificationService;
        private readonly IConfiguration _configuration;
        public ILogger Logger { get; set; }

        public IdentityVerificationManager(YouVerifyIdentityVerificationRepository identityVerificationService, IConfiguration configuration)
        {
            _identityVerificationService = identityVerificationService;
            _configuration = configuration;
        }

        public async Task<string> VerifyBvnAsync(string identityId)
        {
            Logger.Debug($"  9-----------------------------------------------------------------------------------------------------------------------9");
            var processor = GetProcessor();
            Logger.Debug($"{processor}  9-----------------------------------------------------------------------------------------------------------------------9");
            return await processor.VerifyBvnAsync(identityId);
            /*            return await VerifyBvnAsync(identityId);*/
        }

        public async Task<string> VerifyDriverLicenseAsync(string identityId)
        {
              var processor = GetProcessor();
            return await processor.VerifyDriverLicenseAsync(identityId);
         /*   return await VerifyDriverLicenseAsync(identityId);*/
        }

        public async Task<string> VerifyNinAsync(string identityId)
        {
             var processor = GetProcessor();
            return await processor.VerifyNinAsync(identityId);
       /*     return await VerifyNinAsync(identityId);*/
        }

        public async Task<string> VerifyPhoneNoAsync(string identityId)
        {
             var processor = GetProcessor();
            return await processor.VerifyPhoneNoAsync(identityId);
            /*        return await VerifyPhoneNoAsync(identityId);*/
        }

        public async Task<string> VerifyInternationalPassportAsync(string identityId)
        {
              var processor = GetProcessor();
              return await processor.VerifyInternationalPassportAsync(identityId);
          /*  return await VerifyInternationalPassportAsync(identityId);*/
        }

        public async Task<string> VerifyPvcAsync(string identityId)
        {
             var processor = GetProcessor();
            return await processor.VerifyPvcAsync(identityId);
            /*     return await VerifyPvcAsync(identityId);*/
        }

        public async Task<string> VerifyVninAsync(string identityId)
        {
             var processor = GetProcessor();
            return await processor.VerifyVninAsync(identityId);
            /*      return await VerifyVninAsync(identityId);*/
        }

        private YouVerifyIdentityVerificationRepository GetProcessor()
        {

            Logger.Debug($" 1-----------------------------------------------------------------------------------------------------------------------1  ");
            // Retrieve default processors from the configuration
            string defaultProcessor = _configuration["Processor:DefaultProcessor"];
            Logger.Debug($"{defaultProcessor} 11111111111111111111111111111111111111111111111111111111111  ");

            if (defaultProcessor == null || !defaultProcessor.Any())
                throw new InvalidOperationException("No processors configured in the appsettings.json");
            Logger.Debug($" 2-----------------------------------------------------------------------------------------------------------------------2  ");
            // Retrieve all processors from IoC container
            var allProcessors = IocManager.Instance.IocContainer.ResolveAll<YouVerifyIdentityVerificationRepository>();

            Logger.Debug($"{allProcessors}  3-----------------------------------------------------------------------------------------------------------------------3");

            foreach (var processorName in allProcessors)
            {
                Logger.Debug($"  4-----------------------------------------------------------------------------------------------------------------------4");
                // Match processor by name
                var processor = allProcessors.FirstOrDefault(p =>
                    p.GetType().Name.ToLower().StartsWith(defaultProcessor.ToLower()));
                Logger.Debug($"  5-----------------------------------------------------------------------------------------------------------------------5");
                if (processor != null)
                {
                    Logger.Debug($"{processor}   6-----------------------------------------------------------------------------------------------------------------------6");
                    return processor;
                }
            }
            Logger.Debug($"  7-----------------------------------------------------------------------------------------------------------------------7");
            throw new InvalidOperationException("No matching processor found for configured default processors.");
        }
    }
}
