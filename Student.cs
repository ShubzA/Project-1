//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace demopopway.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.Exam__Score = new HashSet<Exam__Score>();
        }
    
        public int ID { get; set; }
        [Required(ErrorMessage ="Required")]
        public string Student_Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public int? Student_Age{ get; set; }
        [Required(ErrorMessage = "Required")]
        public int?  Contact_Number { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Address { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exam__Score> Exam__Score { get; set; }
    }
}
