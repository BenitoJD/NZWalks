using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public interface IWalkRepository
    {
       Task<Walk> CreateAsync(Walk walk);
       Task<List<Walk>> GetallAsync(string? filterOn = null, string? filterQuery = null, 
           string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize  = 1000);
       Task<Walk?>UpdateAsync(Guid id, Walk walk);
       Task<Walk?> GetByIdAsync(Guid id);

       Task<Walk?>DeleteAsync(Guid id);
    }
}
