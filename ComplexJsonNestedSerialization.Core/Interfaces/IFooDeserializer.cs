namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IFooDeserializer<TFoo>
        where TFoo : IFoo
    {
        TFoo Deserialize(string fooJson);
    }
}
