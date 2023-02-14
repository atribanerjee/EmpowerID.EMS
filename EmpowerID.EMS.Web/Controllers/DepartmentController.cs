using EmpowerID.EMS.ApplicationCore.ViewModels;
using EmpowerID.EMS.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmpowerID.EMS.Web.Controllers
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
