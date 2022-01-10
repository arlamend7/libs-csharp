using Libs.System.Utilities.TokenBuilder.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Libs.System.Utilities.TokenBuilder
{
    public class TokenBuilder : ITokenBuilderFactory, ITokenBuilderConfigurated
    {
        public SigningCredentials Credentials { get; protected set; }
        public List<Claim> Claims { get; protected set; }
        public DateTime Expiration { get; protected set; }
        public JwtSecurityTokenHandler Handler { get; protected set; }

        public TokenBuilder()
        {
            Claims = new List<Claim>() {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            Handler = new JwtSecurityTokenHandler();
        }
        public static ITokenBuilderFactory Factory()
        {
            return new TokenBuilder();
        }
        public ITokenBuilderConfigurated Configurate(SecurityKey key, string algorithms, DateTime expirationTime)
        {
            Credentials = new SigningCredentials(key, algorithms);
            Expiration = expirationTime;
            return this;
        }
        public ITokenBuilderConfigurated Configurate(SecurityKey key, string algorithms, int expirationHours)
        {
            return Configurate(key, algorithms, DateTime.Now.AddHours(expirationHours));
        }
        
        /// <summary>
        ///     Use a SymetricSecuretyKey and HmacSha256 algorithms to create the token 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expirationHours"></param>
        /// <returns></returns>
        public ITokenBuilderConfigurated Configurate(string key, int expirationHours)
        {
            var symetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            return Configurate(symetricKey, SecurityAlgorithms.HmacSha256, expirationHours);
        }

        public ITokenBuilderConfigurated AddInformation(params (string key, string value)[] informations)
        {
            Claims.AddRange(informations.Select(information =>
            {
                return new Claim(information.key, information.value);
            }));
            return this;
        }
        public ITokenBuilderConfigurated AddInformation(string key, string value)
        {
            AddInformation((key, value));
            return this;
        }
        public ITokenBuilderConfigurated AddInformation(params Claim[] informations)
        {
            Claims.AddRange(informations);
            return this;
        }
        public string Build()
        {
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claims),
                Expires = Expiration,
                SigningCredentials = Credentials
            };
            SecurityToken token = Handler.CreateToken(tokenDescriptor);

            return Handler.WriteToken(token);
        }
        public JwtSecurityToken Read(string token)
        {
            return Handler.ReadJwtToken(token);
        }


    }

}
