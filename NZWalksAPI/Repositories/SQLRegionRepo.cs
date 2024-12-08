using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class SQLRegionRepo : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLRegionRepo(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid RegionId)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == RegionId);
            if (existingRegion == null) 
            {
                return null;
            }
            dbContext.Regions.Remove(existingRegion);
            await dbContext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();       
        }

        public async Task<Region?> GetByIdAsync(Guid Id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x=>x.Id == Id);
        }

      

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var exisitingRegion = await dbContext.Regions.FirstOrDefaultAsync(x=>x.Id == id);
            if (exisitingRegion != null)
            {
                return null;
            }
            exisitingRegion.Code = region.Code;
            exisitingRegion.Name = region.Name; 
            exisitingRegion.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();
            return exisitingRegion;
        }
    }
}
