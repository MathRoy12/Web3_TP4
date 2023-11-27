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

            builder.Entity<Voyage>().HasData(
                new
                {
                    Id = 1,
                    Destination = "Séoul",
                    Img =
                        "https://content.r9cdn.net/rimg/dimg/30/0c/6318617a-city-35982-163ff913019.jpg?width=1366&height=768&xhint=2421&yhint=1876&crop=true",
                    IsPublic = true
                },
                new
                {
                    Id = 2,
                    Destination = "Tachkent",
                    Img =
                        "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/15/33/fb/7b/tashkent.jpg?w=700&h=500&s=1",
                    IsPublic = true
                },
                new
                {
                    Id = 3,
                    Destination = "Damas",
                    Img =
                        "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Damascus2009.JPG/1200px-Damascus2009.JPG",
                    IsPublic = false
                },
                new
                {
                    Id = 4,
                    Destination = "Kiev",
                    Img = "https://cdn.britannica.com/18/194818-050-E7A7A993/view-Kiev-Ukraine.jpg",
                    IsPublic = false
                },
                new
                {
                    Id = 5,
                    Destination = "Jérusalem",
                    Img =
                        "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a4/2014-06_Israel_-_Jerusalem_090_%2814936890061%29.jpg/640px-2014-06_Israel_-_Jerusalem_090_%2814936890061%29.jpg",
                    IsPublic = false
                },
                new
                {
                    Id = 6,
                    Destination = "Pyongyang",
                    Img =
                        "https://static.latribune.fr/1061511/les-sanctions-us-mauvaises-pour-la-denuclearisation-selon-pyongyang.jpg",
                    IsPublic = true
                },
                new
                {
                    Id = 7,
                    Destination = "Moscou",
                    Img =
                        "https://aeroports-de-lyon.imgix.net/sites/default/files/2020-05/moscou-header.jpg?fit=max&ixlib=php-3.3.1&w=900&s=c4a830ca34826699af3b72b3560efc32",
                    IsPublic = false
                },
                new
                {
                    Id = 8,
                    Destination = "Kigali",
                    Img =
                        "https://prod.cdn-medias.jeuneafrique.com/cdn-cgi/image/q=auto,f=auto,metadata=none,width=1215,height=810,fit=cover/https://prod.cdn-medias.jeuneafrique.com/medias/2017/07/21/13764hr_-e1501750068833.jpg",
                    IsPublic = false
                });

            builder.Entity<Voyage>()
                .HasMany(u => u.Proprietaires)
                .WithMany(v => v.Voyages)
                .UsingEntity(e =>
                {
                    e.HasData(new {ProprietairesId = "fc647606-84c1-11ee-b9d1-0242ac120002", VoyagesId = 1});
                    e.HasData(new {ProprietairesId = "fc647c64-84c1-11ee-b9d1-0242ac120002", VoyagesId = 2});
                    e.HasData(new {ProprietairesId = "fc647608-84c1-11ee-b9d1-0242ac120002", VoyagesId = 3});
                    e.HasData(new {ProprietairesId = "fc647606-84c1-11ee-b9d1-0242ac120002", VoyagesId = 4});
                    e.HasData(new {ProprietairesId = "fc647c64-84c1-11ee-b9d1-0242ac120002", VoyagesId = 5});
                    e.HasData(new {ProprietairesId = "fc647608-84c1-11ee-b9d1-0242ac120002", VoyagesId = 6});
                    e.HasData(new {ProprietairesId = "fc647606-84c1-11ee-b9d1-0242ac120002", VoyagesId = 7});
                    e.HasData(new {ProprietairesId = "fc647c64-84c1-11ee-b9d1-0242ac120002", VoyagesId = 8});
                });
        }

        public DbSet<Voyage> Voyage { get; set; } = default!;
    }
}