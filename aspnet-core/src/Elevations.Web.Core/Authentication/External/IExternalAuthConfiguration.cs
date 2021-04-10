﻿namespace Elevations.Authentication.External
{
    using System.Collections.Generic;

    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}