using EmpowerID.EMS.ApplicationCore.ViewModels;
using EmpowerID.EMS.Web.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpowerID.EMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _IEmployeeService;

        public EmployeeController(IEmployeeService iEmployeeService)
        {
            _IEmployeeService = iEmployeeService;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public List<EmployeeViewModel> GetAllEmployees()
        {
            return _IEmployeeService.GetAllEmployees();
        }

        [HttpGet]
        [Route("SearchEmployees")]
        public List<EmployeeViewModel> SearchEmployees(String Search)
        {
            return _IEmployeeService.GetAllEmployees(Search);
        }

        [HttpGet]
        [Route("GetEmployee")]
        public EmployeeViewModel GetEmployee(String ID)
        {
            return _IEmployeeService.GetEmployee(ID);
        }

        [HttpPost]
        [Route("AddEmployee")]
        public String AddEmployee(EmployeeViewModel _EmployeeViewModel)
        {
            return _IEmployeeService.Add(_EmployeeViewModel);
        }

        [HttpPost]
        [Route("EditEmployee")]
        public String EditEmployee(EmployeeViewModel _EmployeeViewModel)
        {
            return _IEmployeeService.Update(_EmployeeViewModel);
        }

        [HttpPost]
        [Route("DeleteEmployee")]
        public String DeleteEmployee(String ID)
        {
            return _IEmployeeService.Delete(ID);
        }
    }
}
