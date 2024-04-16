using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using PowerTools.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace PowerTools.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Ramazan\\Documents\\powertools.mdf;Integrated Security=True;Connect Timeout=30;";
        string queryString = "SELECT * FROM Users";

        public List<Tool> tools = new List<Tool>();

        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context; // Добавлен контекст базы данных
        private readonly SignInManager<User> _signInManager;

        public LoginModel(ILogger<LoginModel> logger, UserManager<User> userManager, ApplicationDbContext context, SignInManager<User> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var form = await Request.ReadFormAsync();
            Email = form["Email"];
            Password = form["Password"];
            


            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Email)
                };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true // Сохранять ли куки авторизации
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            
            return RedirectToPage("/Index");
        }
        public void OnGet()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

    }
}
