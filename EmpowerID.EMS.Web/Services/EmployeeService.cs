using EmpowerID.EMS.ApplicationCore.Interfaces;
using EmpowerID.EMS.ApplicationCore.ViewModels;
using EmpowerID.EMS.Web.Interfaces;

namespace EmpowerID.EMS.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _IEmployeeRepository;
        private readonly IDepartmentRepository _IDepartmentRepository;
        public EmployeeService(IEmployeeRepository iEmployeeRepository, IDepartmentRepository iDepartmentRepository)
        {
            _IEmployeeRepository = iEmployeeRepository;
            _IDepartmentRepository = iDepartmentRepository;
        }

        public Int32 Add(EmployeeViewModel _EmployeeViewModel)
        {
            return _IEmployeeRepository.Add(_EmployeeViewModel);
        }

        public Int32 Update(EmployeeViewModel _EmployeeViewModel)
        {
            return _IEmployeeRepository.Update(_EmployeeViewModel);
        }

        public List<DepartmentViewModel> GetAllDepartments()
        {
            return _IDepartmentRepository.GetAll();
        }

        public List<EmployeeViewModel> GetAllEmployees(String Search = "")
        {
            return _IEmployeeRepository.GetAll(Search);
        }

        public EmployeeViewModel GetEmployee(Int32 id)
        {
            return _IEmployeeRepository.Get(id);
        }

        public Int32 Delete(Int32 ID)
        {
            return _IEmployeeRepository.Delete(ID);
        }
    }
}
