using ComplexJsonNestedSerialization.Core.Interfaces;
using ComplexJsonNestedSerialization.Core.Models;
using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Services
{
    public class FooProvider : IFooProvider<Bar, Baz>
    {
        public IFoo<Bar, Baz> GetFoo()
        {
            return new Foo()
            {
                Id = 0,
                Bars = new List<Bar>()
                {
                    new Bar()
                    {
                        Id = 0,
                        ShouldSerializeSomeBazProperty = true,
                        Bazes = new List<Baz>()
                        {
                            new Baz()
                            {
                                Id = 0,
                                AndYetAnotherProperty = 5,
                                AnotherProperty = "hey",
                                MyProperty = "Bwahh"
                            },
                            new Baz()
                            {
                                Id = 1,
                                AndYetAnotherProperty = 5,
                                AnotherProperty = "doot doot",
                                MyProperty = "rakataka"
                            }
                        }
                    },
                    new Bar()
                    {
                        Id = 1,
                        ShouldSerializeSomeBazProperty = false,
                        Bazes = new List<Baz>()
                        {
                            new Baz()
                            {
                                Id = 3,
                                AndYetAnotherProperty = 42,
                                AnotherProperty = "hey",
                                MyProperty = "law blog"
                            },
                            new Baz()
                            {
                                Id = 4,
                                AndYetAnotherProperty = 55,
                                AnotherProperty = "doot doot toot!",
                                MyProperty = "bob loblaw"
                            }
                        }
                    }
                }
            };
        }
    }
}
