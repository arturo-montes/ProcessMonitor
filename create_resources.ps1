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
az storage account create --name $storageName --location $location --resource-group $resourceGroupName --sku Standard_LRS --allow-blob-public-access false 

# create azure function
az functionapp create --resource-group $resourceGroupName --consumption-plan-location $location --runtime dotnet-isolated --functions-version 4 --name $functionName --storage-account $storageName

# delete resource group including its resources
az group delete --name $resourceGroupName --yes --no-wait