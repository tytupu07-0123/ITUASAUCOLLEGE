using ITU_ASAU_COLLEGE.Controllers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITU_ASAU_COLLEGE.Models
{
    public class Notice
    {  

        public int NoticeId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        //Data Annotations to not allow more than 100 characters in the description
        [StringLength(100)]
        [DisplayName("Notice Title")]
        public required string NoticesTitle { get; set; }

        [Required]
        //Datat Annotations to not allow more than 1000 characters in the description
        [StringLength(1000)]
        [DisplayName("Notice Description")]
        public required string NoticeDescription { get; set; }
        
        public string? PostedBy { get; set; } = "Admin";
    }
}
