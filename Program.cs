using FluentValidation;
using BetManager.Services;
using Microsoft.Extensions.Hosting;
using BetManager.Application.Models.Mappers;
using Microsoft.Extensions.DependencyInjection;
using BetManager.Infrastructure.Database.Repositories;
using Microsoft.Azure.Functions.Worker.Builder;
using BetManager.Infrastructure.Database;
using BetManager.Application.Validators;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services.AddScoped<CouponMapper>();
builder.Services.AddScoped<CouponService>();
builder.Services.AddScoped<CouponRepository>();
builder.Services.AddScoped<CouponPositionRepository>();
builder.Services.AddScoped<DictionaryItemRepository>();
builder.Services.AddScoped<ApplicationDbContext>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateCouponDTOValidator>();

// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

builder.Build().Run();