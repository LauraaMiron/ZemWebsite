using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyAuthApp.Data;
using MyAuthApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options =>{
    var connectionString= builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IWorkshopService, WorkshopService>();

var app = builder.Build();
if(!app.Environment.IsDevelopment()){
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute(); 
app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();
app.Run();
