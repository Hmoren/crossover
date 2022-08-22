using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CrossOver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        //[HttpPost(Name = "CrearUsuario")]
        //public async Task<IActionResult> CrearUsuario([FromBody] UsuarioRequestDTO usuario)
        //{
        //    try
        //    {
        //        UsuarioResponseDTO usuarioResponseDTO = null;
        //        string token = "bab14d1e-47ce-4d2b-ae86-6a0bb5ed8370";
        //        var usuariostring = JsonConvert.SerializeObject(usuario);
        //        var request = new HttpRequestMessage(HttpMethod.Post, "http://restapi.adequateshop.com/api/users");
        //        request.Content = new StringContent(usuariostring, Encoding.UTF8);
        //        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //        HttpClient client = new HttpClient();


        //        HttpResponseMessage response = await client.SendAsync(request);

        //        if (response.StatusCode == System.Net.HttpStatusCode.Created)
        //        {
        //            var apiString = await response.Content.ReadAsStringAsync();
        //            usuarioResponseDTO = JsonConvert.DeserializeObject<UsuarioResponseDTO>(apiString);
                    
        //        }
        //        else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
        //        {
        //            return BadRequest("Error al crear usuario");
        //        }

        //        return Ok(usuarioResponseDTO);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest("Error al crear usuario");
        //    }
            
        //}

        //public class UsuarioRequestDTO
        //{
        //    public string name { get; set; }
        //    public string email { get; set; }
        //    public string location { get; set; }

        //}

        //public class UsuarioResponseDTO
        //{
        //    public int id { get; set; }
        //    public string name { get; set; }
        //    public string email { get; set; }
        //    public string profilepicture { get; set; }                       
        //    public string location { get; set; }
        //    public string createdat { get; set; }

        //}




    }
}
