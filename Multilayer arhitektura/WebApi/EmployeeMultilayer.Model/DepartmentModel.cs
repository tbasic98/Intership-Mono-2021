using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeMultilayer.Model.Common;

namespace EmployeeMultilayerModel
{
    public class DepartmentModel : IDepartmentModel
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Guid CompanyId { get; set; }
    }
}
