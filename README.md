This is an Example Project to demonstrate the usage of the following technologies:<br>
	- Entity Framework Core<br>
    - Cosmos DB<br>
    - Graph QL (via HotChocolate)<br>
    - RESTful Api<br>

To run this locally:<br>
    1. Pull down the latest version of main<br>
    2. Edit your appsettings.json<br>
        - You will need to add an "AllowedHosts" value<br>
            ```{
                "AllowedHosts": "*"
            }```<br>
        - If you are using a local Cosmos Emulator<br>
            ```{
                "ConnectionStrings": {
                    "DefaultConnection": "AccountEndpoint=https://localhost:8081/;AccountKey=<YOUR_EMULATOR_ACCOUNT_KEY_HERE>"
                }
            }```<br>
        - Instructions for Azure Key Vault Configuration to come!


