using KaryeramAPI.DTOs;
using KaryeramAPI.Models;
using KaryeramAPI.Repositories;

namespace KaryeramAPI.Services
{
    public class EmployerService : IEmployerService
    {
        private readonly IEmployerRepository _employerRepository;

        public EmployerService(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }

        public async Task<EmployerProfile> GetEmployerProfileByIdAsync(int employerId)
        {
            var employerProfile = await _employerRepository.GetProfileByIdAsync(employerId);

            if (employerProfile == null) { throw new KeyNotFoundException("Employer profile not found."); }

            return employerProfile;
        }

        public async Task<EmployerProfile> GetEmployerProfileByUserIdAsync(int userId)
        {
            var employerProfile = await _employerRepository.GetProfileByUserIdAsync(userId);

            if (employerProfile == null) { throw new KeyNotFoundException("Employer profile not found."); }

            return employerProfile;
        }

        public async Task<EmployerProfile> AddProfile(int userId, EmployerProfileDTO dto)
        {
            var checkProfile = await _employerRepository.GetProfileByUserIdAsync(userId);
            if (checkProfile != null) return null!;
            var employerProfile = new EmployerProfile
            {
                UserId = userId,
                CompanyName = dto.CompanyName,
                Industry = dto.Industry,
                CompanyWebsite = dto.CompanyWebsite,
                ContactEmail = dto.ContactEmail,
                ContactPhone = dto.ContactPhone,
                LogoUrl = dto.LogoUrl
            };

            var result = await _employerRepository.AddAsync(employerProfile);

            return result;
        }

    }
}
