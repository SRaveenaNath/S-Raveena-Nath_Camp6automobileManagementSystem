using automobileManagementSystem.Model;

namespace automobileManagementSystem.Repository
{
    public interface IAutoPartsRepository
    {
        Task<IEnumerable<AutoPart>> GetAllPartsAsync();
        Task<AutoPart> GetPartByIdAsync(int id);
        Task<AutoPart> AddPartAsync(AutoPart part);
        Task<AutoPart> UpdatePartAsync(AutoPart part);
        Task<bool> DeletePartAsync(int id);

    }

}
