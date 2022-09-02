using System.Threading.Tasks;
using static Project_Sofa.Sources.Modelos.Modelo_do_AUsuario;

namespace Project_Sofa.Sources.Servicos
{
    public interface IAutenticacao
    {
        string CodificarSenha(string senha);
        Task CriarUsuarioSemDuplicarAsync(AUsuario ausuario);
        string GerarToken(AUsuario ausuario);

    }
}
