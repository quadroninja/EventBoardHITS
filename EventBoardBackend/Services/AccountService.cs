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
        //private readonly AppDbContext _dbContext;
        //private readonly PasswordHasher _passwordHasher;
        //public AccountService(AppDbContext context, PasswordHasher hasher)
        //{
        //    _passwordHasher = hasher;
        //    _dbContext = context;
        //}

        //public async Task Register(RegisterDto registrationData)
        //{
        //    string hashedPassword = _passwordHasher.Generate(registrationData.Password);

        //    UserModel user = new UserModel { Email = registrationData.Email, 
        //                                     HashedPassword = hashedPassword, 
        //                                     Name = registrationData.Name,
        //                                     Surname = registrationData.Surname,
        //                                     Patronymic = registrationData.Patronymic,
        //                                     Role = registrationData.Role,
        //                                     Status = UserStatus.PENDING,
        //                                     RejectionReason = null
        //                                    };

        //    await _dbContext.AddAsync(user);
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task Login(LoginDto loginData)
        //{
            
        //}
    }
}
