using LibraryManagement.Domain;

namespace LibraryManagement.Application.Interfaces
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllAsync();
        Task<Member?> GetByIdAsync(string userId);
        Task AddAsync(Member member);
        Task UpdateAsync(Member member);
        Task DeleteAsync(string userId);
    }
}
