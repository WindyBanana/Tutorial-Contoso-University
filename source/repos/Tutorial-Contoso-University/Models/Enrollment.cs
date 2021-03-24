using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Tutorial_Contoso_University.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    /*
     There's a many-to-many relationship between the Student and Course entities. 
     The Enrollment entity functions as a many-to-many join table with payload in the database. "
     With payload" means that the Enrollment table contains additional data besides FKs for the joined tables (in this case, the PK and Grade).
     */

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        //The CourseID property is a foreign key, and the corresponding navigation property is Course. An Enrollment entity is associated with one and only one Course entity.
        public int CourseID { get; set; }

        // An enrollment record is for one and only one student, so there's a StudentID FK property and a Student navigation property:
        public int StudentID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}