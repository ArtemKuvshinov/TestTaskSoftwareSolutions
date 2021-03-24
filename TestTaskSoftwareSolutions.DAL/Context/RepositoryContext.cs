using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestTaskSoftwareSolutions.DAL.Domain;

namespace TestTaskSoftwareSolutions.DAL.Context
{
    public class RepositoryContext : DbContext
    {
        /// <summary>
        /// Initializes an instance <see cref="TestTaskSoftwareSolutionsContext"/>.
        /// </summary>
        /// <param name="options">Options.</param>
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Message>()
            .HasKey(p => p.Id);

            builder.Entity<Message>()
            .Property(p => p.Id)
            .IsRequired();

            builder.Entity<Message>()
           .Property(p => p.Phone)
           .IsRequired();

            builder.Entity<Message>()
          .Property(p => p.Text)
          .HasMaxLength(1000)
          .IsRequired();
        }

        public DbSet<Message> Messages { get; set; }
    }
}
