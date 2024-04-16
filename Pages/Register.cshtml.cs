using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PowerTools.Models;
using Microsoft.AspNetCore.Http;

namespace PowerTools.Pages
{
    public class RegisterModel : PageModel
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Ramazan\\Documents\\powertools.mdf;Integrated Security=True;Connect Timeout=30;";
        private readonly ILogger<RegisterModel> _logger;
        public  string Email { get; set; }
        public  string Password { get; set; }
        public string Username { get; set; }

        private readonly UserManager<User> _userManager;

        private readonly ApplicationDbContext _context;

        public RegisterModel(ILogger<RegisterModel> logger, UserManager<User> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var form = await Request.ReadFormAsync();
            var temp = new User { Email = form["Email"], UserName = form["Username"] }; // Создание экземпляра User
            var result = await _userManager.CreateAsync(temp, form["Password"]);

            _context.Users.Add(temp); // Добавление пользователя в контекст базы данных
            await _context.SaveChangesAsync();

            return RedirectToPage("/Login");
        }
        public void OnGet()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}
