using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [ForeignKey("GradeId")]
        public int GradeId { get; set; }
        
        public int Fees { get; set; }

        public string Transport { get; set; }

        public Marks Marks { get; set; }
        public  Grade Grade { get; set; }
        public ICollection<Library> Libraries { get; set;}
    }
}
