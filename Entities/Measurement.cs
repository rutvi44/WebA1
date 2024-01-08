using System.ComponentModel.DataAnnotations;

namespace Assignment1RM.Entities
{
    public class Measurement
    {
        public int MeasurementId { get; set; }

        [Required(ErrorMessage = "Please enter Systolic measurement")]
        [Range(20, 400, ErrorMessage = "Systolic value must be between 20 and 400")]
        public int? Systolic { get; set; }

        [Required(ErrorMessage = "Please enter Diastolic measurement")]
        [Range(10, 300, ErrorMessage = "Diastolic value must be between 10 and 300")]
        public int? Diastolic { get; set; }

        [Required(ErrorMessage = "Please enter Date")]
        public string? Date { get; set; }
   
        [Required(ErrorMessage = "Please enter Position")]
        public string? PositionId { get; set; }

        public Position? Position { get; set; }

        public string Category
        {
            get
            {
                if (Systolic < 120 && Diastolic < 80)
                {                    
                    return "Normal";
                }
                else if ((Systolic >= 120 && Systolic <= 130) && (Diastolic < 85))
                {
                    return "Elevated";
                }
                else if ((Systolic >= 130 && Systolic <= 139) && (Diastolic >= 80 && Diastolic <= 89))
                {
                    return "Hypertension Stage 1";
                }
                else if ((Systolic >= 140 && Systolic <= 180) && (Diastolic >= 90 && Diastolic <= 120))
                {
                    return "Hypertension Stage 2";
                }
                else
                {
                    return "Hypertensive Crisis";
                }
            }
        }
    }
}
