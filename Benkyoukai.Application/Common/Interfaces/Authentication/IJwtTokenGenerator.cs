using Benkyoukai.Domain.Entities;

namespace Benkyoukai.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
