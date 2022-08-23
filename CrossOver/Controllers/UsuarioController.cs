using CrossOver.DTOs.Usuario;
using CrossOver.DTOs.UsuarioDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CrossOver.Controllers
{
    /// <summary>
    /// API controller Usuario, consume la api desde la siguiente URL https://www.appsloveworld.com/sample-rest-api-url-for-testing-with-authentication
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost("~/crearUsuario")]
        public async Task<IActionResult> crearUsuario([FromBody] UsuarioRequestDTO usuario, [FromHeader] string token)
        {
            try
            {
                var url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Urls")["url_crearUsuario"];
                UsuarioResponseDTO usuarioResponseDTO = null;

                var usuariostring = JsonConvert.SerializeObject(usuario);
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = new StringContent(usuariostring, Encoding.UTF8);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var apiString = await response.Content.ReadAsStringAsync();
                    usuarioResponseDTO = JsonConvert.DeserializeObject<UsuarioResponseDTO>(apiString);
                }
                else
                {
                    return BadRequest("Error al crear usuario");
                }

                return Ok(usuarioResponseDTO);
            }
            catch (Exception)
            {
                return BadRequest("Error al crear usuario");
            }

        }

        /// <summary>
        /// Registra un usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost("~/registration")]
        public async Task<IActionResult> registration(UsuarioRegitrationRequestDTO usuario)
        {
            try
            {
                var url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Urls")["url_registration"];
                UsuarioRegistrationDTO UsuarioRegistrationDTO = null;
                var usuariostring = JsonConvert.SerializeObject(usuario);
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = new StringContent(usuariostring, Encoding.UTF8);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var apiString = await response.Content.ReadAsStringAsync();
                    UsuarioRegistrationDTO = JsonConvert.DeserializeObject<UsuarioRegistrationDTO>(apiString);
                }
                else
                {
                    return BadRequest("Error al crear registro");
                }

                return Ok(UsuarioRegistrationDTO);

            }
            catch (Exception)
            {
                return BadRequest("Error al crear registro");
            }
        }

        /// <summary>
        /// Autentica usuario para obtener token
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost("~/login")]
        public async Task<UsuarioRegistrationDTO> login(UsuarioLoginDTO usuario)
        {
            var url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Urls")["url_login"];
            var usuariostring = JsonConvert.SerializeObject(usuario);
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(usuariostring, Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);


            var apiString = await response.Content.ReadAsStringAsync();
            UsuarioRegistrationDTO usuarioRegistration = JsonConvert.DeserializeObject<UsuarioRegistrationDTO>(apiString);

            return usuarioRegistration;
        }
    }
}
