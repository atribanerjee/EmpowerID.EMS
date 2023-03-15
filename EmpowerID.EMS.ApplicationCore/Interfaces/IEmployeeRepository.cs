using EmpowerID.EMS.ApplicationCore.ViewModels;

namespace EmpowerID.EMS.ApplicationCore.Interfaces
{
    public interface IEmployeeRepository
    {
        List<EmployeeViewModel> GetAll(String Search = "");
        EmployeeViewModel Get(String ID);
        String Add(EmployeeViewModel _EmployeeViewModel);
        String Update(EmployeeViewModel _EmployeeViewModel);
        String Delete(String ID);
    }
}
