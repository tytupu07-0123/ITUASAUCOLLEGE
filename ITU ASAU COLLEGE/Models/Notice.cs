using ITU_ASAU_COLLEGE.Controllers;
using System.ComponentModel.DataAnnotations;

namespace ITU_ASAU_COLLEGE.Models
{
    public class Notice
    {  

        public int NoticeId { get; set; }
        public DateTime Date { get; set; }

        [Required]
        //Data Annotations to not allow more than 100 characters in the description
        [StringLength(100)]
        public string NoticesTitle { get; set; }

        [Required]
        //Datat Annotations to not allow more than 1000 characters in the description
        [StringLength(1000)]
        public string NoticeDescription { get; set; }
        
        public Teacher Teacher { get; set; }
        public string? PostedBy { get; set; }
    }
}
