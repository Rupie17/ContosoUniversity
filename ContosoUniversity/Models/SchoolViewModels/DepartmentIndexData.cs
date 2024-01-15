
namespace ContosoUniversity.Models.SchoolViewModels
{
    public class DepartmentIndexData
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Course> Courses { get; set; }

        public IEnumerable<Enrollment> Enrollments { get; set; }

    }
}
