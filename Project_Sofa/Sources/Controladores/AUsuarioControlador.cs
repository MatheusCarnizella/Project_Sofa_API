using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Sofa.Sources.Repositorios;
using Project_Sofa.Sources.Servicos;
using System;
using System.Threading.Tasks;
using static Project_Sofa.Sources.Modelos.Modelo_do_AUsuario;

namespace Project_Sofa.Sources.Controladores
{
    [ApiController]
    [Route("api/AUsuarios")]
    [Produces("application/json")]

    public class AUsuarioControlador : ControllerBase
    {
        #region Atributos

        private readonly IAUsuario _repositorio;
        private readonly IAutenticacao _servicos;

        #endregion

        #region Construtores
        public AUsuarioControlador(IAUsuario repositorio, IAutenticacao servicos)
        {
            _repositorio = repositorio;
            _servicos = servicos;

        }
        #endregion

        #region Métodos
        [HttpGet("email/{emailAUsuario}")]
        public async Task<ActionResult> PegarAUsuarioPeloEmailAsync([FromRoute] string emailAUsuario)
        {
            var usuario = await _repositorio.PegarAUsuarioPeloEmailAsync(emailAUsuario);
            if (usuario == null) return NotFound(new {Mensagem = "Usuario não encontrado ou não existe" });

            return Ok(usuario);
        }

        [HttpPost("cadastrar")]
        [AllowAnonymous]
        public async Task<ActionResult> NovoAUsuarioAsync([FromBody] AUsuario ausuario)
        {
            try
            {
                await _repositorio.NovoAUsuarioAsync(ausuario);
                return Created($"api/Usuarios/{ausuario.Email}", ausuario);
            }
            catch (Exception ex)

            {
                return Unauthorized(ex.Message);

            }
        }
        [HttpPost("logar")]
        [AllowAnonymous]
        public async Task<ActionResult> LogarAsync([FromBody] AUsuario ausuario)
        {
            var auxiliar = await _repositorio.PegarAUsuarioPeloEmailAsync(ausuario.Email);
            if (auxiliar == null) return Unauthorized(new
            {
                Mensagem = "E-mail invalido"
            });
            if (auxiliar.Senha != _servicos.CodificarSenha(ausuario.Senha))
                return Unauthorized(new { Mensagem = "Senha invalida" });
            var token = "Bearer " + _servicos.GerarToken(auxiliar);
            return Ok(new { Usuario = auxiliar, Token = token });
        }


        #endregion

    }
}
