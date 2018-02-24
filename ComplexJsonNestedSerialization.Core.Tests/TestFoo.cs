using ComplexJsonNestedSerialization.Core.Enums;
using ComplexJsonNestedSerialization.Core.Interfaces;
using ComplexJsonNestedSerialization.Core.Models;
using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Tests
{
    public static class TestFoo
    {
        /// <summary>
        /// Returns a default <see cref="IFoo"/> hydrated object, 
        /// containing 2 Bars, and 2 Bazes per Bar (4 Bazes total).
        /// </summary>
        /// <returns></returns>
        public static IFoo<Bar, Baz> GetDefaultFoo()
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
                                AndYetAnotherProperty = 0,
                                AnotherProperty = "0",
                                MyProperty = "rakataka",
                                TestEnumDeSerializedAsDescriptionOrName = TestEnum.Lmao
                            },
                            new Baz()
                            {
                                Id = 1,
                                AndYetAnotherProperty = 1,
                                AnotherProperty = "1",
                                MyProperty = "1"
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
                                Id = 2,
                                AndYetAnotherProperty = 2,
                                AnotherProperty = "2",
                                MyProperty = "2"
                            },
                            new Baz()
                            {
                                Id = 3,
                                AndYetAnotherProperty = 3,
                                AnotherProperty = "3",
                                MyProperty = "3"
                            }
                        }
                    }
                }
            };
        }
    }
}
