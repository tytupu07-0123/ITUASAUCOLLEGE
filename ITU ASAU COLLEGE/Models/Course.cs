namespace ITU_ASAU_COLLEGE.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public required string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment>? Enrollment { get; set; }
    }
}
