using AutoMapper;
using Fiap.Api.VerdeVolt.Models;
using Fiap.Api.VerdeVolt.Services;
using Fiap.Api.VerdeVolt.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.VerdeVolt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatrizEnergeticaController : ControllerBase
    {
        private readonly IMatrizEnergeticaService _matrizEnergeticaService;
        private readonly IMapper _mapper;

        public MatrizEnergeticaController(IMatrizEnergeticaService matrizEnergeticaService, IMapper mapper)
        {
            _matrizEnergeticaService = matrizEnergeticaService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MatrizPaginacaoViewModel>> BuscarTodas([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var matrizes = _matrizEnergeticaService.BuscarTodasAsMatrizes(pagina, tamanho);
            var viewModelList = _mapper.Map<IEnumerable<MatrizEnergeticaExibicaoViewModel>>(matrizes);
            var viewModel = new MatrizPaginacaoViewModel
            {
                Matrizes = viewModelList,
                CurrentPage = pagina,
                PageSize = tamanho
            };
            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(long id)
        {
            var matriz = _matrizEnergeticaService.BuscarMatrizPorId(id);
            if (matriz == null)
                return NotFound("Matriz não encontrada.");

            var viewModelMatriz = _mapper.Map<MatrizEnergeticaExibicaoViewModel>(matriz);

            return Ok(viewModelMatriz);
        }

        [HttpGet("por-pais/{pais}")]
        public IActionResult BuscarPorPais(string pais)
        {
            var matriz = _matrizEnergeticaService.BuscarMatrizPorPais(pais);
            if (matriz == null)
                return NotFound($"Nenhuma matriz encontrada para o país: {pais}");

            var viewModelMatriz = _mapper.Map<IEnumerable<MatrizEnergeticaExibicaoViewModel>>(matriz);
            return Ok(viewModelMatriz);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Criar([FromBody] MatrizEnergeticaCadastroViewModel matrizCadastroViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var matriz = _mapper.Map<MatrizEnergeticaModel>(matrizCadastroViewModel);
            _matrizEnergeticaService.SalvarMatriz(matriz);
            return CreatedAtAction(nameof(BuscarPorId), new { id = matriz.MatrizId }, matriz);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Put(long id, [FromBody] MatrizEnergeticaCadastroViewModel matrizCadastroViewModel)
        {
            var matrizExistente = _matrizEnergeticaService.BuscarMatrizPorId(id);
            if (matrizExistente == null)
                return NotFound();


            _mapper.Map(matrizCadastroViewModel, matrizExistente);
            _matrizEnergeticaService.AtualizarMatriz(matrizExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Deletar(long id)
        {
            var matriz = _matrizEnergeticaService.BuscarMatrizPorId(id);
            if (matriz == null)
                return NotFound("Matriz não encontrada.");

            _matrizEnergeticaService.DeletarMatriz(matriz);
            return Ok("Matriz deletada com sucesso.");
        }
    }
}
