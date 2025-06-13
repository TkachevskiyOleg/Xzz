using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xz.Services;

var builder = WebApplication.CreateBuilder(args);

// Додаємо сервіс для книг
builder.Services.AddSingleton<BookService>();

// Додаємо підтримку контролерів з представленнями
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Налаштування HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Головний маршрут: при запуску → BookController → Index()
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Book}/{action=Index}/{id?}"
);

app.Run();
