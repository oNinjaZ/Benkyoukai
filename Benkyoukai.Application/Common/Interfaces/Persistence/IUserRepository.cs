using Benkyoukai.Domain.Entities;

namespace Benkyoukai.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}