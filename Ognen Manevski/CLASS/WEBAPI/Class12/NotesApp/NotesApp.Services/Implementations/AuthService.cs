using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NotesApp.Configuration;
using NotesApp.DataAccess.Interfaces;
using NotesApp.Domain.Models;
using NotesApp.Dtos;
using NotesApp.Services.CustomExceptions;
using NotesApp.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace NotesApp.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly JwtSettings _jwtSettings;

    public AuthService(
        IUserRepository userRepository,
        IOptions<JwtSettings> jwtSettings
        )
    {
        _userRepository = userRepository;
        _jwtSettings = jwtSettings.Value;
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

    public async Task <LoginResponseDto> LoginAsync(LoginDto loginDto)
    {
        //1. validate input data
        if (string.IsNullOrWhiteSpace(loginDto.Username) ||
            string.IsNullOrWhiteSpace(loginDto.Password))
        {
            throw new UserDataException("Username and password are required.");
        }

        //2. Find the user by username
        User? userDb = await _userRepository.GetByUsernameAsync(loginDto.Username);

        //3. Validate the password
        if (userDb == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, userDb.Password))
        {
            throw new InvalidCredentialsException("Invalid username or password.");
        }

        //4.Generate JWT token
        string token = GenerateToken(userDb);

        return new LoginResponseDto
        {
            Token = token
        };

    }


    private string GenerateToken(User user)
    {
        //Header.Payload.Signature

        //1. Defining the claims
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim("fullName", user.FullName),
        };

        //2. The sisgning key, from cofiguration
        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

        //3. Key + algorithm = the credentials that produce the SUGNATURE of the token
        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //4. When the token expires
        DateTime expiresAtUtc = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes);

        //5. Describe the token
        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            Subject = new ClaimsIdentity(claims), //payload
            Expires = expiresAtUtc,
            SigningCredentials = signingCredentials
        };

        //6. Create the token and serialize it to the "Header.Payload.Signature" string
        JwtSecurityTokenHandler tokenHandler = new ();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        string tokenString = tokenHandler.WriteToken(token);


        return tokenString;
    }



}
