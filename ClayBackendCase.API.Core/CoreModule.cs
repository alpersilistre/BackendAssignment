using Autofac;
using ClayBackendCase.API.Core.Interfaces.UseCases;
using ClayBackendCase.API.Core.UseCases;

namespace ClayBackendCase.API.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterUseCase>().As<IRegisterUserUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<LoginUseCase>().As<ILoginUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GetUsersUseCase>().As<IGetUsersUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GetLocksUseCase>().As<IGetLocksUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<LockingUseCase>().As<ILockingUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<CreateLockUseCase>().As<ICreateLockUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GetEventsUseCase>().As<IGetEventsUseCase>().InstancePerLifetimeScope();
        }
    }
}
