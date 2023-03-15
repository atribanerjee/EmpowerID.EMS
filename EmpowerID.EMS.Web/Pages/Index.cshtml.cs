using EmpowerID.EMS.ApplicationCore.Entities;
using EmpowerID.EMS.ApplicationCore.ViewModels;
using EmpowerID.EMS.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EmpowerID.EMS.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeService _IEmployeeService;

        public IndexModel(IEmployeeService iEmployeeService)
        {
            _IEmployeeService = iEmployeeService;
        }

        #region :: PageControls
        public List<EmployeeViewModel> Employees { get; set; }


        [BindProperty]        
        public String Search { get; set; }


        #endregion

        public void OnGet()
        {
            this.Employees= _IEmployeeService.GetAllEmployees();
        }

        public IActionResult OnPostSearchEmployee()
        {
            this.Employees = _IEmployeeService.GetAllEmployees(Search);
            return this.Page();
        }

        public IActionResult OnPostDeleteEmployee(String id)
        {
            _IEmployeeService.Delete(id);
            return RedirectToPage("/Index");            
        }
    }
}