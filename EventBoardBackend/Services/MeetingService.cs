using EventBoardBackend.Data;
using EventBoardBackend.Data.DTO;
using EventBoardBackend.Data.Models.Entities;
using EventBoardBackend.Models.Entities;
using EventBoardBackend.Services.Auth;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EventBoardBackend.Services
{
    public class MeetingService
    {
        private readonly AppDbContext _dbContext;
        
        public MeetingService(AppDbContext context)
        {

            _dbContext = context;
        }

        public async Task<List<MeetingDto>> GetAllMeetings()
        {
            return await _dbContext.Meetings.Select(model =>
                new MeetingDto
                {
                    Title = model.Title,
                    Description = model.Description,
                    MeetingDateTime = model.MeetingDateTime
                }).ToListAsync();
        }

        public async Task<MeetingDto> GetMeetingById(int id)
        {
            var model = await _dbContext.Meetings.FindAsync(id);
            return new MeetingDto
            {
                Title = model.Title,
                Description = model.Description,
                MeetingDateTime = model.MeetingDateTime
            };
        }

        public async Task<MeetingDto> CreateMeeting(MeetingDto newMeeting, int managerId)
        {
            await _dbContext.Meetings.AddAsync(new MeetingModel
            {
                Title = newMeeting.Title,
                Description = newMeeting.Description,
                MeetingDateTime = newMeeting.MeetingDateTime,
                Manager = await _dbContext.Managers.FindAsync(managerId),
            });

            return newMeeting;
        }

    }
}
