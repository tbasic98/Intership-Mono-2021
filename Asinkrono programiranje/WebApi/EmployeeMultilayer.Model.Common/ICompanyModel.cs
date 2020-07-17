using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMultilayer.Model.Common
{
    public interface ICompanyModel
    {
        Guid CompanyId { get; set; }
        string CompanyName { get; set; }
    }
}
