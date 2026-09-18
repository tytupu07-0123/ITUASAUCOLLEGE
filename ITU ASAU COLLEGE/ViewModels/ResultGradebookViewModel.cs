using System.ComponentModel.DataAnnotations;

namespace ITU_ASAU_COLLEGE.ViewModels
{
    public class ResultGradebookViewModel
    {
        [Required]
        [Display(Name = "Class")]
        public string ClassName { get; set; } = "";

        [Required]
        public string Subject { get; set; } = "";

        [Required]
        [Display(Name = "Assessment Type")]
        public string AssessmentType { get; set; } = "";

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today;

        public List<ResultStudentViewModel> Students { get; set; }
            = new List<ResultStudentViewModel>();
    }
}
