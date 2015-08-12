using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_CDFIRST.Models
{
    public class Student
    {

        public int ID { get; set; }

        [Required]
        [StringLength(50,MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [StringLength(500,ErrorMessage ="First Name can not be more than 50.")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        [Display(Name="Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }


        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}