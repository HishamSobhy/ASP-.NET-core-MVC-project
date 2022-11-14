using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using lec5.Migrations;

namespace lec5.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Dept_Id { get; set; }

        [Required]
        public string Dept_Name { get; set; }

        public Department()
        {
            students = new HashSet<Student>();
        }
        public ICollection<Student> students { get; set; }

        public List<courses> coursess { get; set; }
    }
}
