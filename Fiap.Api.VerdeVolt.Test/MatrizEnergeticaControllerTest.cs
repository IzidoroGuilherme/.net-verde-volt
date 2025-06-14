using AutoMapper;
using Fiap.Api.VerdeVolt.Controllers;
using Fiap.Api.VerdeVolt.Models;
using Fiap.Api.VerdeVolt.Services;
using Fiap.Api.VerdeVolt.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Fiap.Api.VerdeVolt.Test
{
    public class MatrizEnergeticaControllerTest
    {
        [Fact]
        public void Criar_DeveRetornar201Created()
        {
            // Arrange
            var mockService = new Mock<IMatrizEnergeticaService>();
            var mockMapper = new Mock<IMapper>();

            var viewModel = new MatrizEnergeticaCadastroViewModel
            {
                Pais = "Brasil",
                Hidroeletrica = 10,
                Biomassa = 10,
                Eolica = 10,
                Solar = 10,
                GasNatural = 10,
                Petroleo = 20,
                Nuclear = 20
            };

            var modelComId = new MatrizEnergeticaModel
            {
                MatrizId = 123, // ID simulado que será retornado
                Pais = viewModel.Pais,
                PorcentagemFonteRenovavel = 55.55,
                Hidroeletrica = viewModel.Hidroeletrica,
                Biomassa = viewModel.Biomassa,
                Eolica = viewModel.Eolica,
                Solar = viewModel.Solar,
                GasNatural = viewModel.GasNatural,
                Petroleo = viewModel.Petroleo,
                Nuclear = viewModel.Nuclear
            };

            mockMapper.Setup(m => m.Map<MatrizEnergeticaModel>(viewModel))
                      .Returns(modelComId);

            var controller = new MatrizEnergeticaController(mockService.Object, mockMapper.Object);

            // Act
            var resultado = controller.Criar(viewModel);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(resultado);
            Assert.Equal(201, createdResult.StatusCode);
            Assert.Equal(nameof(controller.BuscarPorId), createdResult.ActionName);
        }
    }
}