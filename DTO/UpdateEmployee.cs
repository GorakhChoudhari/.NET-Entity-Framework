namespace Assesment.DTO
{
    public class UpdateEmployee
    {
      public int EmpId { get; set; }

      public string EmpName { get; set; }
     public decimal Salary  { get; set;}

     public int DepartmentId { get; set; }

     public bool IsActive { get; set; }
    }
}
