using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMultilayer.Model.Common
{
    public interface IEmpoyeModel
    {
        Guid EmployeeId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        Guid DepartmentId { get; set; }
    }
}
