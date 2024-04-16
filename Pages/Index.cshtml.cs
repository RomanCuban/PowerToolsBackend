using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using PowerTools.Models;

namespace PowerTools.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public String Power { get; set; } = "";
        public String Huina { get; set; } = "";
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Ramazan\\Documents\\powertools.mdf;Integrated Security=True;Connect Timeout=30;";
        string queryString = "SELECT * FROM Tools";

        public List<Tool> tools = new List<Tool>();
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
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

                    while (reader.Read())
                    {
                        //Console.WriteLine($"Column1: {reader["Column1"]}, Column2: {reader["Column2"]}");
                        Tool temp = new Tool((int)reader["ID"], (string)reader["Name"], (string)reader["Title"], (string)reader["LinktoImage"], (string)reader["FirstSpecs"], (string)reader["SecondSpecs"], (string)reader["ThirdSpecs"], (string)reader["FourthSpecs"], (string)reader["FifthSpecs"], (string)reader["SixthSpecs"], (string)reader["SecondTitle"], (string)reader["FirstSlide"], (string)reader["SecondSlide"], (string)reader["ThirdSlide"], (string)reader["FourthSlide"]);
                        tools.Add(temp);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }

    }
}
