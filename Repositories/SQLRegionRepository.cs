using App1.Data;
using App1.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace App1.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly App1DbContext dbContext;
        public SQLRegionRepository(App1DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> create(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> delete(Guid id)
        {
            var existingRegion =await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            else
            {
                dbContext.Regions.Remove(existingRegion);
                await dbContext.SaveChangesAsync();
                return existingRegion;
            }
        }

        public async Task<List<Region>> GetAll()
        {

            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetById(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> update(Guid id, Region region)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            else
            {
                existingRegion.Code = region.Code;
                existingRegion.Name = region.Name;
                existingRegion.RegionImageUrl = region.RegionImageUrl;
                await dbContext.SaveChangesAsync();
                return existingRegion;
            }
        }
    }
}