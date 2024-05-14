﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Infrastructure.Authentication;
using Shoppy.Infrastructure.Web.Authentication;

namespace Shoppy.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}