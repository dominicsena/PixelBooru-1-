using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using pixelBooru_1_.Models; // Make sure to include the namespace for your Artwork model

namespace pixelBooru_1_.Controllers
{
    public class ArtworkController : Controller
    {
        private readonly IConfiguration _configuration;

        public ArtworkController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateImage([FromBody] Artwork model)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string sql = "UPDATE Images SET Title = @Title, ArtistName = @ArtistName WHERE ImageId = @ImageId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Title", model.title);
                    command.Parameters.AddWithValue("@ArtistName", model.artistName);
                    command.Parameters.AddWithValue("@ImageId", model.ImageId);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                        return Json(new { success = true, message = "Image information updated successfully" });
                    }
                    catch (Exception ex)
                    {
                        return Json(new { success = false, message = "Error updating image information: " + ex.Message });
                    }
                }
            }
        }
    }
}
