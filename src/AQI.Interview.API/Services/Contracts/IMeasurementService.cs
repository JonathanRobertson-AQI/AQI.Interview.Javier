using AQI.Interview.Models;
using AQI.Interview.API.Models.DTOs;

namespace AQI.Interview.API.Services.Contracts
{
    public interface IMeasurementService
    {
        Task<IEnumerable<Measurement>> GetAllAsync();
        Task<Measurement?> GetByIdAsync(long id);
        Task<Measurement> CreateAsync(MeasurementCreateDto dto);
        Task<bool> UpdateAsync(long id, MeasurementUpdateDto dto);
        Task<bool> DeleteAsync(long id);
    }
}