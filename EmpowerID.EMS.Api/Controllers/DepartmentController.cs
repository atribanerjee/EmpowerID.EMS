using EmpowerID.EMS.Api.Interfaces;
using EmpowerID.EMS.ApplicationCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmpowerID.EMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IEmployeeService _IEmployeeService;

        public DepartmentController(IEmployeeService iEmployeeService)
        {
            _IEmployeeService = iEmployeeService;
        }

        [HttpGet]
        [Route("GetAllDepartments")]
        public List<DepartmentViewModel> GetAllDepartments()
        {
            return _IEmployeeService.GetAllDepartments();
        }
    }
}
