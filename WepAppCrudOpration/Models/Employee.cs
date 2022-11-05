using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WepAppCrudOpration.Models
{
    [Table(name:"Employes",Schema ="Hr")]
    public class Employee
    {
        [Key]
        [Display(Name ="Id")]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name="Name")]
        [Column(TypeName ="varchar(200)")]
        public string EmployeeName { get; set; }=String.Empty;

        [Display(Name ="Image User"),Column(TypeName ="varchar(250)")]
        public string? ImageUser { get; set; }

        [Display(Name ="BirthDate"),Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name ="Salary"),Column(TypeName ="decimal(12,2)"),Required]
        public decimal Salary { get; set; }
        
        [Required,Display(Name ="Hiring Date"),DataType(DataType.Date),DisplayFormat(DataFormatString ="{0:dd-MMMM-yyyy}")]
        public DateTime HiringDate { get; set; }

        [Required,Display(Name ="National Id"),MaxLength(14),MinLength(14),Column(TypeName ="varchar(14)")]
        public string NationalId { get; set; }=string.Empty;

        [Display(Name = "DepartmentId")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
    }
}
