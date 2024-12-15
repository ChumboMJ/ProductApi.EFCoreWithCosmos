using GraphQL.Types;

namespace ProductApi.EFCoreWithCosmos.Models
{
    public class Supplier
    {
        public Guid SupplierId { get; set; }
        public Guid ProductId { get; set; }
        public required string Name { get; set; }
        public required string ContactEmail { get; set; }
    }

    public class SupplierType : ObjectGraphType<Supplier>
    {
        public SupplierType()
        {
            Field(x => x.SupplierId).Description("Supplier Id");
            Field(x => x.ProductId).Description("Product Id");
            Field(x => x.Name).Description("Supplier Name");
            Field(x => x.ContactEmail).Description("Supplier Contact Email");
        }
    }
}
