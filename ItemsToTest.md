# DI AzureWebJobsStorage in an Azure Function

Using dependency injection: This is the preferred approach, as it is more decoupled and maintainable. To do this, you can create an interface for the Azure Storage account client, and then inject this interface into your function. For example:

public interface ITableClient
{
    // Methods for querying and updating the table
}

public class MyFunction : IFunctionName
{
    private readonly ITableClient _tableClient;

    public MyFunction(ITableClient tableClient)
    {
        _tableClient = tableClient;
    }

    public async Task Run(HttpRequestMessage req, HttpResponseMessage res, ILogger log)
    {
        // Query the table
        var table = await _tableClient.GetTableAsync("Table-1");

        // Get the results
        var results = await table.GetEntitiesAsync<MyEntity>();
    }
}


You can then register the Azure Storage account client with your dependency injection container. For example, if you are using ASP.NET Core, you can do this in the Startup class:


public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ITableClient, TableClient>(new TableClient(AzureWebJobsStorage, "Table-1"));
    }
}


Once the Azure Storage account client is registered with your dependency injection container, it will be injected into your function automatically when it is executed.


AzureWebJobsStorage is an environment variable. It is automatically set when you create an Azure Function App. The value of the AzureWebJobsStorage environment variable is the connection string to the Azure Storage account that is associated with your Azure Function App.

When you register the Azure Storage account client with your dependency injection container as a singleton, the dependency injection container will use the value of the AzureWebJobsStorage environment variable to create the client. This means that you do not need to explicitly specify the AzureWebJobsStorage connection string in your code.