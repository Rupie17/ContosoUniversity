using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        // Previously the Column attribute was used to change column name mapping. In the code for the Department entity, the Column attribute is used to change SQL data type mapping. The Budget column is defined using the SQL Server money type (for currency) in the database.

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        public int? InstructorID { get; set; }

        [Timestamp]
        public byte[] ConcurrencyToken { get; set; }
        //public Guid ConcurrencyToken { get; set; } = Guid.NewGuid();

        public Instructor Administrator { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
