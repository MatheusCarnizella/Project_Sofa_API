using Microsoft.EntityFrameworkCore;
using Project_Sofa.Sources.Contextos;
using System.Threading.Tasks;
using static Project_Sofa.Sources.Modelos.Modelo_do_AUsuario;

namespace Project_Sofa.Sources.Repositorios.Implemetencao
{
    public class AUsuarioRepositorio : IAUsuario
    {

        #region Atributos
        private readonly Sofa_Contextos _scontexto;
        #endregion


        #region Construtores
        public AUsuarioRepositorio(Sofa_Contextos scontexto)
        {
            _scontexto = scontexto;
        }
        #endregion


        #region Métodos
        public async Task NovoAUsuarioAsync(AUsuario ausuario)
        {
            await _scontexto.AUsuarios.AddAsync(new AUsuario
            {
                Nome = ausuario.Nome,
                Email = ausuario.Email,
                Senha = ausuario.Senha,
                Tipo = ausuario.Tipo,
            });
            await _scontexto.SaveChangesAsync();
        }

        public async Task<AUsuario> PegarAUsuarioPeloEmailAsync(string email)
        {
            return await _scontexto.AUsuarios.FirstOrDefaultAsync(u => u.Email == email);
        }
        #endregion

    }
}
