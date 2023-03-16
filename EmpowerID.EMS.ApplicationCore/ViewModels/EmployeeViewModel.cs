namespace EmpowerID.EMS.ApplicationCore.ViewModels
{
    public class EmployeeViewModel
    {
        public System.Guid ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public System.Guid DepartmentID { get; set; }
        public String DepartmentName { get; set; }
    }
}
