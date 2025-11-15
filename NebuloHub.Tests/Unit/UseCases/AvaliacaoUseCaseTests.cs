using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using NebuloHub.Application.UseCase;
using NebuloHub.Application.DTOs.Request;
using NebuloHub.Domain.Entity;
using NebuloHub.Infraestructure.Context;
using NebuloHub.Infraestructure.Repositores;
using System.Threading.Tasks;

public class AvaliacaoUseCaseTests
{
    private readonly Mock<IRepository<Avaliacao>> _repositoryMock;
    private readonly AvaliacaoUseCase _useCase;
    private readonly AppDbContext _context;

    public AvaliacaoUseCaseTests()
    {
        _repositoryMock = new Mock<IRepository<Avaliacao>>();

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDB_Avaliacao")
            .Options;

        _context = new AppDbContext(options);

        // passa os dois parâmetros obrigatórios
        _useCase = new AvaliacaoUseCase(_repositoryMock.Object, _context);
    }

    [Fact]
    public async Task CreateAvaliacao_DeveCriarAvaliacaoComSucesso()
    {
        // Arrange
        var request = new CreateAvaliacaoRequest
        {
            Nota = 10,
            Comentario = "Muito top",
            UsuarioCPF = "48302968275",
            StartupCNPJ = "38206824750298"
        };

        _repositoryMock
            .Setup(r => r.AddAsync(It.IsAny<Avaliacao>()))
            .Callback<Avaliacao>(a => a.IdAvaliacao = 1)
            .Returns(Task.CompletedTask);

        _repositoryMock
            .Setup(r => r.SaveChangesAsync())
            .Returns(Task.CompletedTask);

        // Act
        var result = await _useCase.CreateAvaliacaoAsync(request);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.IdAvaliacao);
        Assert.Equal(10, result.Nota);
        Assert.Equal("Muito top", result.Comentario);

        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Avaliacao>()), Times.Once);
        _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }
}
