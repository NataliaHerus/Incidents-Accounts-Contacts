using Data.Entities.ContactEntity;
using Data.Entities.IncidentEntity;
using System;
namespace Data.Entities.AccountEntity
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? IncidentName { get; set; }
        public Incident? Incident { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
