namespace ITU_ASAU_COLLEGE.Models
{
    public class Department
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string CourseId { get; set; }
        public required string HeadOfDepartment { get; set; }
        public int NumberOfTeachers { get; set; }
        public int NumberOfStudents { get; set; }

        public ICollection<Course>? Courses { get; set; }
        public ICollection<Teacher>? Teachers { get; set; }
        public ICollection<Student>? Students { get; set; }


    }
}
