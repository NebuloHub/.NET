using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using NebuloHub.Application.UseCase;
using NebuloHub.Application.DTOs.Request;
using NebuloHub.Domain.Entity;
using NebuloHub.Infraestructure.Context;
using NebuloHub.Infraestructure.Repositores;
using System.Threading.Tasks;

public class PossuiUseCaseTests
{
    private readonly Mock<IRepository<Possui>> _repositoryMock;
    private readonly PossuiUseCase _useCase;
    private readonly AppDbContext _context;

    public PossuiUseCaseTests()
    {
        _repositoryMock = new Mock<IRepository<Possui>>();

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDB_Possui")
            .Options;

        _context = new AppDbContext(options);

        // passa os dois parâmetros obrigatórios
        _useCase = new PossuiUseCase(_repositoryMock.Object, _context);
    }

    [Fact]
    public async Task CreatePossui_DeveCriarPossuiComSucesso()
    {
        // Arrange
        var request = new CreatePossuiRequest
        {
            StartupCNPJ = "38206824750298",
            IdHabilidade = 321
            
        };

        _repositoryMock
            .Setup(r => r.AddAsync(It.IsAny<Possui>()))
            .Callback<Possui>(a => a.IdPossui = 1)
            .Returns(Task.CompletedTask);

        _repositoryMock
            .Setup(r => r.SaveChangesAsync())
            .Returns(Task.CompletedTask);

        // Act
        var result = await _useCase.CreatePossuiAsync(request);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.IdPossui);

        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Possui>()), Times.Once);
        _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }
}
