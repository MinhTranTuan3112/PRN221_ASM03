using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignalRAssignment.DataAccess.Entities;

namespace SignalRAssignment.DataAccess.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(p => p.PostCategory)
                    .WithMany(pc => pc.Posts)
                    .HasForeignKey(p => p.CategoryID)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}