using EmpowerID.EMS.ApplicationCore.ViewModels;

namespace EmpowerID.EMS.ApplicationCore.Interfaces
{
    public interface IEmployeeRepository
    {
        List<EmployeeViewModel> GetAll(String Search = "");
        EmployeeViewModel Get(Int32 ID);
        Int32 Add(EmployeeViewModel _EmployeeViewModel);
        Int32 Update(EmployeeViewModel _EmployeeViewModel);
        Int32 Delete(Int32 ID);
    }
}
