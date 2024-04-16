using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerTools.Models;

var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы для работы с Razor Pages
builder.Services.AddRazorPages();

// Регистрируем ApplicationDbContext для взаимодействия с базой данных
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрируем Identity и настраиваем параметры
builder.Services.AddDefaultIdentity<User>(options => 
{
    // Настройки подтверждения аккаунта (можно изменить по своему усмотрению)
    options.SignIn.RequireConfirmedAccount = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>(); // Указываем контекст для хранения данных Identity

// Добавляем аутентификацию через куки
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

var app = builder.Build();

// Настраиваем конвейер запросов
if (!app.Environment.IsDevelopment())
{
    // Добавляем обработчик ошибок для непродуктивной среды
    app.UseExceptionHandler("/Error");
}

// Добавляем обработку статических файлов
app.UseStaticFiles();

// Добавляем маршрутизацию
app.UseRouting();

// Добавляем аутентификацию и авторизацию
app.UseAuthentication();
app.UseAuthorization();

// Добавляем обработку запросов к Razor Pages
app.MapRazorPages();



// Остальной код конфигурации...

// Выход из аккаунта при запуске приложения
app.Run();

