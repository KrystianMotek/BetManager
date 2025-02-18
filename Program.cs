using FluentValidation;
using BetManager.Services;
using BetManager.Domain.Services;
using Microsoft.Extensions.Hosting;
using BetManager.Application.Models.Mappers;
using Microsoft.Extensions.DependencyInjection;
using BetManager.Infrastructure.Database.Repositories;
using Microsoft.Azure.Functions.Worker.Builder;
using BetManager.Infrastructure.Database;
using BetManager.Application.Validators;
using BetManager.Domain.Repositories;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services.AddScoped<ICouponMapper, CouponMapper>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<ICouponRepository, CouponRepository>();
builder.Services.AddScoped<ICouponPositionRepository, CouponPositionRepository>();
builder.Services.AddScoped<IDictionaryItemRepository, DictionaryItemRepository>();
builder.Services.AddScoped<ApplicationDbContext>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateCouponDTOValidator>();

// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

builder.Build().Run();