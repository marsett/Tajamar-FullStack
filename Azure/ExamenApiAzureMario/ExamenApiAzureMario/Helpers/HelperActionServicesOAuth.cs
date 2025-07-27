﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ExamenApiAzureMario.Helpers
{
    public class HelperActionServicesOAuth
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }

        public HelperActionServicesOAuth(IConfiguration configuration)
        {
            this.Issuer = configuration.GetValue<string>("ExamenApiMario:Issuer");
            this.Audience = configuration.GetValue<string>("ExamenApiMario:Audience");
            this.SecretKey = configuration.GetValue<string>("ExamenApiMario:SecretKey");
        }

        public SymmetricSecurityKey GetKeyToken()
        {
            byte[] data = Encoding.UTF8.GetBytes(this.SecretKey);
            return new SymmetricSecurityKey(data);
        }

        public Action<JwtBearerOptions> GetJwtBearerOptions()
        {
            return options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = this.Issuer,
                    ValidAudience = this.Audience,
                    IssuerSigningKey = this.GetKeyToken()
                };
            };
        }

        public Action<AuthenticationOptions> GetAuthenticationOptions()
        {
            Action<AuthenticationOptions> action = options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

            };
            return action;
        }
    }
}
