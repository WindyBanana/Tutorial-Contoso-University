using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutorial_Contoso_University.Models
{
    public class Course
    {
        // allows the app to specify the primary key rather than having the database generate it.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0, 5)]
        public int Credits { get; set; }

        public int DepartmentID { get; set; }

        // The Department property is a navigation property. A Couse entity can only be related to one Departement entity.
        // A course is assigned to one department, so there's a DepartmentID FK and a Department navigation property.
        public Department Department { get; set; }
        // The Enrollments property is a navigation property. A Course entity can be related to any number of Enrollment entities.
        // A course can have any number of students enrolled in it, so the Enrollments navigation property is a collection:
        public ICollection<Enrollment> Enrollments { get; set; }
        // A course may be taught by multiple instructors, so the CourseAssignments navigation property is a collection:
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}