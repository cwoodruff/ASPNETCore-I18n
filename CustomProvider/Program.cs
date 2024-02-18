using System.Globalization;
using CustomProvider;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IStringLocalizerFactory, CustomStringLocalizerFactory>();
builder.Services.AddTransient(typeof(IStringLocalizer<>), typeof(StringLocalizer<>));

var supportedCultures = new List<CultureInfo>
{
    new CultureInfo("en-US"),
    new CultureInfo("it-IT"),
    new CultureInfo("ja-JP"),
    new CultureInfo("nl-NL"),
    new CultureInfo("ru-RU")
};

var options = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
};

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRequestLocalization(options);

app.MapGet("/", (IStringLocalizer<Program> stringLocalizer) =>
{
    var detectedCultureName = CultureInfo.CurrentCulture.EnglishName;
    var detectedUiCultureName = CultureInfo.CurrentUICulture.EnglishName;

    var cultureTable = $"{stringLocalizer["Hello"]}, "
                       + $"{stringLocalizer["DetectedCulture"]} is {detectedCultureName}, "
                       + $"{stringLocalizer["DetectedUICulture"]} is {detectedUiCultureName}, "
                       + $"<{stringLocalizer["CurrentDate"]} is {DateTime.Now:D}, "
                       + $"{stringLocalizer["FormattedNumber"]} is {(1234567.89):n}, "
                       + $"{stringLocalizer["CurrencyValue"]} is {(42):C}, "
                       + $"{stringLocalizer["Goodbye"]}";

    return Results.Ok(cultureTable);
});

app.Run();