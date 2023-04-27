
using Microsoft.AspNetCore.Mvc;

namespace pruebaApi01.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioServiceInterface _usuario;
        public UsuarioController(UsuarioServiceInterface usuario)
        {
            _usuario = usuario;
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