using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project_Sofa.Sources.Repositorios;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Project_Sofa.Sources.Modelos.Modelo_do_AUsuario;

namespace Project_Sofa.Sources.Servicos.Implementacoes
{
    public class AutenticacaoServicos : IAutenticacao
    {
        #region Atributos
        private IAUsuario _repositorio;
        public IConfiguration Configuracao { get; }
        #endregion

        #region Construtores
        public AutenticacaoServicos(IAUsuario repositorio, IConfiguration
        configuration)
        {
            _repositorio = repositorio;
            Configuracao = configuration;
        }
        #endregion

        #region Métodos
        public string CodificarSenha(string senha)
        {
            var bytes = Encoding.UTF8.GetBytes(senha);
            return Convert.ToBase64String(bytes);
        }
        public async Task CriarUsuarioSemDuplicarAsync(AUsuario ausuario)
        {
            var auxiliar = await _repositorio.PegarAUsuarioPeloEmailAsync(ausuario.Email);
            if (auxiliar != null) throw new Exception("Este email já está sendo utilizado");
            ausuario.Senha = CodificarSenha(ausuario.Senha);
            await _repositorio.NovoAUsuarioAsync(ausuario);
        }
        public string GerarToken(AUsuario ausuario)
        {
            var tokenManipulador = new JwtSecurityTokenHandler();
            var chave = Encoding.ASCII.GetBytes(Configuracao["Settings:Secret"]);
            var tokenDescricao = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Email, ausuario.Email.ToString()),
                        new Claim(ClaimTypes.Role, ausuario.Tipo.ToString())
                    }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(chave),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var token = tokenManipulador.CreateToken(tokenDescricao);
            return tokenManipulador.WriteToken(token);
            #endregion
        }
    }
}
