// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ML;
using Microsoft.OpenApi.Models;
using System.Threading.Tasks;

// Configure app
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPredictionEnginePool<MLModel.ModelInput, MLModel.ModelOutput>()
    .FromFile("MLModel.zip");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
var app = builder.Build();

//app.UseCors("AllowAll");
//app.UseCors("*");

// Shows UseCors with CorsPolicyBuilder.
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

// Define prediction route & handler
app.MapPost("/predict",
    async (PredictionEnginePool<MLModel.ModelInput, MLModel.ModelOutput> predictionEnginePool, MLModel.ModelInput input) =>
        await Task.FromResult(predictionEnginePool.Predict(input)));

app.MapGet("/", () => "Hello World!");

// Run app
app.Run();


