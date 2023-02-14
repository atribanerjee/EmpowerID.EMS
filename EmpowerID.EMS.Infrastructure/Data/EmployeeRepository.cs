﻿using EmpowerID.EMS.ApplicationCore.Entities;
using EmpowerID.EMS.ApplicationCore.Interfaces;
using EmpowerID.EMS.ApplicationCore.ViewModels;

namespace EmpowerID.EMS.Infrastructure.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EMSContext _dbContext;
        public EmployeeRepository(EMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<EmployeeViewModel> GetAll()
        {
            try
            {
                return (from e in _dbContext.Employees
                        select new EmployeeViewModel
                        {
                            ID = e.ID,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Email = e.Email,
                            Phone = e.Phone,
                            DepartmentID = e.DepartmentID,
                            DepartmentName = (from d in _dbContext.Departments where d.ID == e.DepartmentID select d.Name).FirstOrDefault() ?? String.Empty
                        }).ToList();
            }
            catch (Exception _Exception)
            {


            }
            return new List<EmployeeViewModel>();
        }

        public EmployeeViewModel Get(Int32 ID)
        {
            try
            {
                return (from e in _dbContext.Employees
                        where e.ID == ID
                        select new EmployeeViewModel
                        {
                            ID = e.ID,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Email = e.Email,
                            Phone = e.Phone,
                            DepartmentID = e.DepartmentID,
                            DepartmentName = (from d in _dbContext.Departments where d.ID == e.DepartmentID select d.Name).FirstOrDefault() ?? String.Empty
                        }).FirstOrDefault();
            }
            catch (Exception _Exception)
            {


            }
            return new EmployeeViewModel();
        }
        public Int32 Add(EmployeeViewModel _EmployeeViewModel)
        {
            try
            {
                var employee = new Employee();
                employee.FirstName = _EmployeeViewModel.FirstName;
                employee.LastName = _EmployeeViewModel.LastName;
                employee.Email = _EmployeeViewModel.Email;
                employee.Phone = _EmployeeViewModel.Phone;
                employee.DepartmentID = _EmployeeViewModel.DepartmentID;

                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
                return employee.ID;
            }
            catch (Exception _Exception)
            {
                return _EmployeeViewModel.ID;
            }
        }
        public Int32 Update(EmployeeViewModel _EmployeeViewModel)
        {
            try
            {
                var EmployeeData = (from e in _dbContext.Employees
                                    where e.ID == _EmployeeViewModel.ID
                                    select e).FirstOrDefault();

                if (EmployeeData != null && EmployeeData.ID > 0)
                {
                    EmployeeData.FirstName = _EmployeeViewModel.FirstName;
                    EmployeeData.LastName = _EmployeeViewModel.LastName;
                    EmployeeData.Email = _EmployeeViewModel.Email;
                    EmployeeData.Phone = _EmployeeViewModel.Phone;
                    EmployeeData.DepartmentID = _EmployeeViewModel.DepartmentID;

                    _dbContext.Employees.Update(EmployeeData);
                    _dbContext.SaveChanges();

                }
            }
            catch (Exception _Exception)
            {

            }
            return _EmployeeViewModel.ID;
        }
        public Int32 Delete(EmployeeViewModel _EmployeeViewModel)
        {
            try
            {
                var EmployeeData = (from e in _dbContext.Employees
                                    where e.ID == _EmployeeViewModel.ID
                                    select e).FirstOrDefault();

                if (EmployeeData != null && EmployeeData.ID > 0)
                {
                    _dbContext.Remove(EmployeeData);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception _Exception)
            {

            }
            return _EmployeeViewModel.ID;
        }

    }
}
