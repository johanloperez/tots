using challenge.domain.layer.api.Contracts;
using challenge.domain.layer.api.Models.Options;
using challenge.infrastructure.layer.api.ExternalApis.MicrosoftGraphApi;
using challenge.infrastructure.layer.api.HttpRequest;
using challenge.infrastructure.layer.api;
using challenge.bootstrapper.layer.api;

var builder = WebApplication.CreateBuilder(args);

var token = builder.Configuration.GetSection("GetToken");
var urls = builder.Configuration.GetSection("URL");

builder.Services.Configure<Token>(token);
builder.Services.Configure<Urls>(urls);

var sectionUrls = urls.Get<Urls>();

// Add services to the container.
builder.Services.AddHttpClient("token", options =>
{
    options.BaseAddress = new Uri(sectionUrls.GetToken);
}).ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
    
});

builder.Services.AddHttpClient("users", options =>
{
    options.BaseAddress = new Uri(sectionUrls.GetUsers);
}).ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }

});

builder.Services.AddHttpClient("calendars", options =>
{
    options.BaseAddress = new Uri(sectionUrls.GetCalendars);
}).ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }

});

builder.Services.AddHttpClient("events", options =>
{
    options.BaseAddress = new Uri(sectionUrls.GetEvents);
}).ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }

});

builder.Services.AddHttpClient("createEvents", options =>
{
    options.BaseAddress = new Uri(sectionUrls.CreateEvents);
}).ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }

});

builder.Services.AddHttpClient("editEvents", options =>
{
    options.BaseAddress = new Uri(sectionUrls.EditEvents);
}).ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }

});

builder.Services.AddHttpClient("deleteEvents", options =>
{
    options.BaseAddress = new Uri(sectionUrls.DeleteEvents);
}).ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }

});


builder.Services.AddControllers();

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddHelpers();
builder.Services.AddExternalServices();
builder.Services.AddSwagger();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
