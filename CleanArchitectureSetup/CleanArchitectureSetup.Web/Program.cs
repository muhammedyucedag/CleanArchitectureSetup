using System.Threading.RateLimiting;
using CleanArchitectureSetup.Application;
using CleanArchitectureSetup.Infrastructure;
using Microsoft.AspNetCore.RateLimiting;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultPolicy", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddRateLimiter(x => x.AddFixedWindowLimiter("fixed", cfg =>
{
    // Limitleyici adı: "fixed". Bu, belirli bir istek sınırlama kuralını temsil eder.
    
    cfg.QueueLimit = 100; 
    // Kuyruktaki maksimum bekleyen istek sayısı (kuyruk dolarsa yeni istekler reddedilir).
    cfg.Window = TimeSpan.FromSeconds(1); 
    // Zaman penceresi: Her 1 saniyelik periyotta istekler sınırlanır.
    cfg.PermitLimit = 100; 
    // Zaman penceresi başına izin verilen maksimum istek sayısı.
    cfg.QueueProcessingOrder = QueueProcessingOrder.OldestFirst; 
    // Kuyruktaki isteklerin işlenme sırası: En eski istek önce işlenir.
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "/openapi/{documentName}.json";
    });
    
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("DispatchLine API")
            .WithDownloadButton(true)
            .WithTheme(ScalarTheme.DeepSpace);
    });
}

app.UseCors("DefaultPolicy");
app.UseHttpsRedirection();
app.MapOpenApi();

app.MapWhen(context => context.Request.Path == "/" || context.Request.Path == "/index.html",
    appBuilder =>
    {
        appBuilder.Run(context =>
        {
            context.Response.Redirect("/scalar/v1");
            return Task.CompletedTask;
        });
    });

app.MapControllers().RequireRateLimiting("fixed");

app.Run();