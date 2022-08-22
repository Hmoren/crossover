using CrossOver.DTOs.Usuario;
using CrossOver.DTOs.UsuarioDTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CrossOver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {


        [HttpPost("~/crearUsuario")]
        public async Task<IActionResult> crearUsuario([FromBody] UsuarioRequestDTO usuario)
        {
            try
            {
                UsuarioResponseDTO usuarioResponseDTO = null;
                string token = "bab14d1e-47ce-4d2b-ae86-6a0bb5ed8370";
                var usuariostring = JsonConvert.SerializeObject(usuario);
                var request = new HttpRequestMessage(HttpMethod.Post, "http://restapi.adequateshop.com/api/users");
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
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
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


        [HttpPost("~/registration")]
        public async Task<IActionResult> registration(UsuarioRegitrationRequestDTO usuario)
        {
            try
            {
                UsuarioRegistrationDTO UsuarioRegistrationDTO = null;
                var usuariostring = JsonConvert.SerializeObject(usuario);
                var request = new HttpRequestMessage(HttpMethod.Post, "http://restapi.adequateshop.com/api/authaccount/registration");
                request.Content = new StringContent(usuariostring, Encoding.UTF8);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var apiString = await response.Content.ReadAsStringAsync();
                    UsuarioRegistrationDTO = JsonConvert.DeserializeObject<UsuarioRegistrationDTO>(apiString);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return BadRequest();
                }

                return Ok(UsuarioRegistrationDTO);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("~/login")]
        public async Task<string> login(UsuarioLoginDTO usuario)
        {
            string token = null;
            var usuariostring = JsonConvert.SerializeObject(usuario);
            var request = new HttpRequestMessage(HttpMethod.Post, "http://restapi.adequateshop.com/api/authaccount/login");
            request.Content = new StringContent(usuariostring, Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var apiString = await response.Content.ReadAsStringAsync();
                UsuarioRegistrationDTO usuarioRegistration = JsonConvert.DeserializeObject<UsuarioRegistrationDTO>(apiString);
                token = usuarioRegistration.data.Token;
            }

            return token;
        }
    }
}
