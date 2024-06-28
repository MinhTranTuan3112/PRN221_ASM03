using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.DataAccess.Entities;
using SignalRAssignment.DataAccess.Interfaces;

namespace SignalRAssignment.DataAccess.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly ApplicationDbContext _context;
        public PostRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Post?> GetPostDetailsById(int id)
        {
            return await _context.Posts
                                    .Include(p => p.AppUser)
                                    .Include(p => p.PostCategory)
                                    .SingleOrDefaultAsync(p => p.PostID == id);
        }

        public async Task<List<Post>> GetPosts(string keyword = "")
        {
            var query = _context.Posts.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(p => p.Title.ToLower().Contains(keyword.ToLower()) 
                        || p.Content.ToLower().Contains(keyword.ToLower()));
            }

            return await query.ToListAsync();
        }
    }
}