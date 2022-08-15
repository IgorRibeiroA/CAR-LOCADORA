
using CarLocadora.Modelo.ModelsToken;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CarLocadora.API.Token
{
    public class GeradorToken
    {
        private readonly string _secreto;

        public GeradorToken()
        {
            _secreto = Environment.GetEnvironmentVariable("JWT_SECRETO");
        }

        public LoginRespostaModel GerarToken(LoginRespostaModel loginRespostaModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Convert.FromBase64String(_secreto);

            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier,loginRespostaModel.Usuario)
            });

            var signingCredentils = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Issuer = "EmitenteDoJWT",
                Audience = "DestinatarioDoJWT",
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(10000),
                SigningCredentials = signingCredentils,
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            loginRespostaModel.Autenticado = true;
            loginRespostaModel.DataExpiracao = tokenDescriptor.Expires;
            loginRespostaModel.Token = tokenHandler.WriteToken(token);

            return loginRespostaModel;
        }

    }
}
