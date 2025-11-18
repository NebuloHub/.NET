using NebuloHub.Application.DTOs.Request;
using NebuloHub.Application.DTOs.Response;
using NebuloHub.Infraestructure.Repositores;
using NebuloHub.Infraestructure.Repositories;
using System.Text.Json;

namespace NebuloHub.Application.UseCase
{
    public class AnaliseStartupUseCase
    {
        private readonly StartupProcedureRepository _procedureRepository;

        public AnaliseStartupUseCase(StartupProcedureRepository procedureRepository)
        {
            _procedureRepository = procedureRepository;
        }

        public async Task<AnalisarStartupResponse> AnalisarAsync(AnalisarStartupRequest request)
        {
            // CLOB vindo do Oracle (string JSON)
            var resultado = await _procedureRepository.AnalisarStartupAsync(request.CNPJ);

            // Converte para objeto
            var jsonObject = JsonSerializer.Deserialize<object>(resultado);

            return new AnalisarStartupResponse
            {
                Resultado = jsonObject!
            };
        }

    }
}
