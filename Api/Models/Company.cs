namespace JsonplaceholderTypicodeTests.Api.Models
{
    public class Company
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Company);
        }

        public bool Equals(Company other)
        {
            return other != null &&
                   Name == other.Name &&
                   CatchPhrase == other.CatchPhrase &&
                   Bs == other.Bs;
        }
    }
}
