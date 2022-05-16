using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace MDS_BE.Entities
{
    public class DatabaseContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
        UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<UserOrganization> UserOrganizations { get; set; }
        public DbSet<Register> Register { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseSqlServer(@"Server=localhost,1433;Database=proiect_mds;User Id=sa;Password=someThingComplicated1234;Trusted_Connection=false;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Apelez metoda de pe classa de baza
            base.OnModelCreating(builder);

            // Am adaugat roluri
            builder.Entity<Role>().HasData(new IdentityRole
            {
                Name = "Prof",
                NormalizedName = "PROFESOR".ToUpper()
            },
                new IdentityRole
                {
                    Name = "Student",
                    NormalizedName = "STUDENT".ToUpper()
                },
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN".ToUpper()
                });

            builder.Entity<Post>()
                .Property(p => p.CreatedDate)
                .HasDefaultValueSql("getdate()");

            builder.Entity<Post>()
                .Property(p => p.Tags)
                .HasConversion(
                        t => string.Join(',', t),
                        t => t.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    );

            builder.Entity<User>()
                .HasMany(s => s.Posts)
                .WithOne(p => p.User);

            builder.Entity<User>()
                .HasMany(s => s.Comments)
                .WithOne(p => p.User);

            builder.Entity<User>()
                .HasOne(s => s.Register)
                .WithMany(p => p.User);

            builder.Entity<Post>()
                .HasMany(s => s.Comments)
                .WithOne(p => p.Post);

            builder.Entity<UserOrganization>().HasKey(uo => new { uo.UserId, uo.OrganizationId });

            builder.Entity<UserOrganization>()
                .HasOne(uo => uo.User)
                .WithMany(u => u.UserOrganizations)
                .HasForeignKey(uo => uo.UserId);

            builder.Entity<UserOrganization>()
                .HasOne(uo => uo.Organization)
                .WithMany(o => o.UserOrganizations)
                .HasForeignKey(uo => uo.OrganizationId);

        }
    }
}