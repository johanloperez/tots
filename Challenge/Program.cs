using challenge.domain.layer.Models.Options;
using challenge.infrastructure.layer;
using challenge.infrastructure.layer.Middleware;
using challenge.presentation.layer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var token = builder.Configuration.GetSection("GetToken");
var tokenDelegate = builder.Configuration.GetSection("Delegate");
var urls = builder.Configuration.GetSection("URL");

builder.Services.Configure<Token>(token);
builder.Services.Configure<TokenDelegate>(tokenDelegate);
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

builder.Services.AddHttpClient("code", options =>
{
    options.BaseAddress = new Uri(sectionUrls.GetCode);
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

    builder.Services.AddAuthentication().AddJwtBearer("Bearer", options =>
    {
    options.RequireHttpsMetadata = false;//En producción debe estar en true para usar https
    options.SaveToken = false;

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = false,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidAudience = "https://graph.microsoft.com",
        ClockSkew = TimeSpan.Zero
    };
        options.Authority = "https://sts.windows.net/cbc3158f-4cc3-4a36-b3d5-058b9f717782/";
        options.Audience = "https://graph.microsoft.com";
    });

builder.Services.AddControllers();
builder.Services.AddPresentationModule(builder.Configuration);
builder.Services.AddInfrastructureModule(builder.Configuration);
builder.Services.AddDomainModule(builder.Configuration);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test for TOT", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        });
});

builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();
app.UseMiddleware<ErrorMiddleware>();
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nombre de tu API V1");
});


app.UseInfrastructureModule(builder.Configuration);
app.UsePresentationModule(builder.Configuration);
app.UseDomainModule(builder.Configuration);

app.MapControllers();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
