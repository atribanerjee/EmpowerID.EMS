using EmpowerID.EMS.ApplicationCore.ViewModels;

namespace EmpowerID.EMS.Web.Interfaces
{
    public interface IEmployeeService
    {
        System.Guid Add(EmployeeViewModel _EmployeeViewModel);
        System.Guid Update(EmployeeViewModel _EmployeeViewModel);
        System.Guid Delete(System.Guid ID);
        List<EmployeeViewModel> GetAllEmployees(String Search = "");
        EmployeeViewModel GetEmployee(System.Guid id);
        List<DepartmentViewModel> GetAllDepartments();
    }
}
