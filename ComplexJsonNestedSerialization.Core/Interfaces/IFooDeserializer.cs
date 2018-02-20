namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IFooDeserializer<out TFoo>
        where TFoo : IFoo
    {
        TFoo Deserialize(string fooJson);
    }
}
