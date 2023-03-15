using EmpowerID.EMS.ApplicationCore.ViewModels;
using EmpowerID.EMS.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EmpowerID.EMS.Web.Pages.Employee
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeService _IEmployeeService;

        public EditModel(IEmployeeService iEmployeeService)
        {
            _IEmployeeService = iEmployeeService;
        }

        #region :: PageControls
        public SelectList Departments { get; set; }

        [BindProperty]
        [Required]
        public String EmployeeID { get; set; }
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
        public String DepartmentID { get; set; }
        #endregion

        public void OnGet(String id)
        {
            this.Departments = new SelectList(_IEmployeeService.GetAllDepartments(), "ID", "Name");

            var EmployeData = _IEmployeeService.GetEmployee(id);

            if(EmployeData != null ) 
            {
                EmployeeID = EmployeData.ID;
                FirstName= EmployeData.FirstName;
                LastName= EmployeData.LastName;
                Email= EmployeData.Email;
                Phone= EmployeData.Phone;
                DepartmentID= EmployeData.DepartmentID;
            }
        }

        public IActionResult OnPostSaveEmployee()
        {
            if (ModelState.IsValid)
            {
                EmployeeViewModel _EmployeeViewModel = new EmployeeViewModel();
                _EmployeeViewModel.ID= EmployeeID;
                _EmployeeViewModel.FirstName = FirstName;
                _EmployeeViewModel.LastName = LastName;
                _EmployeeViewModel.Email = Email;
                _EmployeeViewModel.Phone = Phone;
                _EmployeeViewModel.DepartmentID = DepartmentID;


                _IEmployeeService.Update(_EmployeeViewModel);
                return RedirectToPage("/Index");
            }
            return this.Page();
        }
    }
}
