using System.Collections.Generic;
using System.Threading.Tasks;
using static Project_Sofa.Sources.Modelos.Modelo_do_Sofa;

namespace Project_Sofa.Sources.Repositorios
{
    public interface ISofa
    {
        Task<List<Sofa>> PegarTodosSofasAsync();
        Task<Sofa> PegarSofasPeloIdAsync(int id);
        Task NovoSofaAsync(Sofa sofa);
        Task AtualizarSofaAsync(Sofa sofa);
        Task DeletarSofaAsync(int id);
        Task<List<Sofa>> PegarTodosSofasPorInspetorAsync(int idInspetor);


    }
}
