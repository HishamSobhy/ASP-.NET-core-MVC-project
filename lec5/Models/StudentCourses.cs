using System.ComponentModel.DataAnnotations.Schema;

namespace lec5.Models
{
    public class StudentCourses
    {
        [ForeignKey("student")]
        public int StudentId { get; set; }
        [ForeignKey("courses")]
        public int coursesId { get; set; }

        public int Degree { get; set; }

        public courses courses { get; set; }

        public Student student { get; set; }

    }
}
