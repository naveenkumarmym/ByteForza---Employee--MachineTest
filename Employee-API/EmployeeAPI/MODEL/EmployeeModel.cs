using System.ComponentModel.DataAnnotations;

namespace MODEL
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
