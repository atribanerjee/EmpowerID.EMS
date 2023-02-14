using EmpowerID.EMS.ApplicationCore.Interfaces;
using EmpowerID.EMS.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpowerID.EMS.Infrastructure.Data
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EMSContext _dbContext;
        public DepartmentRepository(EMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<DepartmentViewModel> GetAll()
        {
            try
            {
                return (from d in _dbContext.Departments
                        select new DepartmentViewModel
                        {
                            ID = d.ID,
                            Name = d.Name
                        }).ToList();
            }
            catch (Exception _Exception)
            {


            }
            return new List<DepartmentViewModel>();
        }
    }
}
