using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jmepromeneavecmesvalises_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Build.Globbing;

namespace Jmepromeneavecmesvalises_API.Data
{
    public class Jmepromeneavecmesvalises_APIContext : IdentityDbContext<User>
    {
        public Jmepromeneavecmesvalises_APIContext(DbContextOptions<Jmepromeneavecmesvalises_APIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<User> list = new List<User>();

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            User u1 = new User()
            {
                Id = "fc647606-84c1-11ee-b9d1-0242ac120002",
                UserName = "Admin",
                Email = "admin@test.org",
                NormalizedEmail = "ADMIN@TEST.ORG",
                NormalizedUserName = "ADMIN"
            };
            u1.PasswordHash = hasher.HashPassword(u1, "Admin123");
            list.Add(u1);
            User u2 = new User()
            {
                Id = "fc647c64-84c1-11ee-b9d1-0242ac120002",
                UserName = "Moi",
                Email = "moi@test.org",
                NormalizedEmail = "MOI@TEST.ORG",
                NormalizedUserName = "MOI"
            };
            u2.PasswordHash = hasher.HashPassword(u2, "Moi123");
            list.Add(u2);
            User u3 = new User()
            {
                Id = "fc647608-84c1-11ee-b9d1-0242ac120002",
                UserName = "Toi",
                Email = "toi@test.org",
                NormalizedEmail = "TOI@TEST.ORG",
                NormalizedUserName = "TOI"
            };
            u3.PasswordHash = hasher.HashPassword(u3, "Toi123");
            list.Add(u3);

            builder.Entity<User>().HasData(list);
        }

        public DbSet<Voyage> Voyage { get; set; } = default!;
        public DbSet<Photo> Photos { get; set; } = default!;
        public DbSet<Couverture> Couvertures { get; set; } = default!;
    }
}