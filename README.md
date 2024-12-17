This is an Example Project to demonstrate the usage of the following technologies:
  - Entity Framework Core
  - Cosmos DB
  - Graph QL (via HotChocolate)
  - RESTful Api

Configuration
1. Pull down the latest version of main
2. If you are NOT using KeyVault, edit your appsettings.json with the following entries:
      - Make sure that you have a ProductApi section within your appsettings.json
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
	  - Your ProductApi section should look something like this<br>
	  ```json
		{
		  "ProductApi": {
            "AllowedHosts": "*",
            "CosmosDb": {
              "ConnectionString": "AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
              "DatabaseName" : "SampleInventory"
            }                
		  }
		}
	  ```              
3. If you are connecting to Azure KeyVault, you will need the following entries in your appsettings.json:
    ```json
	{
	  "KeyVault": {
        "Name": "YOUR_KEY_VAULT_NAME",
		"AzureAd": {
          "DirectoryId": "YOUR_DIRECTORY_ID",
          "ApplicationId": "YOUR_APPLICATION_ID",
          "ClientId": "YOUR_CLIENT_ID",
          "ClientSecret": "YOUR_CLIENT_SECRET",
          "CertificateThumbprint": "YOUR_REGISTERED_X509_CERT_THUMBPRINT"
        }
      }
    }
    ```
   NOTE: KeyValut is not required for this project, but it is a good practice to use it for storing sensitive information.
   TIP: "KeyVault" should be at the same level with "ProductApi" in your appsettings.json, not within it
   TIP #2: Make sure your KeyVault settings reflect the proper pattern. For example, ConnectionsString should be stored under
           "ProductApi:CosmosDb:ConnectionString" in KeyVault

