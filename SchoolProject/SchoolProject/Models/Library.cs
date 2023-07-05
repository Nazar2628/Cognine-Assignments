using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class Library
    {
        [Key]
        public int BookId { get; set; }
        public int StudentId { get; set; }
        public string BookName { get; set; }
        [ForeignKey("StudentId")]
        public string Status { get;set; }
        public Student Student { get; set; }
    }
}
