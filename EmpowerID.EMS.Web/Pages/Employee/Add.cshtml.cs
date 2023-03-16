using EmpowerID.EMS.ApplicationCore.ViewModels;
using EmpowerID.EMS.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace EmpowerID.EMS.Web.Pages.Employee
{
    public class AddModel : PageModel
    {
        private readonly IEmployeeService _IEmployeeService;

        public AddModel(IEmployeeService iEmployeeService)
        {
            _IEmployeeService = iEmployeeService;
        }


        #region :: PageControls
        public SelectList Departments { get; set; }


        [BindProperty]
        [Required]
        public String FirstName { get; set; }
        [BindProperty]
        [Required]
        public String LastName { get; set; }
        [BindProperty]
        [Required]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [BindProperty]
        [Required]
        public String Phone { get; set; }
        [BindProperty]
        [Required]
        public System.Guid DepartmentID { get; set; }
        #endregion


        public void OnGet()
        {
            this.Departments = new SelectList(_IEmployeeService.GetAllDepartments(), "ID", "Name");
        }

        public IActionResult OnPostSaveEmployee()
        {
            if(ModelState.IsValid)
            {
                EmployeeViewModel _EmployeeViewModel = new EmployeeViewModel();
                _EmployeeViewModel.FirstName = FirstName;
                _EmployeeViewModel.LastName = LastName;
                _EmployeeViewModel.Email= Email;
                _EmployeeViewModel.Phone = Phone;
                _EmployeeViewModel.DepartmentID = DepartmentID;


                _IEmployeeService.Add(_EmployeeViewModel);
                return RedirectToPage("/Index");
            }
            return this.Page();
        }
    }
}
