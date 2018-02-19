using ComplexJsonNestedSerialization.Core.Interfaces;

namespace ComplexJsonNestedSerialization.Core.Models
{
    public class Baz : IBaz
    {
        public int Id { get; set; }
        public string MyProperty { get; set; }
        public string AnotherProperty { get; set; }
        public int AndYetAnotherProperty { get; set; }
    }
}