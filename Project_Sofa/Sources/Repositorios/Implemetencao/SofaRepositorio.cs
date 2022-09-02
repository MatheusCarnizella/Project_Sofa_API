using Microsoft.EntityFrameworkCore;
using Project_Sofa.Sources.Contextos;
using Project_Sofa.Sources.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Project_Sofa.Sources.Modelos.Modelo_do_Sofa;

namespace Project_Sofa.Sources.Repositorios.Implemetencao
{
    public class SofaRepositorio : ISofa
    {

        #region Atributos
        private readonly Sofa_Contextos _scontexto;
        #endregion


        #region Construtores
        public SofaRepositorio(Sofa_Contextos scontexto)
        {
            _scontexto = scontexto;
        }
        #endregion


        #region Métodos
        public async Task AtualizarSofaAsync(Sofa sofa)
        {
            var _sofa = await PegarSofasPeloIdAsync(sofa.Id);
            _sofa.Descricao = sofa.Descricao;
            _scontexto.Sofas.Update(_sofa);
            await _scontexto.SaveChangesAsync();
        }

        public async Task DeletarSofaAsync(int id)
        {
            _scontexto.Sofas.Remove(await PegarSofasPeloIdAsync(id));
            await _scontexto.SaveChangesAsync();
        }

        public async Task NovoSofaAsync(Sofa sofa)
        {
            await _scontexto.Sofas.AddAsync(new Sofa
            {
                Descricao = sofa.Descricao
            });
            await _scontexto.SaveChangesAsync();
        }

        public async Task<Sofa> PegarSofasPeloIdAsync(int id)
        {
            if (!ExisteId(id)) throw new Exception("Id do tema não encontrado");
            return await _scontexto.Sofas.FirstOrDefaultAsync(t => t.Id == id);

            bool ExisteId(int id)
            {
                Sofa _sofa = _scontexto.Sofas.FirstOrDefault(u => u.Id == id);
                return _sofa != null;
            }
        }

        public async Task<List<Sofa>> PegarTodosSofasAsync()
        {
            return await _scontexto.Sofas.ToListAsync();
        }

        public async Task<List<Sofa>> PegarTodosSofasPorInspetorAsync(int idInspetor)
        {
            if (!ExisteIdInspetor(idInspetor)) throw new Exception("Id do Inspetor não encontrado");
            return await _scontexto.Sofas.Include(s => s.Inspetor).Where(s => s.Inspetor.Id == idInspetor).ToListAsync();

            bool ExisteIdInspetor(int id)
            {
                var auxiliar = _scontexto.AUsuarios.FirstOrDefault(u => u.Id == id);
                return auxiliar != null;
            }
        }
        #endregion

    }
}
