using EmpowerID.EMS.ApplicationCore.Interfaces;
using EmpowerID.EMS.ApplicationCore.ViewModels;
using EmpowerID.EMS.Api.Interfaces;

namespace EmpowerID.EMS.Api.Services
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

        public System.Guid Add(EmployeeViewModel _EmployeeViewModel)
        {
            return _IEmployeeRepository.Add(_EmployeeViewModel);
        }

        public System.Guid Update(EmployeeViewModel _EmployeeViewModel)
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

        public EmployeeViewModel GetEmployee(System.Guid id)
        {
            return _IEmployeeRepository.Get(id);
        }

        public System.Guid Delete(System.Guid ID)
        {
            return _IEmployeeRepository.Delete(ID);
        }
    }
}
