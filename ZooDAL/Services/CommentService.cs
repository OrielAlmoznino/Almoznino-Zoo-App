using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDAL.Entities;
using ZooDAL.Services.Interfaces;

namespace ZooDAL.Services
{
    public class CommentService : ZooServiceBase<Comment>, ICommentService
    {
        public CommentService(ZooDbContext dbContext) : base(dbContext) { }
        public async Task<IEnumerable<Comment>> GetCommentsForAnimal(Animal animal)
        {
            var comments = await GetAllAsync();

            var commentsForAnimal = comments.Where(x => x.AnimalID == animal.Id).ToList();

            return commentsForAnimal;
        }
        public async Task DeleteCommentsForAnimal(Animal animal)
        {
            var commentsForAnimal = await GetCommentsForAnimal(animal);

            if (commentsForAnimal.Count() == 0)
            {
                return;//throw new ArgumentException("There are no comments for the specified animal.");
            }

            var commentsTable = _dbContext.Comments;
            commentsTable.RemoveRange(commentsForAnimal);
            await _dbContext.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}
