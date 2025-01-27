using Ardalis.SharedKernel;
using Authentication.Domain.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDomainEventDispatcher? _dispatcher;

        public ApplicationDbContext(DbContextOptions options, IDomainEventDispatcher? dispatcher) : base(options)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Define relation one to many
            modelBuilder.Entity<Role>()
                        .HasMany(u => u.Users)
                        .WithOne(r => r.Role)
                        .HasForeignKey(k => k.RoleId)
                        .IsRequired();

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_dispatcher == null) return result;

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
