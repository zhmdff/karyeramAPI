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

            if (employerProfile == null)
            {
                throw new KeyNotFoundException("Employer profile not found.");
            }

            return employerProfile;
        }

        public async Task<EmployerProfile> GetEmployerProfileByUserIdAsync(int userId)
        {
            var employerProfile = await _employerRepository.GetProfileByIdAsync(userId);

            if (employerProfile == null)
            {
                throw new KeyNotFoundException("Employer profile not found.");
            }

            return employerProfile;
        }

    }
}
