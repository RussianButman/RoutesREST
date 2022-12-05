using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace RoutesREST.Models.IdentityData
{
    public class RSAKeyHelper
    {
        private readonly IConfiguration _configuration;

        public RSAKeyHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        RSA rsa = RSA.Create();
        public RsaSecurityKey GetIssuerSigningKey()
        {
            rsa.ImportFromPem(JwtIdentityOptions.PrivateKey.ToCharArray());

            return new RsaSecurityKey(rsa);
        }
        public SigningCredentials GetAudienceSigningKey()
        {
            rsa.ImportFromPem(JwtIdentityOptions.PrivateKey.ToCharArray());

            return new SigningCredentials(
                key: new RsaSecurityKey(rsa),
                algorithm: SecurityAlgorithms.RsaSha256);
        }
    }
}
