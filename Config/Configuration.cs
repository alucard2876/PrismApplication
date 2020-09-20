using DomainAccess;
using DomainAccess.Implementation;
using DomainAccess.Interfaces;
using Microsoft.Practices.Unity;


namespace Config
{
    public static class Configuration
    {
        private static IUnityContainer Container = new UnityContainer();
        public static void Configure()
        { 
            Container.RegisterType<IProductRepository, ProductRepository>();
            Container.RegisterType<ICategoryRepository, CategoryRepository>();
            
        }

        public static T Resolve<T>(string key)
        => Container.Resolve<T>(key);

        public static T Resolve<T>()
            => Container.Resolve<T>();
    }

}
