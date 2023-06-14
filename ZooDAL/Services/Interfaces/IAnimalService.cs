using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDAL.Entities;

namespace ZooDAL.Services.Interfaces
{
    public interface IAnimalService : IZooServiceBase<Animal>
    {
        public Task<IEnumerable<Animal>> GetTopTwoAnimals();

        public Task<IEnumerable<Animal>> GetAnimalsByCategory(Guid categoryID);

        public Task<IEnumerable<Animal>> GetAnimalsWithCategories();

        public Task<Animal> GetAnimalWithCategory(Guid id);

    }
}
