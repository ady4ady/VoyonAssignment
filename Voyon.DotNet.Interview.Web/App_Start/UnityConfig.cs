using Voyon.DotNet.Interview.Core.Database;
using Voyon.DotNet.Interview.Core.Repositories;
using Voyon.DotNet.Interview.Logic.BL;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
using Unity.Mvc5;

namespace Voyon.DotNet.Interview.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            
            container.RegisterType<IDbContext, DbContext>(new ContainerControlledLifetimeManager());

            container.RegisterType<ITaskRepository, TaskRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IRoleRepository, RoleRepository>(new ContainerControlledLifetimeManager());

            container.RegisterType<ITaskLogic, TaskLogic>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAuthorizationLogic, AuthorizationLogic>(new ContainerControlledLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}