using GraphQL.Types;

namespace ProductApi.EFCoreWithCosmos.Models
{
    public class Dimensions
    {
        public required string Height { get; set; }
        public required string Width { get; set; }
        public required string Depth { get; set; }
    }

    //For GraphQL
    public class DimensionsType : ObjectGraphType<Dimensions>
    {
        public DimensionsType()
        {
            Field(x => x.Height).Description("Item Height");
            Field(x => x.Width).Description("Item Width");
            Field(x => x.Depth).Description("Item Depth");
        }
    }
}
