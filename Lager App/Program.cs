using Lager_App.DBContext;
using Lager_App.Model;
using Lager_App.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();



//Adding DB 
builder.Services.Configure<DBOptions>(builder.Configuration.GetSection(DBOptions.SectionName));
using (var provider = builder.Services!.BuildServiceProvider())
{
    var OptionService = provider.GetRequiredService<IOptions<DBOptions>>();
    var option = OptionService.Value;

    if (option is null)
    {
        throw new Exception("DBOptions not set");
    }

    builder.Services.AddDbContext<ArticelDBContext>(o =>
    {
        o.UseSqlite(option.ConnectionString??"");
    });
}


//Adding Articel Service
builder.Services.AddScoped<ArticelService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

//Create DB if not exists
using (var serviceScope = app.Services.CreateScope())
{
    var dbcontext = serviceScope.ServiceProvider.GetRequiredService<ArticelDBContext>();
    await dbcontext!.Database.MigrateAsync();
}

app.Run();
