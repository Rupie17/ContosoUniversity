using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoUniversity.Models.SchoolViewModels;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;
using Humanizer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace ContosoUniversity.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public IndexModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public DepartmentIndexData DepartmentData { get; set; }
        public int DepartmentID { get; set; }
        public int CourseID { get; set; }
        public IList<Department> Department { get;set; } = default!;

        public async Task OnGetAsync(int? id, int? courseID)
        {
            //Eager loading for the nav properties Courses
            DepartmentData = new DepartmentIndexData();
            DepartmentData.Departments = await _context.Departments
                .Include(i => i.Courses)
                .OrderBy(i => i.Name)
                .ToListAsync();

            /* The selected department is retrieved from the list of departments in the view model. The view model's Courses property is loaded with the Course entities from the selected instructor's Courses navigation property.

            The Where method returns a collection. In this case, the filter select a single entity, so the Single method is called to convert the collection into a single Department entity. The Department entity provides access to the Course navigation property. */
            if (id !=null)
                {
                    DepartmentID = id.Value;
                Department department = (Department)DepartmentData.Departments
                    .Where(i => i.DepartmentID == id.Value).Single();
                DepartmentData.Courses = department.Courses;
            }

            //The following code populates the view model's Enrollments property when a course is selected
            if (courseID != null)
            {
                CourseID = courseID.Value;
                IEnumerable<Enrollment> Enrollments = await _context.Enrollments
                    .Where(x => x.CourseID == CourseID)
                    .Include(i => i.Student)
                    .ToListAsync();
                DepartmentData.Enrollments = Enrollments;
            }

            if (_context.Departments != null)
            {
                Department = await _context.Departments
                .Include(d => d.Administrator).ToListAsync();
            }
        }
    }
}
