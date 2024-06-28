using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRAssignment.DataAccess.Interfaces;
using SignalRAssignment.DataAccess.Repositories;

namespace SignalRAssignment.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private readonly Lazy<IPostRepository> _postRepository;

        private readonly Lazy<IPostCategoryRepository> _postCategoryRepository;

        private readonly Lazy<IAppUserRepository> _appUserRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _postRepository = new Lazy<IPostRepository>(() => new PostRepository(context));
            _postCategoryRepository = new Lazy<IPostCategoryRepository>(() => new PostCategoryRepository(context));
            _appUserRepository = new Lazy<IAppUserRepository>(() => new AppUserRepository(context));
        }

        public IPostRepository PostRepository => _postRepository.Value;

        public IPostCategoryRepository PostCategoryRepository => _postCategoryRepository.Value;

        public IAppUserRepository AppUserRepository => _appUserRepository.Value;

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}