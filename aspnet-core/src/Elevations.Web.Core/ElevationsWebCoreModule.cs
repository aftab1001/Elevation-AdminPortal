﻿namespace Elevations
{
    using System;
    using System.Text;

    using Abp.AspNetCore;
    using Abp.AspNetCore.Configuration;
    using Abp.AspNetCore.SignalR;
    using Abp.Modules;
    using Abp.Reflection.Extensions;
    using Abp.Zero.Configuration;

    using Elevations.Authentication.JwtBearer;
    using Elevations.Configuration;
    using Elevations.EntityFrameworkCore;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.ApplicationParts;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;

    [DependsOn(
        typeof(ElevationsApplicationModule),
        typeof(ElevationsEntityFrameworkModule),
        typeof(AbpAspNetCoreModule),
        typeof(AbpAspNetCoreSignalRModule))]
    public class ElevationsWebCoreModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        private readonly IWebHostEnvironment _env;

        public ElevationsWebCoreModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ElevationsWebCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ElevationsWebCoreModule).Assembly);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                ElevationsConsts.ConnectionStringName);

            // Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(typeof(ElevationsApplicationModule).GetAssembly());

            ConfigureTokenAuth();
        }

        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            TokenAuthConfiguration tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(
                tokenAuthConfig.SecurityKey,
                SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
        }
    }
}