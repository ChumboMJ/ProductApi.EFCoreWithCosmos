namespace ProductApi.EFCoreWithCosmos
{
    public class ProductApiOptions
    {
        public const string ProductApi = "ProductApi";
        public string AllowedHosts { get; set; }
        public CosmosDbOptions CosmosDb { get; set; }

        public class CosmosDbOptions
        {
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }
    }
}
