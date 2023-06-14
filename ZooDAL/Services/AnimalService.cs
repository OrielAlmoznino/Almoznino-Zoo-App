using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDAL.Entities;
using ZooDAL.Services.Interfaces;

namespace ZooDAL.Services
{
    public class AnimalService : ZooServiceBase<Animal>, IAnimalService
    {
        public AnimalService(ZooDbContext dbContext) : base(dbContext) { }
        public async Task<IEnumerable<Animal>> GetAnimalsWithCategories()
        {
            var animals = await GetAllAsync();
            var categories = await _dbContext.Categories.ToListAsync();

            foreach (var animal in animals)
            {
                animal.Category = categories.FirstOrDefault(x => animal.CategoryID == x.Id);
            }

            return animals;
        }
        public async Task<Animal> GetAnimalWithCategory(Guid id)
        {
            var animal = await GetByIdAsync(id);
            if (animal == null)
            {
                throw new ArgumentException($"Entity with ID {id} does not exist.");
            }
            var categories = await _dbContext.Categories.ToListAsync();

            animal.Category = categories.FirstOrDefault(x => animal.CategoryID == x.Id);

            return animal;
        }
        public async Task<IEnumerable<Animal>> GetAnimalsByCategory(Guid categoryId)
        {
            var animals = await GetAllAsync();
            var categories = await _dbContext.Categories.ToListAsync();

            var categoryMatch = categories.FirstOrDefault(c => c.Id == categoryId);
            if (categoryMatch == null)
            {
                throw new ArgumentException("The specified category does not exist.");
            }

            var animalsByCategory = animals.Where(x => x.CategoryID == categoryMatch.Id).ToList();

            return animalsByCategory;
        }
        public async Task<IEnumerable<Animal>> GetTopTwoAnimals()
        {
            var animals = await GetAnimalsWithCategories();
            var comments = await _dbContext.Comments.ToListAsync();

            foreach (var animal in animals)
            {
                var animalComments = comments.Where(comment => comment.AnimalID == animal.Id);
                animal.Comments = animalComments;
            }

            var topAnimals = animals.OrderByDescending(animal => animal.Comments.Count()).Take(2).ToList();

            return topAnimals;
        }
    }
}
