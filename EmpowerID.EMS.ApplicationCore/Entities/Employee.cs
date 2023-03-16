using EmpowerID.EMS.ApplicationCore.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpowerID.EMS.ApplicationCore.Entities
{
    public partial class Employee:BaseEntity, IAggregateRoot
    {

        [Key]
        public System.Guid ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        [ForeignKey("DepartmentID")]
        public System.Guid DepartmentID { get; set; }
        public virtual Department Department { get; set; }
    }
}
