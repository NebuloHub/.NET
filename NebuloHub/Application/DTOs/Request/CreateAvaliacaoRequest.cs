namespace NebuloHub.Application.DTOs.Request
{
    public class CreateAvaliacaoRequest
    {
        /// <example>0 a 10</example>
        public long Nota { get; set; }
        public string? Comentario { get; set; }


        // Relacionamento
        public string UsuarioCPF { get; set; }
        public string StartupCNPJ { get; set; }
    }
}
