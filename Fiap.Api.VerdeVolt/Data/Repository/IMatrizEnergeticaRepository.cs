using Fiap.Api.VerdeVolt.Models;

namespace Fiap.Api.VerdeVolt.Data.Repository
{
    public interface IMatrizEnergeticaRepository
    {
        IEnumerable<MatrizEnergeticaModel> GetAll(int page, int size);
        MatrizEnergeticaModel GetById(long id);

        IEnumerable<MatrizEnergeticaModel> GetByPais(string pais);
        void Add(MatrizEnergeticaModel matrizEnergetica);
        void Update(MatrizEnergeticaModel matrizEnergetica);
        void Delete(MatrizEnergeticaModel matrizEnergetica);
    }
}
