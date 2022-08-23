using CrossOver.DTOs.RespositorioDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CrossOver.Controllers
{
    /// <summary>
    /// API controller Respositorio, consume la api desde la siguiente URL https://api.github.com/
    /// </summary>
    public class RespositorioController : Controller
    {
        /// <summary>
        /// Lista repositorios segun la cantidad indicada
        /// </summary>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        [HttpGet("~/obtenerRepositorio/{cantidad:int}")]
        public async Task<IActionResult> obtenerRepositorio(int cantidad)
        {
            try
            {
                var url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Urls")["url_obtenerRepositorio"];
                List<RepositorioResponseDTO> RepositorioResponseDTOs = new List<RepositorioResponseDTO>();                
                string uri = url + cantidad;
                var request = new HttpRequestMessage(HttpMethod.Get, uri);                
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("product", "1"));
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var apiString = await response.Content.ReadAsStringAsync();
                    RepositorioResponseDTOs = JsonConvert.DeserializeObject<List<RepositorioResponseDTO>>(apiString);
                }
                else 
                {
                    return BadRequest("Error al obtener repositorio");
                }

                return Ok(RepositorioResponseDTOs);
            }
            catch (Exception)
            {
                return BadRequest("Error al obtener repositorio");
            }

        }

    }
}
