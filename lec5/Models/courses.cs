namespace lec5.Models
{
    public class courses
    {
        public int Cour_Id { get; set; }
        public string Cour_name { get; set; }
        public int Cour_Hours { get; set; }

        public List<Department> Departments { get; set; }

        public List<StudentCourses> StudentCourses { get; set; }
    }
}
