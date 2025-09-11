using EventBoardBackend.CustomExceptions;
using EventBoardBackend.Data;
using EventBoardBackend.Data.DTO;
using EventBoardBackend.Data.Enums;
using EventBoardBackend.Data.Models.Entities;
using EventBoardBackend.Services.Auth;
using Microsoft.AspNetCore.Identity;

namespace EventBoardBackend.Services
{
    public class AccountService
    {
        private readonly AppDbContext _dbContext;
        private readonly PasswordHasher _passwordHasher;
        private readonly JwtProvider _jwtProvider;

        public AccountService(AppDbContext context, PasswordHasher hasher, JwtProvider jwtProvider)
        {
            _passwordHasher = hasher;
            _dbContext = context;
            _jwtProvider = jwtProvider; 
        }

        public async Task Register(RegisterDto registrationData)
        {
            string hashedPassword = _passwordHasher.Generate(registrationData.Password);

            UserModel user = new UserModel
            {
                Email = registrationData.Email,
                HashedPassword = hashedPassword,
                Name = registrationData.Name,
                Surname = registrationData.Surname,
                Patronymic = registrationData.Patronymic,
                Role = registrationData.Role,
                Status = UserStatus.PENDING,
                CompanyId = (registrationData.Role == UserRole.MANAGER) ? registrationData.CompanyId : null,
                RejectionReason = null
            };

            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> Login(LoginDto loginData)
        {
            UserModel user = await _dbContext.GetUserByEmail(loginData.Email);
            if (user == null)
                throw new LoginException("User not found");

            bool checkPassword = _passwordHasher.Verify(loginData.Password, user.HashedPassword);
            if (!checkPassword)
                throw new LoginException("Incorrect password");

            var token = _jwtProvider.GenerateToken(user);
            

            return token;
        }
    }
}
