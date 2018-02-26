using System;
using ComplexJsonNestedSerialization.Core.ContractResolvers;
using ComplexJsonNestedSerialization.Core.Enums;
using ComplexJsonNestedSerialization.Core.Interfaces;
using Newtonsoft.Json.Serialization;

namespace ComplexJsonNestedSerialization.Core.Factories
{
    public class ContractResolverFactory : IContractResolverFactory
    {
        public IContractResolver GetContractResolver(Projection projection)
        {
            switch (projection)
            {
                case Projection.None:
                    return new CamelCasePropertyNamesContractResolver();
                case Projection.Client:
                    return new ClientProjectionContractResolver();
                case Projection.Server:
                    return new ServerProjectionContractResolver();
                default:
                    throw new ArgumentException($"invalid {nameof(projection)} of {projection}");
            }
        }
    }
}
