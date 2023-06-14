using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooDAL.Entities;

namespace ZooDAL.Services.Interfaces
{
    public interface ICommentService : IZooServiceBase<Comment>
    {
        Task<IEnumerable<Comment>> GetCommentsForAnimal(Animal animal);
        Task DeleteCommentsForAnimal(Animal animal);
    }
}
