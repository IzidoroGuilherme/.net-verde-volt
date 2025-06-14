using Fiap.Api.VerdeVolt.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.VerdeVolt.Data.Repository
{
    public class MatrizEnergeticaRepository : IMatrizEnergeticaRepository
    {
        private readonly DatabaseContext _databaseContext;

        public MatrizEnergeticaRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<MatrizEnergeticaModel> GetAll(int page, int size)
        {
            return _databaseContext.MatrizEnergetica
            .Skip((page - 1) * page)
            .Take(size)
            .AsNoTracking()
            .ToList();
        }

        public MatrizEnergeticaModel GetById(long id)
        {
            return _databaseContext.MatrizEnergetica.Find(id);
        }

        public IEnumerable<MatrizEnergeticaModel> GetByPais(string pais)
        {
            return _databaseContext.MatrizEnergetica.Where(m => m.Pais.ToLower() == pais.ToLower()).ToList();

        }

        public void Add(MatrizEnergeticaModel matrizEnergetica)
        {
            _databaseContext.MatrizEnergetica.Add(matrizEnergetica);
            _databaseContext.SaveChanges();
        }

        public void Delete(MatrizEnergeticaModel matrizEnergetica)
        {
            _databaseContext.MatrizEnergetica.Remove(matrizEnergetica);
            _databaseContext.SaveChanges();
        }

        public void Update(MatrizEnergeticaModel matrizEnergetica)
        {
            _databaseContext.MatrizEnergetica.Update(matrizEnergetica);
            _databaseContext.SaveChanges();
        }

    }
}
