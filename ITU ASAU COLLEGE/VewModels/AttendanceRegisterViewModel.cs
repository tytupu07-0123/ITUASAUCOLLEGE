using System.ComponentModel.DataAnnotations;

namespace ITU_ASAU_COLLEGE.VewModels
{
    public class AttendanceRegisterViewModel
    {
        [Required]
        [Dispaly(Name = "Class Name")]
        public string ClassName { get; set; }
        [Required]
        [Display(Name = "Subject")]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public List<AttendanceStudentViewModel> Students { get; set; } = new List<AttendanceStudentViewModel>();


    }
}
