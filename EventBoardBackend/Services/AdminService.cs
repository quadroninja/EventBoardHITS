using EventBoardBackend.Data;
using EventBoardBackend.Data.DTO;
using EventBoardBackend.Data.Enums;
using EventBoardBackend.Data.Models.Entities;

namespace EventBoardBackend.Services
{
    public class AdminService
    {

        private AppDbContext _dbContext;

        public AdminService(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task AcceptUser(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user != null)
            {
                user.Status = UserStatus.ACCEPTED;

                if (user.Role == UserRole.MANAGER)
                {
                    await _dbContext.Managers.AddAsync(new ManagerModel
                    {
                        Id = user.Id,
                        Company = await _dbContext.Companies.FindAsync(user.CompanyId),
                    });
                }
                else if (user.Role == UserRole.STUDENT)
                {
                    await _dbContext.Students.AddAsync(new StudentModel
                    {
                        Id = user.Id
                    });
                }


                await _dbContext.SaveChangesAsync();
            }
            return;
        }


        public async Task RejectUser(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user != null)
            {
                user.Status = UserStatus.REJECTED;
                await _dbContext.SaveChangesAsync();
            }
            return;
        }

        public async Task CreateCompany(CompanyDto company)
        {
            await _dbContext.Companies.AddAsync(new CompanyModel
            {
                Name = company.Name
            });
            await _dbContext.SaveChangesAsync();
            return;
        }
    }
}