using Project_Sofa.Sources.Utilidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static Project_Sofa.Sources.Modelos.Modelo_do_Sofa;

namespace Project_Sofa.Sources.Modelos
{
    public class Modelo_do_AUsuario
    {
        [Table("tb_AUsuarios")]
        public class AUsuario
        {
            #region Atributos
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Senha { get; set; }

            [Required]
            public TipoAUsuario Tipo { get; set; }


            [JsonIgnore, InverseProperty("Criador")]
            public List<Sofa> PostagemSofa { get; set; }

            [JsonIgnore, InverseProperty("Inspetor")]
            public List<Sofa> SofasPostados { get; set; }
            #endregion
        }

    }
}
