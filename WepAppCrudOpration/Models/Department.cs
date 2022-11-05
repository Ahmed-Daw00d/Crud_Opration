using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WepAppCrudOpration.Models
{
    [Table(name:"Departments",Schema ="Hr")]
    public class Department
    {
        [Key]
        [Display(Name ="Id")]
        public int DepartmentId { get; set; }

        [Required]
        [Display(Name="Department Name")]
        [Column(TypeName = "varchar(200)")]
        public string DepartmentName { get; set; }=String.Empty;
    }
}
