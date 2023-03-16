using EmpowerID.EMS.ApplicationCore.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EmpowerID.EMS.ApplicationCore.Entities
{
    public partial class Department:BaseEntity, IAggregateRoot
    {
        [Key]
        public System.Guid ID { get; set; }
        public String Name { get; set; }
    }    
}
