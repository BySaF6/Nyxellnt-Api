using NyxellntAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Net;

namespace NyxellntAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public AuthController(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            var response = _httpClient.GetAsync($"api/datos/GetByEmail?email={model.Email}&password={model.Password}");
            // Aquí validamos el usuario y contraseña (este es solo un ejemplo básico)

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsAsync<bool>();
                if (result)
                {
                    Console.WriteLine("El registro existe");
                }
                else
                {
                    Console.WriteLine("El registro no existe");
                }
            }

            // Si el usuario y la contraseña son válidos, generamos un token JWT
            var token = GenerateJwtToken(model.Email);

            // Devolvemos el token como respuesta
            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(string email)
        {
            // Configuramos los parámetros de generación de token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSecret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Generamos el token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

}