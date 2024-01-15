using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public enum Grade
    {
        A,B,C,D,F

    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        // foreign keys
        public int CourseID { get; set; }
        public int StudentID { get; set; }


        [DisplayFormat(NullDisplayText = "No Grade")]
        public Grade? Grade { get; set; }

        // navigation properties
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}