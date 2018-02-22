using System;
using System.Collections.Generic;
using System.Text;

namespace ComplexJsonNestedSerialization.Core.Enums
{
    public enum Projection
    {
        /// <summary>
        /// using this none-y boi to utilize no custom converters for testing purposes.
        /// </summary>
        None,
        /// <summary>
        /// Server projection - generally includes everything
        /// </summary>
        Server,
        /// <summary>
        /// Client projection - stuff we send to the client, probably excludes some things.
        /// </summary>
        Client
    }
}
