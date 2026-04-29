namespace ITU_ASAU_COLLEGE.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public required string TeacherName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ClassCode { get; set; }

        public ICollection<Notice>? Notice { get; set; }

    }
}
