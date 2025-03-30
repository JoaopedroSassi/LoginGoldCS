using LoginGoldCS.Models.Entities;

namespace LoginGoldCS.Services.Interfaces;

public interface ILoginUserService
{
    public Task<Login> GetByEmailAsync(string email);
}