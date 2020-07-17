using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMultilayer.Model.Common
{
    public interface IDepartmentModel
    {
        Guid DepartmentId { get; set; }
        string DepartmentName { get; set; }
        Guid CompanyId { get; set; }
    }
}
