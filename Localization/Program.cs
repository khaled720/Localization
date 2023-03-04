using Localization;
using Localization.Resources;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages().AddViewLocalization().AddDataAnnotationsLocalization();

builder.Services.AddMvc().AddDataAnnotationsLocalization(
    opt => opt.DataAnnotationLocalizerProvider = (type, factory) =>
    {
        var assemblyName = new AssemblyName(typeof(DataAnnotationsResource).GetTypeInfo().Assembly.FullName!);
        return factory.Create(nameof(DataAnnotationsResource), assemblyName.Name!);

    }
    ).AddViewLocalization(
    
    Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix);  

builder.Services.AddLocalization(opt => opt.ResourcesPath = "Resources");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


var locOptions = new RequestLocalizationOptions();
var cultures = new[] { "en", "ar" };
locOptions.AddSupportedCultures(cultures);
locOptions.AddSupportedUICultures(cultures);
locOptions.ApplyCurrentCultureToResponseHeaders = true;
locOptions.DefaultRequestCulture = new RequestCulture(new CultureInfo(cultures[0]));

app.UseRequestLocalization(locOptions);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();

//app.MapRazorPages();

app.MapControllerRoute("default","{controller}/{action}");

app.Run();
