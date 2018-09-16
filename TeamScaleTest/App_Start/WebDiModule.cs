using Autofac;
using DataProvider;
using DataService;

namespace TeamScaleTest.App_Start
{
    public class WebDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<PersonRecordServices>().As<IPersonRecordServices>().InstancePerRequest();
            builder.RegisterType<DataRepository>().As<IDataRepository>().InstancePerRequest();
        }
    }
}