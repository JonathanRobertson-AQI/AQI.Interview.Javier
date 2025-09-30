using AQI.Interview.Models;
using AQI.Interview.API.Models.DTOs;
using AQI.Interview.API.Services.Contracts;
using AQI.Interview.API.Data;
using Microsoft.EntityFrameworkCore;

namespace AQI.Interview.API.Services.Implementations
{
    public class MeasurementService : IMeasurementService
    {
        private readonly ApplicationDbContext _context;

        public MeasurementService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Measurement>> GetAllAsync()
        {
            return await _context.Measurements.ToListAsync();
        }

        public async Task<Measurement?> GetByIdAsync(long id)
        {
            return await _context.Measurements.FindAsync(id);
        }

        public async Task<Measurement> CreateAsync(MeasurementCreateDto dto)
        {
            var measurement = new Measurement
            {
                NumericValue = dto.NumericValue,
                StringValue = dto.StringValue,
                Precision = dto.Precision,
                Parameter = dto.Parameter,
                UTCCapturedTimestamp = dto.UTCCapturedTimestamp ?? DateTime.UtcNow,
                UTCSavedTimestamp = DateTime.UtcNow
            };

            _context.Measurements.Add(measurement);
            await _context.SaveChangesAsync();

            return measurement;
        }

        public async Task<bool> UpdateAsync(long id, MeasurementUpdateDto dto)
        {
            var measurement = await _context.Measurements.FindAsync(id);
            if (measurement == null)
                return false;

            if (dto.NumericValue.HasValue)
                measurement.NumericValue = dto.NumericValue;
            if (!string.IsNullOrEmpty(dto.StringValue))
                measurement.StringValue = dto.StringValue;
            if (dto.Precision.HasValue)
                measurement.Precision = dto.Precision.Value;
            if (dto.Parameter.HasValue)
                measurement.Parameter = dto.Parameter.Value;
            if (dto.UTCCapturedTimestamp.HasValue)
                measurement.UTCCapturedTimestamp = dto.UTCCapturedTimestamp.Value;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var measurement = await _context.Measurements.FindAsync(id);
            
            if (measurement == null)
                return false;

            _context.Measurements.Remove(measurement);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}