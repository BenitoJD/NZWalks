using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions): base(dbContextOptions) 
        {
            
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("2d0c401a-2692-4319-af88-f5dc8cc1882f"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("2966e4be-e9c2-40aa-a138-682e5c1cdbf9"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("2e708c42-678e-4fb9-a389-3708c550aecd"),
                    Name = "Hard"
                }
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // seed data for Regions
            var regions = new List<Region>()
{
    new Region
    {
        Id = Guid.Parse("28a75517-4b97-49c8-a2fe-fdeeb21618b9"),
        Name = "Auckland",
        Code = "AKL",
        RegionImageUrl = "images.pixel.com/photos/auckland"
    },
    new Region
    {
        Id = Guid.Parse("17599607-1c37-4343-b015-dbdf67572807"),
        Name = "Wellington",
        Code = "WLG",
        RegionImageUrl = "images.pixel.com/photos/wellington"
    },
    new Region
    {
        Id = Guid.Parse("54be8188-ecde-47ff-9908-1f78fc122aeb"),
        Name = "Christchurch",
        Code = "CHC",
        RegionImageUrl = "images.pixel.com/photos/christchurch"
    },
    new Region
    {
        Id = Guid.Parse("88bf3d86-3721-4c85-a360-2ee1720cf87d"),
        Name = "Hamilton",
        Code = "HAM",
        RegionImageUrl = "images.pixel.com/photos/hamilton"
    },
    new Region
    {
        Id = Guid.Parse("e8dbdc31-e3fb-4436-b78d-ab8993334aba"),
        Name = "Tauranga",
        Code = "TRG",
        RegionImageUrl = "images.pixel.com/photos/tauranga"
    },
    new Region
    {
        Id = Guid.Parse("58632891-1d35-465c-8053-379e3d6566bd"),
        Name = "Dunedin",
        Code = "DUD",
        RegionImageUrl = "images.pixel.com/photos/dunedin"
    },
    new Region
    {
        Id = Guid.Parse("d43748c1-c040-49f2-a856-2e8f5e80ae3f"),
        Name = "Napier",
        Code = "NPE",
        RegionImageUrl = "images.pixel.com/photos/napier"
    },
    new Region
    {
        Id = Guid.Parse("a6dacde2-9ff7-44b7-8d7d-7881cb2150a5"),
        Name = "Rotorua",
        Code = "ROT",
        RegionImageUrl = "images.pixel.com/photos/rotorua"
    },
    new Region
    {
        Id = Guid.Parse("ee8bb125-6df3-487f-bbd6-6f7a590ce815"),
        Name = "Queenstown",
        Code = "ZQN",
        RegionImageUrl = "images.pixel.com/photos/queenstown"
    },
    new Region
    {
        Id = Guid.Parse("e1ff24cc-b9e9-4a13-9f9c-8254e125468c"),
        Name = "Nelson",
        Code = "NSN",
        RegionImageUrl = "images.pixel.com/photos/nelson"
    },
    new Region
    {
        Id = Guid.Parse("f2cb14e5-33fb-4c97-9c5c-2f347d65eead"),
        Name = "Palmerston North",
        Code = "PMR",
        RegionImageUrl = "images.pixel.com/photos/palmerston-north"
    },
    new Region
    {
        Id = Guid.Parse("1078793b-7c4c-4b8b-9529-510205577b52"),
        Name = "New Plymouth",
        Code = "NPL",
        RegionImageUrl = "images.pixel.com/photos/new-plymouth"
    },
    new Region
    {
        Id = Guid.Parse("7d30d8eb-b783-4a78-94e5-df49179c5273"),
        Name = "Whangarei",
        Code = "WRE",
        RegionImageUrl = "images.pixel.com/photos/whangarei"
    },
    new Region
    {
        Id = Guid.Parse("0f39db6b-065c-4cd2-b177-ad3152708314"),
        Name = "Invercargill",
        Code = "IVC",
        RegionImageUrl = "images.pixel.com/photos/invercargill"
    },
    new Region
    {
        Id = Guid.Parse("13668196-071a-4ab2-8cc1-c2c2914d3b3a"),
        Name = "Gisborne",
        Code = "GIS",
        RegionImageUrl = "images.pixel.com/photos/gisborne"
    }
};



            modelBuilder.Entity<Region>().HasData(regions);

        }
    }
}
