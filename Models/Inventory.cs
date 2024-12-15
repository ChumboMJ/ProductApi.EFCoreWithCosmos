using GraphQL.Types;

namespace ProductApi.EFCoreWithCosmos.Models
{
    public class Inventory
    {
        public Guid InventoryId { get; set; }
        public Guid ProductId { get; set; }
        public int StockQuantity { get; set; }
        public DateTime LastRestocked { get; set; }
    }

    //For GraphQL
    public class InventoryType : ObjectGraphType<Inventory>
    {
        public InventoryType()
        {
            Field(x => x.InventoryId).Description("Inventory Id");
            Field(x => x.ProductId).Description("Product Id");
            Field(x => x.StockQuantity).Description("Stock Quantity");
            Field(x => x.LastRestocked).Description("Last Restocked");
        }
    }
}
