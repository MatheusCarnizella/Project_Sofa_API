using Microsoft.EntityFrameworkCore;
using static Project_Sofa.Sources.Modelos.Modelo_do_AUsuario;
using static Project_Sofa.Sources.Modelos.Modelo_do_Sofa;

namespace Project_Sofa.Sources.Contextos
{
    public class Sofa_Contextos : DbContext
    {
        #region Atributos
        public DbSet<AUsuario> AUsuarios { get; set; }
        public DbSet<Sofa> Sofas { get; set; }
        #endregion
        #region Construtores

        public Sofa_Contextos(DbContextOptions<Sofa_Contextos> opt) : base(opt)
        {
        }
        #endregion
    }

}

