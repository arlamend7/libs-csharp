using Microsoft.IdentityModel.Tokens;
using System;

namespace Libs.System.Utilities.TokenBuilder.Interfaces
{
    public interface ITokenBuilderFactory
    {
        ITokenBuilderConfigurated Configurate(SecurityKey key, string algorithms, DateTime expirationTime);
        ITokenBuilderConfigurated Configurate(SecurityKey key, string algorithms, int expirationHours);
        ITokenBuilderConfigurated Configurate(string key, int expirationHours);
    }
}
