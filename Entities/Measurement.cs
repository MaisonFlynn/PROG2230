using System.ComponentModel.DataAnnotations;

namespace Ass1gnment.Entities
{
    public class Measurement
    {
        public int MeasurementID { get; set; }

        [Required(ErrorMessage = "!Systolic")]
        [Range(20, 400, ErrorMessage = "Systolic >= 20 && <= 400")]
        public int? Systolic { get; set; }

        [Required(ErrorMessage = "!Diastolic")]
        [Range(10, 300, ErrorMessage = "Diastolic >= 10 && <= 300")]
        public int? Diastolic { get; set; }

        [Required(ErrorMessage = "!Date")]
        // [Range(typeof(DateTime), "09/01/2024", "09/30/2024", ErrorMessage = "Date != 09/??/2024")]
        public DateTime? Date { get; set; }

        public string Category
        {
            get
            {
                if (Systolic < 120 && Diastolic < 80)
                {
                    return "Normal";
                }
                else if (Systolic >= 120 && Systolic <= 129 && Diastolic < 80)
                {
                    return "Elevated";
                }
                else if ((Systolic >= 130 && Systolic <= 139) || (Diastolic >= 80 && Diastolic <= 89))
                {
                    return "Hypertension Stage Ⅰ";
                }
                else if (Systolic >= 140 || Diastolic >= 90)
                {
                    return "Hypertension Stage Ⅱ";
                }
                else if (Systolic > 180 || Diastolic > 120)
                {
                    return "Hypertensive Crisis";
                }
                else
                {
                    return "IDK";
                }
            }
        }
    }
}
