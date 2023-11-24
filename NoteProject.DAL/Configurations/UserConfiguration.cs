using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);
            builder.HasIndex(x => x.UserName).IsUnique();

            builder.HasData( 
                new User
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = "admin",
                    CreateDate = DateTime.Now,
                    IsActive = true,
                    Password = "admin123",
                    UserType = Domain.Enums.UserType.Admin,
                    Status = Domain.Enums.Status.Added
                });
        }
    }
}
