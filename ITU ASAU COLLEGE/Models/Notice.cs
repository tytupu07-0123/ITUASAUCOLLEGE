namespace ITU_ASAU_COLLEGE.Models
{
    public class Notice
    {
       

        public int NoticeId { get; set; }
        public DateTime Date { get; set; }
        public string? NoticesTitle { get; set; }
        //Data Annotations to not allow more than 100 characters in the description
        [System.ComponentModel.DataAnnotations.StringLength(100, ErrorMessage = "Description cannot be more than 100 characters.")]
        public string? NoticeDescription { get; set; }
        //Datat Annotations to not allow more than 1000 characters in the description
        [System.ComponentModel.DataAnnotations.StringLength(1000, ErrorMessage = "Description cannot be more than 1000 characters.")]
        public Teacher? Teacher { get; set; }
        public string? PostedBy { get; set; }
    }
}
