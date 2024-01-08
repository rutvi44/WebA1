using Assignment1RM.Entities;
namespace Assignment1RM.Models
{
    public class MeasurementViewModel
    {
        public List<Position>? Positions { get; set; }
        public Measurement ActiveMeasurement { get; set; }
    }
}
