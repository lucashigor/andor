﻿using Family.Budget.Application.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Family.Budget.Api.Common.Middlewares
{
    public class ClaimsTransformer : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)principal.Identity;

            if (claimsIdentity.IsAuthenticated && claimsIdentity.HasClaim((claim) => claim.Type == "realm_access"))
            {
                var userRole = claimsIdentity.FindFirst((claim) => claim.Type == "realm_access");

                var content = Newtonsoft.Json.Linq.JObject.Parse(userRole.Value);

                foreach (var role in content["roles"])
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.ToString()));
                }
            }

            return Task.FromResult(principal);
        }
    }

    public static class JwtAuthenticationMiddleware
    {
        private static RsaSecurityKey BuildRSAKey(IConfiguration configuration)
        {
            var authOptions = configuration.GetSection("IdentityProvider").Get<IdentityProvider>();

            RSA rsa = RSA.Create();

            rsa.ImportSubjectPublicKeyInfo(
                source: Convert.FromBase64String(authOptions?.PublicKeyJwt!),
                bytesRead: out _
            );

            var IssuerSigningKey = new RsaSecurityKey(rsa);
            return IssuerSigningKey;
        }

        public static IServiceCollection ConfigureJWT(this IServiceCollection services,
            IConfiguration configuration,
            bool IsDevelopment, IHostEnvironment environment)
        {
            services.AddTransient<IClaimsTransformation, ClaimsTransformer>();

            var authOptions = configuration.GetSection("IdentityProvider").Get<IdentityProvider>();

            services.AddAuthorization(o =>
            {
                if (environment.IsDevelopment())
                {
                    o.FallbackPolicy = new AuthorizationPolicyBuilder()
                                        .RequireAssertion(p => environment.IsDevelopment())
                                    .Build();

                    o.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                        .RequireAssertion(p => environment.IsDevelopment())
                        .Build();
                }
                else
                {
                    o.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                                    .Build();

                    o.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser()
                        .Build();
                }

            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                #region == JWT Token Validation ===
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = true,
                    ValidIssuers = new[] { authOptions?.Authority! },
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = BuildRSAKey(configuration),
                    ValidateLifetime = true
                };
                #endregion

                o.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        c.NoResult();
                        c.Response.StatusCode = 401;
                        c.Response.ContentType = "text/plain";

                        if (IsDevelopment) return c.Response.WriteAsync(c.Exception.ToString());

                        return c.Response.WriteAsync("An error occured processing your authentication.");
                    }
                };
            });

            return services;
        }
    }
}
