using END.Persistence;
using END.Application.Model;
using Microsoft.EntityFrameworkCore;
using END.Persistence.Services;
using END.Application.Interfaces.Services;
using NLog.Web;
using NLog;

var logger = LogManager.Setup().
    LoadConfigurationFromAppSettings().
    GetCurrentClassLogger();
try
{
    logger.Info("Program init");

    var builder = WebApplication.CreateBuilder(args);

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddScoped<EntityDBContext>();
    builder.Services.AddScoped<IDocumentService, DocumentService>();
    builder.Services.AddScoped<IAttributeValueService, AttributeValueService>();
    builder.Services.AddScoped<IDocumentLinkService, DocumentLinkService>();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddControllersWithViews()
        .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );
    builder.Configuration.Bind("DataBase", new DataBase());
    builder.Services.AddDbContext<EntityDBContext>(options =>
    {
        options.UseNpgsql(DataBase.ConnectionString);
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    });

    var app = builder.Build();

    app.UseCors(x => x
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true)
        .AllowCredentials());

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Error($"Program Error: {ex}");
}
finally
{
    LogManager.Shutdown();
}