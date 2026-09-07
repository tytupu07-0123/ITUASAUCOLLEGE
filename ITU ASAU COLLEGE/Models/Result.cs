using System.ComponentModel.DataAnnotations;

namespace ITU_ASAU_COLLEGE.Models
{
    public class Result
    {
        public int ResultId { get; set; }

        [Required]
        public int StudentId { get; set; }

        public Student? Student { get; set; }

        [Required]
        public string Subject { get; set; } = "";

        public decimal Mark { get; set; }

        public string? Grade { get; set; }

        public string? AssessmentType { get; set; }

        public DateTime Date { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}