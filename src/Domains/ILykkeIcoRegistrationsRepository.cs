using System;
using System.Threading.Tasks;

namespace Domains
{

    public interface ILykkeIcoRegistration
    {
        DateTime Registered { get; }
        string Amount { get; }
        string Wallet { get; }
        string Name { get; }
        string Street { get; }
        string City { get; }
        string Country { get; }
        string Email { get; }
        string Ip { get; }
        string Currency { get; }
    }

    public interface ILykkeIcoRegistrationsRepository
    {
        Task RegisterAsync(ILykkeIcoRegistration item);
    }
}
