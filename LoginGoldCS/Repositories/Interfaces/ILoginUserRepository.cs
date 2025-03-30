using LoginGoldCS.Models.Entities;

namespace LoginGoldCS.Repositories.Interfaces;

public interface ILoginUserRepository
{
    Task<Login> GetByEmailAsync(string email);
}
