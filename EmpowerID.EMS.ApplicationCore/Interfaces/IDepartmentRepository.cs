using EmpowerID.EMS.ApplicationCore.ViewModels;

namespace EmpowerID.EMS.ApplicationCore.Interfaces
{
    public interface IDepartmentRepository
    {
        List<DepartmentViewModel> GetAll();
    }
}
