using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRAssignment.DataAccess.Entities;
using SignalRAssignment.Shared.BusinessModels;
using SignalRAssignment.Shared.RequestModels;

namespace SignalRAssignment.DataAccess.Interfaces
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<Post?> GetPostDetailsById(int id);

        Task<PagedResultModel<Post>> GetPagedPosts(QueryPagedPostRequest request);
    }
}