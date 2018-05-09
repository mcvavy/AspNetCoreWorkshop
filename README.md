# What you'll learn
An hour-long META 2018 workshop about what's new and different in ASP.NET Core 2.0 compared to .NET Framework. It begins with a little background on .NET Core framework and CLI   

* setting up MVC
* create middleware
* configuration abstraction
* default logging framework
* dependency injection (default and 3rd party)
* API explorer
* test server

# Prerequisites
* .NET Core SDK (version 2.0 or higher) [[download](https://www.microsoft.com/net/download/)]
* Visual Studio or Visual Studio Code (latest public release)

# Why do you need this repository
This is not a coding from scratch exercise as it would take us far longer than an allocated hour to present what've prepared. We want to focus on the new things, so this solution has all the required Nuget packages pre-installed and some of the code is already pre-written

# Code snippets and Nuget packages

## Configuration

Register configuration actions for `BlogSettings`
```csharp
public void ConfigureServices(IServiceCollection services)
{
   services.Configure<BlogSettings>(_configuration.GetSection("BlogSettings"));
   services.Configure<BlogSettings>(settings => settings.BlogType = BlogType.Games);

   //...
}
```
## Logging

### Nuget package: [`NLog.Web.AspNetCore`](https://www.nuget.org/packages/NLog.Web.AspNetCore/)

## AutoFac dependency injection

### Nuget package: [`Autofac.Extensions.DependencyInjection`](https://www.nuget.org/packages/Autofac.Extensions.DependencyInjection/)

Change `ConfigureServices` method to return `IServiceProvider` implemented by AutoFac
```csharp
public IServiceProvider ConfigureServices(IServiceCollection services)
{
   //...

   var containerBuilder = new ContainerBuilder();
   containerBuilder.Populate(services);
   containerBuilder.RegisterType<BlogRepository>().As<IBlogRepository>();
   return new AutofacServiceProvider(containerBuilder.Build());
}
```

## API Explorer

### Nuget package: [`Swashbuckle.AspNetCore`](https://www.nuget.org/packages/Swashbuckle.AspNetCore/)

Register Swashbuckle dependencies
```csharp
public void ConfigureServices(IServiceCollection services)
{
   //...

   services.AddSwaggerGen(config => config.SwaggerDoc("v1", new Info()));

   //...
}
```

Register middleware to create endpoints
```csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
   //...

   app.UseSwagger();
   app.UseSwaggerUI(config => config.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI"));

   //...
}
```

## Test server

### Nuget package: [`Microsoft.AspNetCore.TestHost`](https://www.nuget.org/packages/Microsoft.AspNetCore.TestHost/)

Create test server and make a GET call to swagger JSON endpoint
```csharp
[Test]
public async Task ShouldHaveSwaggerEndpoint()
{
   var testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
   var httpClient = testServer.CreateClient();
   var response = await httpClient.GetAsync("/swagger/v1/swagger.json");

   //...
}
```