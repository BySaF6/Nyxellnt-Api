
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace pruebaApi01.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly UsuarioServiceInterface _usuario;
        private readonly ILogger<UsuarioController> _logger;
        public UsuarioController(UsuarioServiceInterface usuario, IConfiguration configuration)
        {
            _usuario = usuario;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public dynamic IniciarSesion([FromBody] Object optData){
            var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());

            int id = data.id;
            string email = data.email.ToString();
            string password = data.password.ToString();

            UsuarioEntity usuario = _usuario.Get(id);

            if(usuario == null){
                return new
                {
                    success = false,
                    message = "Credenciales incorrectas",
                    result = ""
                };
            }

            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

            var claims = new []
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("id", usuario.idUsuario.ToString()),
                new Claim("rol", usuario.rol),
                new Claim("usuario", usuario.nombre),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var timeOut = 60;
            if(usuario.rol == "Admin"){
                timeOut = 1440;
            }

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(timeOut),
                signingCredentials: signIn
            );

            return new
            {
                success = true,
                message = "Éxito",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };

        }

        // GET all action
        [HttpGet]
        public List<UsuarioEntity> GetAll() => _usuario.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<UsuarioEntity> Get(int id)
        {
            var usuario = _usuario.Get(id);
            if (usuario == null)
                return NotFound();

            return usuario;
        }

        // GET by Email action
        [HttpGet("{email}, {password}")]
        public Boolean GetByEmail(string email, string password)
        {
            var usuario = _usuario.GetByEmail(email);
            if (usuario == null)
            {
                return false;
            }
            if (usuario.password == password)
            {
                return true;
            }

            return false;
        }

        // // POST action
        [HttpPost]
        public ActionResult Create(UsuarioEntity usuario)
        {
            _usuario.Add(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.idUsuario }, usuario);
        }

        // // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _usuario.Get(id);

            if (usuario is null)
                return NotFound();

            _usuario.Delete(id);
            return NoContent();
        }

        // // // PUT action
        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(UsuarioEntity usuarioEntity)
        {
            _usuario.Update(usuarioEntity);
            return NoContent();
        }

        // [HttpPut("{id}")]
        // public ActionResult Update(int id, UsuarioEntity usuario)
        // {
        //     if (id != usuario.idUsuario)
        //         return BadRequest();

        //     var existingUsuario = _usuario.Get(id);
        //     if (existingUsuario is null)
        //         return NotFound();

        //     _usuario.Update(usuario);
        //     return NoContent();
        // }
    }
}