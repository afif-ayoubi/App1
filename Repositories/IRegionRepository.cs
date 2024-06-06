using App1.Models.Domain;

namespace App1.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAll();
        Task<Region?> GetById(Guid id);

        Task<Region> create(Region region);

        Task<Region?> update(Guid id,Region region);

        Task<Region?> delete(Guid id);

    }
}