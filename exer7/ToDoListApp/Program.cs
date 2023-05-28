using Microsoft.EntityFrameworkCore;
var webApplicationOptions = new WebApplicationOptions
{
    ContentRootPath = AppContext.BaseDirectory,
    Args = args,
};
var builder = WebApplication.CreateBuilder(webApplicationOptions);

// Add services to the container.
builder.Services.AddRazorPages(opt=>{
    opt.Conventions.AddPageRoute("/Tasks/Index","");
});

builder.Services.AddDbContext<ToDoDbContext>(opt => opt.UseSqlite("DataSource=Data/ToDoList.db"));

var app = builder.Build();


app.UseMiddleware<RequestLoggingMiddleware>();
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
