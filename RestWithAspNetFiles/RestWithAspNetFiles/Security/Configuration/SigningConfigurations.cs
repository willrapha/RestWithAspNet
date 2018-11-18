using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace RestWithAspNetFiles.Security.Configuration
{
    public class SigningConfigurations
    {
        // Resposavel por gerar o Token e a encryptação do mesmo
        public SigningConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }

        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }
    }
}