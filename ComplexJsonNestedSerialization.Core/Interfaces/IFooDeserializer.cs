namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IFooDeserializer<out TFoo, TBar, TBaz>
        where TFoo : IFoo<TBar, TBaz>
        where TBar : IBar<TBar, TBaz>
        where TBaz : IBaz<TBar>
    {
        TFoo Deserialize(string fooJson);
    }
}
