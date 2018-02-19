namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IDeserializer
    {
        IFoo Deserialize(string fooJson);
    }
}
