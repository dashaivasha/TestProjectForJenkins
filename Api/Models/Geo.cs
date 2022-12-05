namespace JsonplaceholderTypicodeTests.Api.Models
{
    public class Geo
    {
        public string Lat { get; set; }
        public string Lng { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Geo);
        }

        public bool Equals(Geo other)
        {
            return other != null &&
                   Lat == other.Lat &&
                   Lng == other.Lng;
        }

    }
}
