using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lec5.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int Age { get; set; }

        [ForeignKey("Department")]
        public int Dept_Id { get; set; }

        public Department? Department { get; set; }

        public List<StudentCourses>? StudentCourses { get; set; }
    }
}
