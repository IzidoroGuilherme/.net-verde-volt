using Fiap.Api.VerdeVolt.Data.Repository;
using Fiap.Api.VerdeVolt.Models;

namespace Fiap.Api.VerdeVolt.Services
{
    public class MatrizEnergeticaService : IMatrizEnergeticaService
    {
        private readonly IMatrizEnergeticaRepository _matrizEnergeticaRepository;

        public MatrizEnergeticaService(IMatrizEnergeticaRepository matrizEnergeticaRepository)
        {
            _matrizEnergeticaRepository = matrizEnergeticaRepository;
        }

        public MatrizEnergeticaModel BuscarMatrizPorId(long id)
        {
            return _matrizEnergeticaRepository.GetById(id);
        }

        public IEnumerable<MatrizEnergeticaModel> BuscarMatrizPorPais(string pais)
        {
            return _matrizEnergeticaRepository.GetByPais(pais);
        }

        public IEnumerable<MatrizEnergeticaModel> BuscarTodasAsMatrizes(int page, int size)
        {
            return _matrizEnergeticaRepository.GetAll(page, size);
        }
      
        public void SalvarMatriz(MatrizEnergeticaModel matrizEnergetica)
        {
            matrizEnergetica.PorcentagemFonteRenovavel = CalcularPorcentagemFonteRenovavel(matrizEnergetica);
            _matrizEnergeticaRepository.Add(matrizEnergetica);
        }

        public void AtualizarMatriz(MatrizEnergeticaModel matrizEnergetica)
        {
            matrizEnergetica.PorcentagemFonteRenovavel = CalcularPorcentagemFonteRenovavel(matrizEnergetica);
            _matrizEnergeticaRepository.Update(matrizEnergetica);
        }

        public void DeletarMatriz(MatrizEnergeticaModel matrizEnergetica)
        {
            _matrizEnergeticaRepository.Delete(matrizEnergetica);
        }

        public double CalcularPorcentagemFonteRenovavel(MatrizEnergeticaModel matriz)
        {
            // Soma das fontes renováveis
            double renovaveis = matriz.Hidroeletrica +
                                matriz.Biomassa +
                                matriz.Eolica +
                                matriz.Solar;

            // Soma de todas as fontes
            double total = renovaveis +
                           matriz.GasNatural +
                           matriz.Petroleo +
                           matriz.Nuclear;

            // Evita divisão por zero
            if (total == 0)
                return 0;

            // Porcentagem de renováveis
            return Math.Round((renovaveis / total) * 100, 2);
        }

    }
}
