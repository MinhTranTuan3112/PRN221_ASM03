using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRAssignment.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IPostRepository PostRepository { get; }

        IPostCategoryRepository PostCategoryRepository { get; }

        IAppUserRepository AppUserRepository { get; }

        Task<int> SaveChangesAsync();
    }
}