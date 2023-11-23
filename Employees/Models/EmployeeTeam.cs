namespace Employees.Models
{
    public class EmployeeTeam
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int TeamId {  get; set; }
        public int RoleId { get; set; }
        public decimal Salary { get; set; }
        public DateTime? StartWorkAt { get; set; }
    }
}
