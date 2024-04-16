using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerTools.Models;

var builder = WebApplication.CreateBuilder(args);

// ��������� ������� ��� ������ � Razor Pages
builder.Services.AddRazorPages();

// ������������ ApplicationDbContext ��� �������������� � ����� ������
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ������������ Identity � ����������� ���������
builder.Services.AddDefaultIdentity<User>(options => 
{
    // ��������� ������������� �������� (����� �������� �� ������ ����������)
    options.SignIn.RequireConfirmedAccount = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>(); // ��������� �������� ��� �������� ������ Identity

// ��������� �������������� ����� ����
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

var app = builder.Build();

// ����������� �������� ��������
if (!app.Environment.IsDevelopment())
{
    // ��������� ���������� ������ ��� �������������� �����
    app.UseExceptionHandler("/Error");
}

// ��������� ��������� ����������� ������
app.UseStaticFiles();

// ��������� �������������
app.UseRouting();

// ��������� �������������� � �����������
app.UseAuthentication();
app.UseAuthorization();

// ��������� ��������� �������� � Razor Pages
app.MapRazorPages();



// ��������� ��� ������������...

// ����� �� �������� ��� ������� ����������
app.Run();

