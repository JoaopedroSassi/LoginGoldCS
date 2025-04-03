using LoginGoldCS.Models.Entities;
using LoginGoldCS.Repositories.Interfaces;
using MongoDB.Driver;

namespace LoginGoldCS.Repositories;

public class LoginUserRepository : ILoginUserRepository
{
    private readonly IMongoCollection<Login> _loginCollection;

    public LoginUserRepository(IMongoDatabase database)
    {
        _loginCollection = database.GetCollection<Login>("logins"); ;
    }

    public async Task<Login> GetByEmailAsync(string email)
    {
        return await _loginCollection.Find(x => x.Email == email).FirstOrDefaultAsync();
    }
}
