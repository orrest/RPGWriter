using Microsoft.Extensions.DependencyInjection;
using RPGWriter.ViewModels;

namespace RPGWriter.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDependencies(this ServiceCollection collection)
        {
            AddCommonServices(collection);
            AddViewModels(collection);
        }

        private static void AddCommonServices(this IServiceCollection collection)
        {
            //collection.AddSingleton<IRepository, Repository>();
            //collection.AddTransient<BusinessService>();
        }

        private static void AddViewModels(this IServiceCollection collection)
        {
            collection.AddTransient<MainViewModel>();
        }
    }
}
