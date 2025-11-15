using Moq;
using Xunit;
using System.Threading.Tasks;
using NebuloHub.Application.UseCase;
using NebuloHub.Application.DTOs.Request;
using NebuloHub.Domain.Entity;
using NebuloHub.Infraestructure.Repositores;

public class HabilidadeUseCaseTests
{
    private readonly Mock<IRepository<Habilidade>> _repositoryMock;
    private readonly HabilidadeUseCase _useCase;

    public HabilidadeUseCaseTests()
    {
        _repositoryMock = new Mock<IRepository<Habilidade>>();

        _useCase = new HabilidadeUseCase(_repositoryMock.Object);
    }

    [Fact]
    public async Task CreateHabilidade_DeveCriarHabilidadeComSucesso()
    {
        // Arrange
        var request = new CreateHabilidadeRequest
        {
            NomeHabilidade = "Programação",
            TipoHabilidade = "Backend"
        };

        // Simula que o repositório salva e atribui ID
        _repositoryMock
            .Setup(r => r.AddAsync(It.IsAny<Habilidade>()))
            .Callback<Habilidade>(h => h.IdHabilidade = 1)
            .Returns(Task.CompletedTask);

        _repositoryMock
            .Setup(r => r.SaveChangesAsync())
            .Returns(Task.CompletedTask);

        // Act
        var result = await _useCase.CreateHabilidadeAsync(request);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.IdHabilidade);
        Assert.Equal(request.NomeHabilidade, result.NomeHabilidade);
        Assert.Equal(request.TipoHabilidade, result.TipoHabilidade);

        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Habilidade>()), Times.Once);
        _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }
}
