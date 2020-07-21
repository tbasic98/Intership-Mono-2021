
using Autofac;
using EmployeeMultilayer.Repository.Common;
using EmployeeMultilayerRepository;

namespace EmployeeMultilayer.Repository
{
    public class DIRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();

        }
    }
}
