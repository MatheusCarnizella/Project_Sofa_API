using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Project_Sofa.Sources.Modelos.Modelo_do_AUsuario;

namespace Project_Sofa.Sources.Modelos
{
    public class Modelo_do_Sofa
    {
        [Table("tb_Sofas")]
        public class Sofa
        {
            #region Atributos
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public string Foto { get; set; }
            public string Aprovacao { get; set; }

            [ForeignKey("fk_AUsuario")]
            public AUsuario Criador { get; set; }

            [ForeignKey("fk_Inspetor")]
            public AUsuario Inspetor { get; set; }

            #endregion
        }

    }
}
