using ApiRestFullPruebaTecnica.Application.Interfaces;
using ApiRestFullPruebaTecnica.Infrastructure.Persistence;
using ApiRestFullPruebaTecnica.Infrastructure.UniOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.UnitOfWorks
{
    public class UnitOfWorkTest
    {
        private readonly Mock<ApplicationDbContext> _contextMock;
        private readonly Mock<ICandidatoRepository> _candidatoRepoMock;
        private readonly Mock<IApiMetricRepository> _apiMetricRepoMock;
        private readonly UnitOfWork _unitOfWork;


        public UnitOfWorkTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databaseName: "CandidatosDB")
                            .Options;

            _contextMock = new Mock<ApplicationDbContext>(options);
            _candidatoRepoMock = new Mock<ICandidatoRepository>();
            _apiMetricRepoMock = new Mock<IApiMetricRepository>();

            _unitOfWork = new UnitOfWork(_contextMock.Object)
            {
                Candidatos = _candidatoRepoMock.Object,
                ApiMetrics = _apiMetricRepoMock.Object
            };
        }


        [Fact]
        public async Task CommitAsync_ShouldSaveChanges()
        {
            // Arrange
            _contextMock.Setup(c => c.SaveChangesAsync(default))
                        .ReturnsAsync(1);

            // Act
            var result = await _unitOfWork.CommitAsync();

            // Assert
            Assert.Equal(1, result);
            _contextMock.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }
    }
}

  
