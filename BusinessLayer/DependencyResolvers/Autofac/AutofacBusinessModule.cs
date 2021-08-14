using Autofac;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;

namespace BusinessLayer.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConverterManager>().As<IConverterService>();
        }
    }
}
