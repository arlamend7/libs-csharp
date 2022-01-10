using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Libs.System.Utilities.TokenBuilder.Interfaces
{
    public interface ITokenBuilderConfigurated
    {
        ITokenBuilderConfigurated AddInformation(params (string key, string value)[] informations);
        ITokenBuilderConfigurated AddInformation(params Claim[] informations);
        ITokenBuilderConfigurated AddInformation(string key, string value);
        string Build();
        JwtSecurityToken Read(string token);
    }
}