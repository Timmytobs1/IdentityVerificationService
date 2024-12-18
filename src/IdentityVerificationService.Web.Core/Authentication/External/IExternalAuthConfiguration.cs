﻿using System.Collections.Generic;

namespace IdentityVerificationService.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
