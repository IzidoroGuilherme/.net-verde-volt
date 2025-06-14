using Fiap.Api.VerdeVolt.Models;

namespace Fiap.Api.VerdeVolt.Services
{
    public interface IMatrizEnergeticaService
    {
        IEnumerable<MatrizEnergeticaModel> BuscarTodasAsMatrizes(int page, int size);
        MatrizEnergeticaModel BuscarMatrizPorId(long id);

        IEnumerable<MatrizEnergeticaModel> BuscarMatrizPorPais(string pais);
        void SalvarMatriz(MatrizEnergeticaModel matrizEnergetica);
        void AtualizarMatriz(MatrizEnergeticaModel matrizEnergetica);
        void DeletarMatriz(MatrizEnergeticaModel matrizEnergetica);
    }
}
