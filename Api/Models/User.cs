using System.Collections.Generic;

namespace JsonplaceholderTypicodeTests.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Company Company { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as User);
        }

        public bool Equals(User other)
        {
            return other != null &&
                   Id == other.Id &&
                   Name == other.Name &&
                   Username == other.Username &&
                   Email == other.Email &&
                   EqualityComparer<Address>.Default.Equals(Address, other.Address) &&
                   Phone == other.Phone &&
                   Website == other.Website &&
                   EqualityComparer<Company>.Default.Equals(Company, other.Company);
        }
    }
}
