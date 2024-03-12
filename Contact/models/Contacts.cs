using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.models
{
    public class Contacts
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime LastModificationDate { get; set; }

        public Contacts() { }
        public Contacts(int id, string fullName, string phoneNumber, DateTime lastModificationDate)
        {
            Id = id;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            LastModificationDate = lastModificationDate;
        }
    }
}
