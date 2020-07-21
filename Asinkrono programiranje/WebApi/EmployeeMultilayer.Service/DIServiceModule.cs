
using Autofac;
using EmployeeMultilayer.Service.Common;
using EmployeeMultilayerService;

namespace EmployeeMultilayer.Service
{
    public class DIServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();

        }
    }
}
