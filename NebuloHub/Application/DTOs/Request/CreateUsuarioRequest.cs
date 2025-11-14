using NebuloHub.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace NebuloHub.Application.DTOs.Request
{
    public class CreateUsuarioRequest
    {
        /// <example>O CPF deve ter no minimo 11 digitos</example>
        public string CPF { get; set; }
        public string Nome { get; set; }

        /// <example>email@gmail.com</example>
        public string Email { get; set; }

        /// <example>Senha@135</example>
        public string Senha { get; set; }

        [EnumDataType(typeof(Role))]
        /// <example>USER</example>
        public Role Role { get; set; }
        public long? Telefone { get; set; }
    }
}
