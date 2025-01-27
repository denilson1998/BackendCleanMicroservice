using Ardalis.SharedKernel;
using Coupons.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Coupons.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDomainEventDispatcher? _dispatcher;

        public ApplicationDbContext(DbContextOptions options, IDomainEventDispatcher? dispatcher) : base(options)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<Coupon> Coupons { get; set; }

        public DbSet<CouponAuthorizer> CouponAuthorizers { get; set; }

        public DbSet<CouponConfiguration> CouponConfigurations { get; set; }

        public DbSet<CouponType> CouponTypes { get; set; }

        public DbSet<CouponDetail> CouponDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CouponAuthorizer>()
                        .HasMany(c => c.Coupons)
                        .WithOne(a => a.CouponAuthorizer)
                        .HasForeignKey(k => k.CouponAuthorizerId)
                        .IsRequired();

            modelBuilder.Entity<CouponConfiguration>()
                        .HasMany(c => c.Coupons)
                        .WithOne(a => a.CouponConfiguration)
                        .HasForeignKey(k => k.CouponConfigurationId)
                        .IsRequired();

            modelBuilder.Entity<CouponType>()
                        .HasMany(c => c.CouponConfigurations)
                        .WithOne(t => t.CouponType)
                        .HasForeignKey(k => k.CouponTypeId)
                        .IsRequired();

            modelBuilder.Entity<Coupon>()
                        .HasMany(d => d.CouponDetail)
                        .WithOne(c => c.Coupon)
                        .HasForeignKey(k => k.CounponId)
                        .IsRequired();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
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