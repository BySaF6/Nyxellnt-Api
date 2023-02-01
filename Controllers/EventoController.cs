
using Microsoft.AspNetCore.Mvc;

namespace pruebaApi01.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        public EventoController()
        {
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<EventoEntity>> GetAll() => EventoService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<EventoEntity> Get(int id)
        {
            var evento = EventoService.Get(id);
            if (evento == null)
                return NotFound();

            return evento;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(EventoEntity eventoEntity)
        {
            EventoService.Add(eventoEntity);
            return CreatedAtAction(nameof(Get), new { id = eventoEntity.idEvento }, eventoEntity);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, EventoEntity eventoEntity)
        {
            if (id != eventoEntity.idEvento)
                return BadRequest();

            var existingEvento = EventoService.Get(id);
            if (existingEvento is null)
                return NotFound();

            EventoService.Update(eventoEntity);
            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var eventoEntity = EventoService.Get(id);

            if (eventoEntity is null)
                return NotFound();

            EventoService.Delete(id);
            return NoContent();
        }
    }
}