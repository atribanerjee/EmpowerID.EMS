using EmpowerID.EMS.ApplicationCore.ViewModels;

namespace EmpowerID.EMS.Api.Interfaces
{
    public interface IEmployeeService
    {
        Int32 Add(EmployeeViewModel _EmployeeViewModel);
        Int32 Update(EmployeeViewModel _EmployeeViewModel);
        Int32 Delete(Int32 ID);
        List<EmployeeViewModel> GetAllEmployees(String Search="");
        EmployeeViewModel GetEmployee(Int32 id);
        List<DepartmentViewModel> GetAllDepartments();
    }
}
