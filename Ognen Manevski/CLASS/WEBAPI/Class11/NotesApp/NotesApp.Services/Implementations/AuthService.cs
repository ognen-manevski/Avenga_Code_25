using NotesApp.DataAccess.Interfaces;
using NotesApp.Domain.Models;
using NotesApp.Dtos;
using NotesApp.Services.CustomExceptions;
using NotesApp.Services.Interfaces;

namespace NotesApp.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
    {
        //1. validate input data
        ValidateRegistration(registerDto);

        //2. validate username uniqueness
        bool usernameExists = await _userRepository.CheckUserNameExistsAsync(registerDto.Username);

        if (usernameExists)
        {
            throw new UserDataException("Username already exists. Please choose a different username.");
        }

        //3. hash the password
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);


        //4. map to User entity
        User newUser = new User
        {
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            Username = registerDto.Username,
            Password = passwordHash
        };

        //5. save to database
        await _userRepository.AddAsync(newUser);

        //6. return the created user (without password)
        return  new UserDto
        {
            Id = newUser.Id,
            FirstName = registerDto.FirstName,
            LastName= registerDto.LastName,
            Username= registerDto.Username,
        };

    }

    private void ValidateRegistration(RegisterDto registerDto)
    {
        //usernames
        if (string.IsNullOrWhiteSpace(registerDto.FirstName) || registerDto.FirstName.Length > 100)
        {
            throw new UserDataException("First name is required and should not exceed 100 characters.");
        }
        if (string.IsNullOrWhiteSpace(registerDto.LastName) || registerDto.LastName.Length > 100)
        {
            throw new UserDataException("Last name is required and should not exceed 100 characters.");
        }
        if (string.IsNullOrWhiteSpace(registerDto.Username) || registerDto.Username.Length > 30)
        {
            throw new UserDataException("Username is required and should not exceed 30 characters.");
        }
        //pw
        if (string.IsNullOrWhiteSpace(registerDto.Password) || registerDto.Password.Length < 8)
        {
            throw new UserDataException("Password is required and should be at least 8 characters long.");
        }
        //confirm pw
        if (registerDto.Password != registerDto.ConfirmPassword)
        {
            throw new UserDataException("Entered passwords do not match.");
        }

    }


}
