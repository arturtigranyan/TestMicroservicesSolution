using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularUI", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddHttpClient();

var app = builder.Build();

app.UseCors("AllowAngularUI");
app.UseHttpsRedirection();

// Users Microservice routes
app.MapPost("/api/users/auth/register", async (HttpContext context, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();
    var requestMessage = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5078/api/auth/register")
    {
        Content = new StreamContent(context.Request.Body)
    };
    requestMessage.Content.Headers.ContentType = new("application/json");

    var response = await client.SendAsync(requestMessage);
    context.Response.StatusCode = (int)response.StatusCode;
    await response.Content.CopyToAsync(context.Response.Body);
});

app.MapPost("/api/users/auth/login", async (HttpContext context, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();
    var requestMessage = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5078/api/auth/login")
    {
        Content = new StreamContent(context.Request.Body)
    };
    requestMessage.Content.Headers.ContentType = new("application/json");

    var response = await client.SendAsync(requestMessage);
    context.Response.StatusCode = (int)response.StatusCode;
    await response.Content.CopyToAsync(context.Response.Body);
});

app.MapGet("/api/users/profile", async (HttpContext context, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();
    var requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5078/api/users/profile");

    if (context.Request.Headers.TryGetValue("Authorization", out var token))
        requestMessage.Headers.Add("Authorization", token.ToString());

    var response = await client.SendAsync(requestMessage);
    context.Response.StatusCode = (int)response.StatusCode;
    await response.Content.CopyToAsync(context.Response.Body);
});

// Products Microservice routes
app.MapGet("/api/products", async (IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();
    var response = await client.GetAsync("http://localhost:5269/api/products");
    return Results.Stream(await response.Content.ReadAsStreamAsync(), "application/json");
});

app.MapGet("/api/products/{id:guid}", async (Guid id, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();
    var response = await client.GetAsync($"http://localhost:5269/api/products/{id}");
    return Results.Stream(await response.Content.ReadAsStreamAsync(), response.Content.Headers.ContentType?.ToString());
});

app.MapPost("/api/products", async (HttpContext context, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();
    var requestMessage = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5269/api/products")
    {
        Content = new StreamContent(context.Request.Body)
    };
    requestMessage.Content.Headers.ContentType = new("application/json");

    var response = await client.SendAsync(requestMessage);
    context.Response.StatusCode = (int)response.StatusCode;
    await response.Content.CopyToAsync(context.Response.Body);
});

// Orders Microservice routes (corrected)
app.MapPost("/api/orders", async (HttpContext context, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();
    var requestMessage = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5072/api/orders")
    {
        Content = new StreamContent(context.Request.Body)
    };
    requestMessage.Content.Headers.ContentType = new("application/json");

    var response = await client.SendAsync(requestMessage);
    context.Response.StatusCode = (int)response.StatusCode;
    await response.Content.CopyToAsync(context.Response.Body);
});

app.MapGet("/api/orders", async (IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();
    var response = await client.GetAsync("http://localhost:5072/api/orders");
    return Results.Stream(await response.Content.ReadAsStreamAsync(), response.Content.Headers.ContentType?.ToString());
});

app.MapGet("/api/orders/user-orders/{userId:guid}", async (Guid userId, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();
    var response = await client.GetAsync($"http://localhost:5072/api/orders/user/{userId}");
    return Results.Stream(await response.Content.ReadAsStreamAsync(), response.Content.Headers.ContentType?.ToString());
});

app.Run();
