namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IFooDeserializer<out TFoo>
        where TFoo : IFoo<IBar<IBaz>>
    {
        TFoo Deserialize(string fooJson);
    }
}
