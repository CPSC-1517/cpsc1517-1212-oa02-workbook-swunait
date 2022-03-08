using Microsoft.Extensions.DependencyInjection; // for IServiceCollection
using Microsoft.EntityFrameworkCore;    // for DbContextOptionsBuilders

namespace WestwindSystem
{
    public static class BackendExtensions
    {
        public static void WestwindBackendDependencies(
            this IServiceCollection services, 
            Action<DbContextOptionsBuilder> options)
        {

        }
    }

}
