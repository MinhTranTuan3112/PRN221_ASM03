using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignalRAssignment.DataAccess.Entities;

namespace SignalRAssignment.DataAccess.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasIndex(u => u.Email)
                    .IsUnique();

            builder.HasMany(u => u.Posts)
                    .WithOne(p => p.AppUser)
                    .HasForeignKey(p => p.AuthorID)
                    .OnDelete(DeleteBehavior.Cascade);

            
        }
    }
}