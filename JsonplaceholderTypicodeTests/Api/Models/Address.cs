using System.Collections.Generic;

namespace JsonplaceholderTypicodeTests.Api.Models
{
    public class Address
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geo { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Address);
        }

        public bool Equals(Address other)
        {
            return other != null &&
                   Street == other.Street &&
                   Suite == other.Suite &&
                   City == other.City &&
                   Zipcode == other.Zipcode &&
                   EqualityComparer<Geo>.Default.Equals(Geo, other.Geo);
        }

    }
}
