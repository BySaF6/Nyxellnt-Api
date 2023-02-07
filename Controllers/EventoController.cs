using NyxellntAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace NyxellntAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly NyxellntDb _context;
        public EventoController(NyxellntDb context)
        {
            _context = context;
        }

        // GET all action
        [HttpGet]
        public List<EventoEntity> GetAll() => _context.Eventos.ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public List<EventoEntity> Get(int id)
        {
            var evento = _context.Eventos.

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