using System;
using Newtonsoft.Json.Serialization;

namespace Checkout.Orders.Tests.Factory
{
    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return Char.ToLowerInvariant(propertyName[0]) + propertyName.Substring(1);

        }
    }
}