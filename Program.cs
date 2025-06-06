using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Configuration.AddAzureAppConfiguration(
    options => {
        options.Connect("Endpoint=https://applicationconfig4002.azconfig.io;Id=poXr;Secret=EQFPzOZwJIgJlTP1aIewDSo8rZpBLnxpv8Ey1fuBOh3Wiy2WTQi9JQQJ99BDACrJL3JL688dAAACAZAC238s");
        options.UseFeatureFlags();
    }
);
// builder.Configuration.AddAzureAppConfiguration("Endpoint=https://applicationconfig4002.azconfig.io;Id=poXr;Secret=EQFPzOZwJIgJlTP1aIewDSo8rZpBLnxpv8Ey1fuBOh3Wiy2WTQi9JQQJ99BDACrJL3JL688dAAACAZAC238s");
// builder.Configuration
// .AddJsonFile("appsettings.json")
//     .AddEnvironmentVariables();
builder.Services.AddFeatureManagement();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
