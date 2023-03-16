using EmpowerID.EMS.ApplicationCore.ViewModels;

namespace EmpowerID.EMS.ApplicationCore.Interfaces
{
    public interface IEmployeeRepository
    {
        List<EmployeeViewModel> GetAll(String Search = "");
        EmployeeViewModel Get(System.Guid ID);
        System.Guid Add(EmployeeViewModel _EmployeeViewModel);
        System.Guid Update(EmployeeViewModel _EmployeeViewModel);
        System.Guid Delete(System.Guid ID);
    }
}
