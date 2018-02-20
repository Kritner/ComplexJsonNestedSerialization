namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IFooDeserializer<out TFoo, TBar, TBaz>
        where TFoo : IFoo<TBar, TBaz>
        where TBar : IBar<TBaz>
        where TBaz : IBaz
    {
        TFoo Deserialize(string fooJson);
    }
}
