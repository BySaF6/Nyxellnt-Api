
using Microsoft.AspNetCore.Mvc;

namespace pruebaApi01.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        public UsuarioController()
        {
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<UsuarioEntity>> GetAll() => UsuarioService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<UsuarioEntity> Get(int id)
        {
            var usuario = UsuarioService.Get(id);
            if (usuario == null)
                return NotFound();

            return usuario;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(UsuarioEntity usuario)
        {
            UsuarioService.Add(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.idUsuario }, usuario);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, UsuarioEntity usuario)
        {
            if (id != usuario.idUsuario)
                return BadRequest();

            var existingUsuario = UsuarioService.Get(id);
            if (existingUsuario is null)
                return NotFound();

            UsuarioService.Update(usuario);
            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = UsuarioService.Get(id);

            if (usuario is null)
                return NotFound();

            UsuarioService.Delete(id);
            return NoContent();
        }
    }
}