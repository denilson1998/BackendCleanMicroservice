using Ardalis.SharedKernel;
using Autofac;
using MediatR.Pipeline;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = Autofac.Module;
using Authentication.UseCases.Users.Create;
using Authentication.Infrastructure.Repositories;
using Authentication.Domain.Persistence.Repositories;
using Authentication.Domain.UserAggregate.Entities;

namespace Authentication.Infrastructure
{
    public class AutofacInfrastructureModule : Module
    {
        private readonly bool _isDevelopment = false;
        private readonly List<Assembly> _assemblies = new List<Assembly>();

        public AutofacInfrastructureModule(bool isDevelopment, Assembly? callingAssembly = null)
        {
            _isDevelopment = isDevelopment;
            AddToAssembliesIfNotNull(callingAssembly);
        }

        private void AddToAssembliesIfNotNull(Assembly? assembly)
        {
            if (assembly != null)
            {
                _assemblies.Add(assembly);
            }
        }

        private void LoadAssemblies()
        {
            // TODO: Replace these types with any type in the appropriate assembly/project
            var coreAssembly = Assembly.GetAssembly(typeof(User));
            var infrastructureAssembly = Assembly.GetAssembly(typeof(AutofacInfrastructureModule));
            var useCasesAssembly = Assembly.GetAssembly(typeof(CreateUserCommand));

            AddToAssembliesIfNotNull(coreAssembly);
            AddToAssembliesIfNotNull(infrastructureAssembly);
            AddToAssembliesIfNotNull(useCasesAssembly);
        }

        protected override void Load(ContainerBuilder builder)
        {
            LoadAssemblies();
            if (_isDevelopment)
            {
                RegisterDevelopmentOnlyDependencies(builder);
            }
            else
            {
                RegisterProductionOnlyDependencies(builder);
            }
            //RegisterEF(builder);
            RegisterQueries(builder);
            RegisterMediatR(builder);
        }

        //private void RegisterEF(ContainerBuilder builder)
        //{
        //    builder.RegisterGeneric(typeof(EfRepository<>))
        //      .As(typeof(IRepository<>))
        //      .As(typeof(IReadRepository<>))
        //      .InstancePerLifetimeScope();
        //}

        private void RegisterQueries(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>()
              .As<IUserRepository>()
              .InstancePerLifetimeScope();
        }

        private void RegisterMediatR(ContainerBuilder builder)
        {
            builder
              .RegisterType<Mediator>()
              .As<IMediator>()
              .InstancePerLifetimeScope();

            builder
              .RegisterGeneric(typeof(LoggingBehavior<,>))
              .As(typeof(IPipelineBehavior<,>))
              .InstancePerLifetimeScope();

            builder
              .RegisterType<MediatRDomainEventDispatcher>()
              .As<IDomainEventDispatcher>()
              .InstancePerLifetimeScope();

            var mediatrOpenTypes = new[]
            {
              typeof(IRequestHandler<,>),
              typeof(IRequestExceptionHandler<,,>),
              typeof(IRequestExceptionAction<,>),
              typeof(INotificationHandler<>),
            };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                  .RegisterAssemblyTypes(_assemblies.ToArray())
                  .AsClosedTypesOf(mediatrOpenType)
                  .AsImplementedInterfaces();
            }
        }

        private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
        {
            // NOTE: Add any development only services here
            //builder.RegisterType<FakeEmailSender>().As<IEmailSender>()
            //  .InstancePerLifetimeScope();

            //builder.RegisterType<FakeListContributorsQueryService>()
            //  .As<IListContributorsQueryService>()
            //  .InstancePerLifetimeScope();
        }

        private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
        {
            // NOTE: Add any production only (real) services here
            //builder.RegisterType<SmtpEmailSender>().As<IEmailSender>()
            //  .InstancePerLifetimeScope();
        }
    }
}
