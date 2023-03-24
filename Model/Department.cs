using System.ComponentModel.DataAnnotations;

namespace Assesment.Model
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [MaxLength(30)]
        public string DepartmentName { get; set; }
        public bool Isactive { get; set; }


    }
}
