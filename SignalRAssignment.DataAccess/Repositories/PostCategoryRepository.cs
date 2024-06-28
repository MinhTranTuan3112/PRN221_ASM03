using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRAssignment.DataAccess.Entities;
using SignalRAssignment.DataAccess.Interfaces;

namespace SignalRAssignment.DataAccess.Repositories
{
    public class PostCategoryRepository : GenericRepository<PostCategory>, IPostCategoryRepository
    {
        public PostCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}