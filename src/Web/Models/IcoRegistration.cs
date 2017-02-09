
using System;
using Domains;

namespace Web.Models
{
    public class IcoRegistrationModel : ILykkeIcoRegistration
    {
        public DateTime Registered => DateTime.UtcNow;
        public string Amount { get; set; }
        public string Wallet { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Ip { get; set; }
        public string Currency { get; set; }
    }
}
