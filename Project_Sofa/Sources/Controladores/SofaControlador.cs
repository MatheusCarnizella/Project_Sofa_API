using Microsoft.AspNetCore.Mvc;
using Project_Sofa.Sources.Repositorios;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using static Project_Sofa.Sources.Modelos.Modelo_do_Sofa;

namespace Project_Sofa.Sources.Controladores
{
    [ApiController]
    [Route("api/Sofas")]
    [Produces("application/json")]
    public class SofaControlador : ControllerBase
    {
        #region Atributos
        private readonly ISofa _sofastatus;

        #endregion

        #region Construtores
        public SofaControlador(ISofa sofastatus)
        {
            _sofastatus = sofastatus;
        }
        #endregion

        #region Métodos

        [HttpGet]
        public async Task<ActionResult> PegarTodosSofasAsync()
        {
            var lista = await _sofastatus.PegarTodosSofasAsync();
            if (lista.Count < 1) return NoContent();
            return Ok(lista);
        }

        [HttpGet("id/{idSofa}")]
        public async Task<ActionResult> PegarSofasPeloIdAsync([FromRoute] int idTema)
        {
            try
            {
                return Ok(await _sofastatus.PegarSofasPeloIdAsync(idTema));
            }
            catch (Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> NovoSofaAsync([FromBody] Sofa sofa)
        {
            await _sofastatus.NovoSofaAsync(sofa);
            return Created($"api/Sofas", sofa);
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarSofa([FromBody] Sofa sofa)
        {
            try
            {
                await _sofastatus.AtualizarSofaAsync(sofa);
                return Ok(sofa);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }                       
        }

        [HttpDelete("deletar/{idSofa}")]
        public async Task<ActionResult> DeletarSofa([FromRoute] int idsofa)
        {
            try
            {
                await _sofastatus.DeletarSofaAsync(idsofa);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }

        [HttpGet("idInspetor/{idInspetor}")]
        public async Task<ActionResult> PegarSofasPeloIdDoInspetorAsync([FromRoute] int idInspetor)
        {
            try
            {
                return Ok(await _sofastatus.PegarTodosSofasPorInspetorAsync(idInspetor));
            }
            catch (Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }

        #endregion
    } 
}
