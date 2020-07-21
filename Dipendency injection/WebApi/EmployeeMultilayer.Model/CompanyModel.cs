using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeMultilayer.Model.Common;


namespace EmployeeMultilayerModel
{
    public class CompanyModel :ICompanyModel
    {
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
