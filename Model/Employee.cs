using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assesment.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(30)]
        public string?  EmployeeName { get; set; }
        [Required]
        [DataType("decimal(10,2)")]

        public  decimal Salary  { get; set; }

       
        public  int DepartmentId { get; set; }
        /*public  Department? Departments { get; set; }*/
        public bool  Isactive { get; set; }
    }
}
