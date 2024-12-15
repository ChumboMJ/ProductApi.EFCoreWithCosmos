using GraphQL.Types;

namespace ProductApi.EFCoreWithCosmos.Models
{
    public class ShippingOption
    {
        public required string Method { get; set; }
        public decimal Cost { get; set; }
    }

    public class ShippingOptionsType : ObjectGraphType<ShippingOption>
    {
        public ShippingOptionsType()
        {
            Field(x => x.Method).Description("Shipping Method");
            Field(x => x.Cost).Description("Shipping Cost");
        }
    }
}
