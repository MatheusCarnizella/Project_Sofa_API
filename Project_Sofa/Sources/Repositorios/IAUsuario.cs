using System.Threading.Tasks;
using static Project_Sofa.Sources.Modelos.Modelo_do_AUsuario;

namespace Project_Sofa.Sources.Repositorios
{
    public interface IAUsuario
    {
        Task<AUsuario> PegarAUsuarioPeloEmailAsync(string email);
        Task NovoAUsuarioAsync(AUsuario ausuario);
    }
}
