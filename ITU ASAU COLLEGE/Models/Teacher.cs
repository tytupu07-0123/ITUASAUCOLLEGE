namespace ITU_ASAU_COLLEGE.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ClassCode { get; set; }

        public ICollection<Notice>? Notice { get; set; }
        public string? Email { get; internal set; }
    }
}
