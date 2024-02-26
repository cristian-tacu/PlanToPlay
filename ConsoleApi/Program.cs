using Adapter.Database.Common.Repositories;
using Adapter.Database.Players;
using Adapter.Hangfire;
using DomainApi.Common.Repositories;
using DomainApi.Players.Repositories;
using DomainImpl;
using DomainImpl.Players.Services;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

Env.Load();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("ptp")!);
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAdapterHangfireServices(builder.Configuration.GetConnectionString("hangfire")!);


builder.Services.AddApiVersioning()
    .AddMvc()
    .AddApiExplorer(
        options =>
        {
            // format the version as "'v'major[.minor][-status]"
            // ReSharper disable once StringLiteralTypo
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(DomainImplAssembly.Value));

builder.Services.AddResponseCaching();

// Add repositories
builder.Services.AddScoped<IPlayersRepository, PlayersRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IStatsRepository, StatsRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// builder.Services.AddScoped<IEngineService, EngineService>();

builder.Services.AddLogging(build =>
{
    build.AddConsole().SetMinimumLevel(LogLevel.Debug);
    build.AddDebug().SetMinimumLevel(LogLevel.Debug);
});

var app = builder.Build();
app.UseResponseCaching();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();

    app.UseSwagger();

    app.UseSwaggerUI(
        options =>
        {
            foreach (var description in app.DescribeApiVersions())
            {
                var url = $"/swagger/{description.GroupName}/swagger.json";
                var name = description.GroupName;
                options.SwaggerEndpoint(url, name);
            }
        });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseAdapterHangfire();

// Deleting the jobs older than 1 day
RecurringJob.AddOrUpdate<ClearGradesService>("grade-job", x => x.Invoke(), Cron.Daily);

app.Run();