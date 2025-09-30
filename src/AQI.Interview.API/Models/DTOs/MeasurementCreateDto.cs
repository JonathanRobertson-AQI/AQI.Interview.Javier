using System;
using AQI.Interview.Models;

namespace AQI.Interview.API.Models.DTOs
{
    public class MeasurementCreateDto
    {
        public double? NumericValue { get; set; }
        public string? StringValue { get; set; }
        public int Precision { get; set; }
        public Parameter Parameter { get; set; }
        public DateTime? UTCCapturedTimestamp { get; set; }
    }
}