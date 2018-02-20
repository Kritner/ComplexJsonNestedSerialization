namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IFooSerializer<TBar, TBaz>
        where TBar : IBar<TBaz>
        where TBaz : IBaz
    {
        string Serialize(IFoo<TBar, TBaz> foo);
    }
}
