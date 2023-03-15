using EmpowerID.EMS.ApplicationCore.ViewModels;

namespace EmpowerID.EMS.Api.Interfaces
{
    public interface IEmployeeService
    {
        String Add(EmployeeViewModel _EmployeeViewModel);
        String Update(EmployeeViewModel _EmployeeViewModel);
        String Delete(String ID);
        List<EmployeeViewModel> GetAllEmployees(String Search="");
        EmployeeViewModel GetEmployee(String id);
        List<DepartmentViewModel> GetAllDepartments();
    }
}
