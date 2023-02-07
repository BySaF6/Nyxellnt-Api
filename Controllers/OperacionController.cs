using Microsoft.AspNetCore.Mvc;

namespace pruebaApi01.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OperacionController : ControllerBase
    {
        public OperacionController()
        {
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<OperacionEntity>> GetAll() => OperacionService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<OperacionEntity> Get(int id)
        {
            var evento = OperacionService.Get(id);
            if (evento == null)
                return NotFound();

            return evento;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(OperacionEntity operacionEntity)
        {
            OperacionService.Add(operacionEntity);
            return CreatedAtAction(nameof(Get), new { id = operacionEntity.idOperacion }, operacionEntity);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, OperacionEntity operacionEntity)
        {
            if (id != operacionEntity.idOperacion)
                return BadRequest();

            var existingEvento = OperacionService.Get(id);
            if (existingEvento is null)
                return NotFound();

            OperacionService.Update(operacionEntity);
            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var operacionEntity = OperacionService.Get(id);

            if (operacionEntity is null)
                return NotFound();

            OperacionService.Delete(id);
            return NoContent();
        }
    }
}