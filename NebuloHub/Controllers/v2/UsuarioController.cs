using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NebuloHub.Application.DTOs.Request;
using NebuloHub.Application.DTOs.Response;
using NebuloHub.Application.UseCase;
using NebuloHub.Application.Validators;
using System.Net;

namespace NebuloHub.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    [Tags("CRUD Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioUseCase _usuarioUseCase;
        private readonly CreateUsuarioRequestValidator _validationUsuario;

        // ILogger
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(
            UsuarioUseCase usuarioUseCase,
            CreateUsuarioRequestValidator validationUsuario,
            ILogger<UsuarioController> logger)
        {
            _usuarioUseCase = usuarioUseCase;
            _validationUsuario = validationUsuario;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<CreateUsuarioResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsuario()
        {
            _logger.LogInformation("Iniciando busca de todos os usuários...");

            var usuario = await _usuarioUseCase.GetAllPagedAsync();

            _logger.LogInformation("Busca de usuários concluída. {count} registros encontrados.", usuario.Count());

            var result = usuario.Select(d => new
            {
                d.CPF,
                d.Nome,
                d.Email,
                links = new
                {
                    self = Url.Action(nameof(GetUsuarioById), new { cpf = d.CPF })
                }
            });

            return Ok(new
            {
                totalItems = usuario.Count(),
                items = result
            });
        }

        [HttpGet("{cpf}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(CreateUsuarioResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetUsuarioById(string cpf)
        {
            _logger.LogInformation("Buscando usuário com CPF {cpf}", cpf);

            var usuario = await _usuarioUseCase.GetByIdAsync(cpf);
            if (usuario == null)
            {
                _logger.LogWarning("Usuário {cpf} não encontrado.", cpf);
                return NotFound();
            }

            _logger.LogInformation("Usuário {cpf} encontrado com sucesso.", cpf);
            return Ok(usuario);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(CreateUsuarioResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostUsuario([FromBody] CreateUsuarioRequest request)
        {
            _logger.LogInformation("Iniciando criação do usuário {cpf}", request.CPF);

            _validationUsuario.ValidateAndThrow(request);

            var usuarioResponse = await _usuarioUseCase.CreateUsuarioAsync(request);

            _logger.LogInformation("Usuário {cpf} criado com sucesso.", usuarioResponse.CPF);

            return CreatedAtAction(nameof(GetUsuarioById),
                new { cpf = usuarioResponse.CPF }, usuarioResponse);
        }

        [HttpPut("{cpf}")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PutUsuario(string cpf, [FromBody] CreateUsuarioRequest request)
        {
            _logger.LogInformation("Atualizando usuário {cpf}", cpf);

            var updated = await _usuarioUseCase.UpdateUsuarioAsync(cpf, request);
            if (!updated)
            {
                _logger.LogWarning("Tentativa de atualizar usuário {cpf}, mas o registro não existe.", cpf);
                return NotFound();
            }

            _logger.LogInformation("Usuário {cpf} atualizado com sucesso.", cpf);
            return NoContent();
        }

        [HttpDelete("{cpf}")]
        [Authorize(Roles = "ADMIN")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteUsuario(string cpf)
        {
            _logger.LogInformation("Deletando usuário {cpf}", cpf);

            var deleted = await _usuarioUseCase.DeleteUsuarioAsync(cpf);
            if (!deleted)
            {
                _logger.LogWarning("Tentativa de deletar usuário {cpf}, porém não encontrado.", cpf);
                return NotFound();
            }

            _logger.LogInformation("Usuário {cpf} deletado com sucesso.", cpf);
            return NoContent();
        }
    }
}
