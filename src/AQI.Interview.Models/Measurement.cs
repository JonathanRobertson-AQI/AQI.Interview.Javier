using System;
using System.ComponentModel.DataAnnotations;

namespace AQI.Interview.Models
{
    public class Measurement
    {
        [Key]
        public long MeasurementId { get; set; }
        public double? NumericValue { get; set; }
        public string? StringValue { get; set; }
        public int Precision { get; set; }
        public Parameter Parameter { get; set; }
        public DateTime UTCCapturedTimestamp { get; set; }
        public DateTime UTCSavedTimestamp { get; set; }
    }
}
