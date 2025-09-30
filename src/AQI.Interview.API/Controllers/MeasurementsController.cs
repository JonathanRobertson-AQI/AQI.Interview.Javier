using Microsoft.AspNetCore.Mvc;
using AQI.Interview.Models;
using AQI.Interview.API.Models.DTOs;
using AQI.Interview.API.Services.Contracts;


namespace AQI.Interview.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeasurementsController : ControllerBase
    {
        private readonly IMeasurementService _measurementService;
        private readonly ILogger<MeasurementsController> _logger;

        public MeasurementsController(IMeasurementService measurementService, ILogger<MeasurementsController> logger)
        {
            _measurementService = measurementService;
            _logger = logger;
        }

        // URL: GET api/measurements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Measurement>>> GetAll()
        {
            var measurements = await _measurementService.GetAllAsync();
            _logger.LogInformation("Retrieved {Count} measurements", measurements.Count());
            
            return Ok(measurements);
        }

        // URL: GET api/measurements/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Measurement>> GetById(long id)
        {
            var measurement = await _measurementService.GetByIdAsync(id);
            if (measurement == null)
            {
                _logger.LogWarning("Measurement with ID {MeasurementId} not found", id);
                return NotFound();
            }
            
            _logger.LogInformation("Successfully retrieved measurement with ID: {MeasurementId}", id);
            
            return Ok(measurement);
        }

        // URL: POST api/measurements
        [HttpPost]
        public async Task<ActionResult<Measurement>> Create([FromBody] MeasurementCreateDto dto)
        {
            var measurement = await _measurementService.CreateAsync(dto);
            _logger.LogInformation("Successfully created measurement with ID: {MeasurementId}", measurement.MeasurementId);
            
            return CreatedAtAction(nameof(GetById), new { id = measurement.MeasurementId }, measurement);
        }

        // URL: PUT api/measurements/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] MeasurementUpdateDto dto)
        {
            var success = await _measurementService.UpdateAsync(id, dto);
            
            if (!success)
            {
                _logger.LogWarning("Failed to update measurement with ID {MeasurementId} - measurement not found", id);
                return NotFound();
            }

            _logger.LogInformation("Successfully updated measurement with ID: {MeasurementId}", id);
            
            return NoContent();
        }

        // URL: DELETE api/measurements/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var success = await _measurementService.DeleteAsync(id);
            
            if (!success)
            {
                _logger.LogWarning("Failed to delete measurement with ID {MeasurementId} - measurement not found", id);
                return NotFound();
            }

            _logger.LogInformation("Successfully deleted measurement with ID: {MeasurementId}", id);
            
            return NoContent();
        }
    }
}