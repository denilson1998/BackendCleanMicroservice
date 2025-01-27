using Ardalis.SharedKernel;
using Autofac;
using Coupons.Domain.Entities;
using Coupons.Domain.Persistence.Repositories;
using Coupons.Infrastructure.Repositories;
using Coupons.Infrastructure.Services.Authentication;
using Coupons.UseCases.Authentication.Login;
using Coupons.UseCases.Authorizers.Create;
using Coupons.UseCases.CouponConfigurations.Create;
using Coupons.UseCases.Coupons.Create;
using Coupons.UseCases.CouponTypes.Create;
using MediatR;
using MediatR.Pipeline;
using System.Reflection;
using Module = Autofac.Module;

namespace Coupons.Infrastructure
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
            //Assembly Entities
            var coreAssembly = Assembly.GetAssembly(typeof(Coupon));
            var authorizerAssembly = Assembly.GetAssembly(typeof(CouponAuthorizer));
            var couponTypeAssembly = Assembly.GetAssembly(typeof(CouponType));
            var couponConfigurationAssembly = Assembly.GetAssembly(typeof(CouponConfiguration));
            //////////////////////////////////
            var infrastructureAssembly = Assembly.GetAssembly(typeof(AutofacInfrastructureModule));

            //Assembly Commands
            var useCasesAssembly = Assembly.GetAssembly(typeof(CreateCouponCommand));
            var useCasesAuthorizer = Assembly.GetAssembly(typeof(CreateAuthorizerCommand));
            var useCasesCouponType = Assembly.GetAssembly(typeof(CreateCouponTypeCommand));
            var useCasesCouponConfiguration = Assembly.GetAssembly(typeof(CreateCouponConfigurationCommand));
            var useCasesLogin = Assembly.GetAssembly(typeof(LoginCommand));

            AddToAssembliesIfNotNull(coreAssembly);
            AddToAssembliesIfNotNull(authorizerAssembly);
            AddToAssembliesIfNotNull(couponTypeAssembly);
            AddToAssembliesIfNotNull(couponConfigurationAssembly);

            AddToAssembliesIfNotNull(infrastructureAssembly);

            AddToAssembliesIfNotNull(useCasesAssembly);
            AddToAssembliesIfNotNull(useCasesAuthorizer);
            AddToAssembliesIfNotNull(useCasesCouponType);
            AddToAssembliesIfNotNull(useCasesCouponConfiguration);
            AddToAssembliesIfNotNull(useCasesLogin);
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
            RegisterEF(builder);
            RegisterQueries(builder);
            RegisterMediatR(builder);
        }

        private void RegisterEF(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>))
              .As(typeof(IRepository<>))
              .As(typeof(IReadRepository<>))
              .InstancePerLifetimeScope();
        }

        private void RegisterQueries(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<JwtProvider>()
                .As<IJwtProvider>()
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