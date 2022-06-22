using Benkyoukai.Application.Common.Interfaces.Authentication;
using Benkyoukai.Application.Common.Interfaces.Persistence;
using Benkyoukai.Domain.Entities;

namespace Benkyoukai.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // validate that the user doesn't exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists");
        }

        // create user (generate unique ID) & persist to db
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        // create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        // validate that the user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
            throw new Exception("User with given email does not exist");

        // validate that the password is correct
        if (user.Password != password)
            throw new Exception("Invalid password");

        // create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}