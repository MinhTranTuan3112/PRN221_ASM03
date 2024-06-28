using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRAssignment.DataAccess.Entities;

namespace SignalRAssignment.DataAccess.Interfaces
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<Post?> GetPostDetailsById(int id);

        Task<List<Post>> GetPosts(string keyword = "");
    }
}