using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using marshinov2310.Models;

namespace marshinov2310.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = new List<Product>();
            string connectionString = @"Server=10.17.1.56;Port=5432;Database=arshinov2310;User Id=postgres;
Password=admin;";
            string sqlExpression = "SELECT * FROM Users";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        var product = new Product();
                        product.Cost = reader.GetInt32(0);
                        product.Description = reader.GetString(1);
                        product.Image = reader.GetString(2);
                        product.Name = reader.GetString(3);
                        products.Add(product);
                    }
                }

                reader.Close();
            }

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}