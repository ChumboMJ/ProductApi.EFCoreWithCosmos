using GraphQL.Types;

namespace ProductApi.EFCoreWithCosmos.Models
{
    public class Product(Guid productId)
    {
        [GraphQLDescription("Product Id")]
        [ID]
        public Guid ProductId { get; set; } = productId;
        [GraphQLDescription("Product Name")]
        public required string Name { get; set; }
        [GraphQLDescription("Product Category")]
        public required string Category { get; set; }
        public required Dimensions Dimensions { get; set; }
        public List<ShippingOption> ShippingOptions { get; set; } = [];
        public List<Supplier> Suppliers { get; set; } = [];
        public Inventory Inventory { get; set; } = new Inventory();
    }

    //For GraphQL
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(x => x.ProductId).Description("Product Id");
            Field(x => x.Name).Description("Product Name");
            Field(x => x.Category).Description("Product Category");
            Field(x => x.Dimensions, type: typeof(DimensionsType)).Description("Product Dimensions");
            Field(x => x.ShippingOptions).Description("Shipping Options");
            Field(x => x.Suppliers, type: typeof(ListGraphType<SupplierType>)).Description("Suppliers");
            Field(x => x.Inventory, type: typeof(InventoryType)).Description("Inventory");
        }
    }
}
