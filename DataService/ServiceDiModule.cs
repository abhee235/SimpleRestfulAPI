using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DataProvider;

namespace DataService
{
    public class ServiceDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<DataRepository>().As<IDataRepository>();
        }
    }
}
