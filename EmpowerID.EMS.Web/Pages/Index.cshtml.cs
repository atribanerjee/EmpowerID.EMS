﻿using EmpowerID.EMS.ApplicationCore.Entities;
using EmpowerID.EMS.ApplicationCore.ViewModels;
using EmpowerID.EMS.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace EmpowerID.EMS.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeService _IEmployeeService;
        static HttpClient client = new HttpClient();

        public IndexModel(IEmployeeService iEmployeeService)
        {
            _IEmployeeService = iEmployeeService;
        }

        #region :: PageControls
        public List<EmployeeViewModel> Employees { get; set; }


        [BindProperty]        
        public String Search { get; set; }


        #endregion

        public async Task OnGetAsync()
        {
            //this.Employees= _IEmployeeService.GetAllEmployees();


            HttpResponseMessage response = await client.GetAsync("https://localhost:7178/api/Employee/GetAllEmployees");
            if (response.IsSuccessStatusCode)
            {
                this.Employees = await response.Content.ReadFromJsonAsync<List<EmployeeViewModel>>();
            }            
        }

        public IActionResult OnPostSearchEmployee()
        {
            this.Employees = _IEmployeeService.GetAllEmployees(Search);
            return this.Page();
        }

        public IActionResult OnPostDeleteEmployee(System.Guid id)
        {
            _IEmployeeService.Delete(id);
            return RedirectToPage("/Index");            
        }
    }
}