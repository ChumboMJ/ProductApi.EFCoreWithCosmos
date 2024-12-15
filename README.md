This is an Example Project to demonstrate the usage of the following technologies:
  - Entity Framework Core
  - Cosmos DB
  - Graph QL (via HotChocolate)
  - RESTful Api

Configuration
1. Pull down the latest version of main
2. Edit your appsettings.json
      - You will need to add an "AllowedHosts" value, this is for CORS<br>
      ```json
          {
            "AllowedHosts": "*"
          }
      ```
      - If you are using a local Cosmos Emulator<br>
      ```json
        {
          "ConnectionStrings": {
            "DefaultConnection": "AccountEndpoint=https://localhost:8081/;AccountKey=<YOUR_EMULATOR_ACCOUNT_KEY_HERE>"
          }
        }
      ```
3. Instructions for Azure Key Vault Configuration to come!


