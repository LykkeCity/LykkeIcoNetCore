using AzureStorage.Tables;
using Common.Log;
using Domains;
using Microsoft.Extensions.DependencyInjection;

namespace AzureRepositories
{
    public static class AzureRepositoriesBinder
    {
        public static void UseAzureRepositories(this IServiceCollection serviceCollection, string connectionString, ILog log)
        {
            serviceCollection.AddSingleton<ILykkeIcoRegistrationsRepository>(
                new LykkeIcoRegistrationsRepository(
                    new AzureTableStorage<LykkeIcoRegistrationEntity>(connectionString, "IcoRegistrations", log)
                    )
            );
        }
    }
}
