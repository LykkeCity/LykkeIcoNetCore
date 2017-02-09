using System;
using System.Threading.Tasks;
using AzureStorage;
using Domains;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureRepositories
{
    public class LykkeIcoRegistrationEntity : TableEntity , ILykkeIcoRegistration
    {
        public static string GeneratePartitionKey()
        {
            return "2017";
        }

        public DateTime Registered { get; set; }
        public string Amount { get; set; }
        public string Wallet { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Currency { get; set; }

        public string Ip { get; set; }

        public static LykkeIcoRegistrationEntity Create(ILykkeIcoRegistration src)
        {
            return new LykkeIcoRegistrationEntity
            {
                PartitionKey = GeneratePartitionKey(),
                Registered = src.Registered,
                Amount = src.Amount,
                City = src.City,
                Country = src.Country,
                Email = src.Email,
                Ip = src.Ip,
                Name = src.Name,
                Street = src.Street,
                Wallet = src.Wallet,
                Currency = src.Currency
            };
        }

    }

    public class LykkeIcoRegistrationsRepository : ILykkeIcoRegistrationsRepository
    {
        private readonly INoSQLTableStorage<LykkeIcoRegistrationEntity> _tableStorage;

        public LykkeIcoRegistrationsRepository(INoSQLTableStorage<LykkeIcoRegistrationEntity> tableStorage)
        {
            _tableStorage = tableStorage;
        }

        public Task RegisterAsync(ILykkeIcoRegistration item)
        {
            var entity = LykkeIcoRegistrationEntity.Create(item);
            return _tableStorage.InsertAndGenerateRowKeyAsDateTimeAsync(entity, entity.Registered);
        }

    }
}
