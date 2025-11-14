using NebuloHub.Domain.Enum;

namespace NebuloHub.Application.DTOs.Request
{
    public class CreateStartupRequest
    {
        /// <example>O CNPJ deve ter no minimo 14 digitos</example>
        public string CNPJ { get; set; }

        /// <example>Link de um video ja postado na internet</example>
        public string? Video { get; set; }
        public string NomeStartup { get; set; }
        public string? Site { get; set; }
        public string Descricao { get; set; }
        public string? NomeResponsavel { get; set; }
        public string EmailStartup { get; set; }

        // Relacionamento
        public string UsuarioCPF { get; set; }
    }
}
