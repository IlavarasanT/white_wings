using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using white_wings.Models;

namespace white_wings.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //HttpClientHandler _clientHandler = new HttpClientHandler();
        Uri baseAddress = new Uri("https://localhost:7109/api/");
        HttpClient _client;

        public HomeController(ILogger<HomeController> logger)
        {
            _client =new HttpClient();
            _client.BaseAddress = baseAddress;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(user_table user_Table)
        {
            string data = JsonConvert.SerializeObject(user_Table);
            StringContent content=new StringContent(data,Encoding.UTF8,"application/json");
            HttpResponseMessage reponse = _client.PostAsync(_client.BaseAddress + "user_table", content).Result;
            if (reponse.IsSuccessStatusCode)
            {

            }
            return View();
        }

        [HttpGet]
        public ActionResult GetuserDetails(user_table user_Table)
        {
            List<user_table> modelList = new List<user_table>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/user_table").Result;
            if (response.IsSuccessStatusCode)
            {
                string data=response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<user_table>>(data);
            }
            return View(modelList);
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}