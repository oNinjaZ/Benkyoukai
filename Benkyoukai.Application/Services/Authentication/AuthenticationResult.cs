using Benkyoukai.Domain.Entities;

namespace Benkyoukai.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);