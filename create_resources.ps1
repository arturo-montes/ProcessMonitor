#func init SunocoProcessMonitor --worker-runtime dotnet-isolated --target-framework net7.0


# dotnet new function --name ProcessMonitor.ProcessFunction --output ProcessMonitor --framework net7.0

# Variable for resource group name
$resourceGroupName="SunocoProcessMonitor-RG"
$location="Central US"
$storageName="processmonitors1"
$functionName="processmonitorf1"

# login into azure
az login

# create resource
az group create --name $resourceGroupName --location $location

# create storage
az storage account create --name $storageName --location $location --resource-group $resourceGroupName --sku Standard_LRS --allow-blob-public-access false --bypass AzureServices --default-action Allow --min-tls-version TLS1_2

# Display valid zone locations
az functionapp list-consumption-locations
# create azure function
az functionapp create --resource-group $resourceGroupName --consumption-plan-location centralus --runtime dotnet-isolated --functions-version 4 --name $functionName --storage-account $storageName

# delete resource group including its resources
az group delete --name $resourceGroupName --yes --no-wait

# Replace 'YourStorageAccountName' and 'YourResourceGroupName' with your actual Storage account name and resource group name.
az storage account show-usage --name "processmonitorstorage" --resource-group "ProcessMonitor_group" --location centralus --query "[?name=='Total'].{Total: currentValue}" --output table 

# Replace 'YourStorageAccountName' and 'YourResourceGroupName' with your actual Storage account name and resource group name.
az monitor metrics list --resource /subscriptions/73c0ac4d-0815-482e-94cd-d1ee6d022305/resourceGroups/ProcessMonitor_group/providers/Microsoft.Storage/storageAccounts/processmonitorstorage --metric "UsedCapacity" --output table
