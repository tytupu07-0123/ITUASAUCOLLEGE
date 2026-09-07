using System.ComponentModel.DataAnnotations;

namespace ITU_ASAU_COLLEGE.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }

        [Required]
        public int StudentId { get; set; }

        public Student? Student { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public bool IsPresent { get; set; }

        public string? Subject { get; set; }

        public string? ClassName { get; set; }
    }
}
