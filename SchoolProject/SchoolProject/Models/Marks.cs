using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class Marks
    {
        [Key]
        public int MarkId { get; set; }
        [ForeignKey("StudentId")]
        public int studentId { get; set; }
        public int Telugu { get; set; }
        public int Hindi { get; set; }
        public int English { get; set; }
        public int Maths { get; set; }
        public int Science { get; set; }
        public int SocialStudies { get; set; }
        public int TotalMarks { get;set; }

        public Student Student { get; set; }

    }
}
