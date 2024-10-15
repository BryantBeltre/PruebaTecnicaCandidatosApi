using ApiRestFullPruebaTecnica.Application.Commands.Candidatos;
using ApiRestFullPruebaTecnica.Application.DTOs.Candidatos;
using ApiRestFullPruebaTecnica.Application.Handlers.Commands.Candidatos;
using ApiRestFullPruebaTecnica.Application.Handlers.Queries.Candidatos;
using ApiRestFullPruebaTecnica.Application.Interfaces;
using ApiRestFullPruebaTecnica.Application.Queries.Candidatos;
using ApiRestFullPruebaTecnica.Domain.Entities;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Candidatos
{
    public class CandidatoHandlerTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IMapper _mapper;

        public CandidatoHandlerTest()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateCandidatosDto, Candidato>().ReverseMap();
                cfg.CreateMap<UpdateCandidatosDto, Candidato>().ReverseMap();
                cfg.CreateMap<CandidatoDto, Candidato>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }


        [Fact]
        public async Task CreateCandidatoCommandHandler_ShouldCreateCandidato()
        {
            // Arrange
            var candidatoCreateDto = new CreateCandidatosDto
            {
                Name = "Bryant",
                Surname = "Beltre",
                Email = "beltrebryant07@gmail.com",
                PhoneNumber = "8496278338",
                BirthDate = new System.DateTime(2003, 9, 7),
                AppliedPosition = "Desarrollador"
            };

            var candidato = new Candidato
            {
                Name = candidatoCreateDto.Name,
                Surname = candidatoCreateDto.Surname,
                Email = candidatoCreateDto.Email,
                PhoneNumber = candidatoCreateDto.PhoneNumber,
                BirthDate = candidatoCreateDto.BirthDate,
                AppliedPosition = candidatoCreateDto.AppliedPosition
            };

            _unitOfWorkMock.Setup(u => u.Candidatos.AddAsync(It.IsAny<Candidato>()))
                          .ReturnsAsync(candidato);
            _unitOfWorkMock.Setup(u => u.CommitAsync())
                          .ReturnsAsync(1);

            var handler = new CreateCandidatoCommandHandler(_unitOfWorkMock.Object, _mapper);
            var command = new CreateCandidatoCommand
            {
                CreateCandidatosDto = candidatoCreateDto
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Bryant", result.Name);
            _unitOfWorkMock.Verify(u => u.Candidatos.AddAsync(It.IsAny<Candidato>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateCandidatoCommandHandler_ShouldUpdateCandidato()
        {
            // Arrange
            var candidatoUpdateDto = new UpdateCandidatosDto
            {
                Id = Guid.NewGuid(),
                Name = "Francis Bryant",
                Surname = "Beltre Martinez",
                Email = "bryantbeltr@gmail.com",
                PhoneNumber = "8496278338",
                BirthDate = new System.DateTime(2003, 9, 7),
                AppliedPosition = "Analista"
            };

            var existingCandidato = new Candidato
            {
                Id = candidatoUpdateDto.Id,
                Name = "Bryant Jr",
                Surname = "Beltre Jr",
                Email = "bryantJr.BeltreJr@gmail.com",
                PhoneNumber = "8099221902",
                BirthDate = new System.DateTime(2003, 9, 8),
                AppliedPosition = "Desarrollador"
            };

            _unitOfWorkMock.Setup(u => u.Candidatos.GetByIdAsync(candidatoUpdateDto.Id))
                          .ReturnsAsync(existingCandidato);
            _unitOfWorkMock.Setup(u => u.Candidatos.UpdateAsync(existingCandidato))
                          .ReturnsAsync(existingCandidato);
            _unitOfWorkMock.Setup(u => u.CommitAsync())
                          .ReturnsAsync(1);

            var handler = new UpdatedCandidatoCommandHandler(_unitOfWorkMock.Object, _mapper);
            var command = new UpdateCandidatoCommand
            {
                UpdateCandidatosDto = candidatoUpdateDto
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Francis Bryant", result.Name);
            Assert.Equal("Beltre Martinez", result.Surname);
            Assert.Equal("bryantbeltr@gmail.com", result.Email);
            Assert.Equal("8496278338", result.PhoneNumber);
            Assert.Equal("Analista", result.AppliedPosition);
            _unitOfWorkMock.Verify(u => u.Candidatos.GetByIdAsync(candidatoUpdateDto.Id), Times.Once);
            _unitOfWorkMock.Verify(u => u.Candidatos.UpdateAsync(existingCandidato), Times.Once);
            _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteCandidatoCommandHandler_ShouldDeleteCandidato()
        {
            // Arrange
            var candidatoId = Guid.NewGuid();

            _unitOfWorkMock.Setup(u => u.Candidatos.DeleteAsync(candidatoId))
                          .ReturnsAsync(true);
            _unitOfWorkMock.Setup(u => u.CommitAsync())
                          .ReturnsAsync(1);

            var handler = new DeleteCandidatoCommandHandler(_unitOfWorkMock.Object);
            var command = new DeleteCandidatoCommand(candidatoId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
            _unitOfWorkMock.Verify(u => u.Candidatos.DeleteAsync(candidatoId), Times.Once);
            _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task GetAllCandidatosQueryHandler_ShouldReturnAllCandidatos()
        {
            // Arrange
            var candidatos = new List<Candidato>
            {
                new Candidato
                {
                    Id = Guid.NewGuid(),
                    Name = "Bryant",
                    Surname = "Beltre",
                    Email = "beltrebryant07@gmail.com",
                    PhoneNumber = "8496278338",
                    BirthDate = new System.DateTime(2003, 9, 7),
                    AppliedPosition = "Desarrollador"
                },
                new Candidato
                {
                    Id = Guid.NewGuid(),
                    Name = "Francis Bryant",
                    Surname = "Beltre Martinez",
                    Email = "bryantbeltr@gmail.com",
                    PhoneNumber = "8496278338",
                    BirthDate = new System.DateTime(2003, 9, 7),
                    AppliedPosition = "Analista"
                }
            };

            _unitOfWorkMock.Setup(u => u.Candidatos.GetAllAsync())
                          .ReturnsAsync(candidatos);

            var handler = new GetAllCandidatosQueryHandler(_unitOfWorkMock.Object, _mapper);
            var query = new GetAllCandidatosQuery();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Collection(result,
                candidato =>
                {
                    Assert.Equal("Bryant", candidato.Name);
                },
                candidato =>
                {
                    Assert.Equal("Francis Bryant", candidato.Name);
                });
            _unitOfWorkMock.Verify(u => u.Candidatos.GetAllAsync(), Times.Once);
        }


        [Fact]
        public async Task GetCandidatoByIdQueryHandler_ShouldReturnCandidato()
        {
            // Arrange
            var candidatoId = Guid.NewGuid();
            var candidato = new Candidato
            {
                Id = candidatoId,
                Name = "Bryant",
                Surname = "Beltre",
                Email = "beltrebryant07@gmail.com",
                PhoneNumber = "8496278338",
                BirthDate = new System.DateTime(2003, 9, 7),
                AppliedPosition = "Desarrollador"
            };

            _unitOfWorkMock.Setup(u => u.Candidatos.GetByIdAsync(candidatoId))
                          .ReturnsAsync(candidato);

            var handler = new GetCandidatoByIdQueryHandler(_unitOfWorkMock.Object, _mapper);
            var query = new GetCandidatoByIdQuery(candidatoId);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Bryant", result.Name);
            _unitOfWorkMock.Verify(u => u.Candidatos.GetByIdAsync(candidatoId), Times.Once);
        }

        [Fact]
        public async Task GetCandidatoByIdQueryHandler_ShouldReturnNull_WhenCandidatoNotFound()
        {
            // Arrange
            var candidatoId = Guid.NewGuid();

            _unitOfWorkMock.Setup(u => u.Candidatos.GetByIdAsync(candidatoId))
                          .ReturnsAsync((Candidato)null);

            var handler = new GetCandidatoByIdQueryHandler(_unitOfWorkMock.Object, _mapper);
            var query = new GetCandidatoByIdQuery(candidatoId);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Null(result);
            _unitOfWorkMock.Verify(u => u.Candidatos.GetByIdAsync(candidatoId), Times.Once);
        }
    }
}
