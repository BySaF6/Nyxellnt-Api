using NyxellntAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace NyxellntAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly EventoServiceInterface _evento;
        public EventoController(EventoServiceInterface evento)
        {
            _evento = evento;
        }

        // GET all action
        [HttpGet]
        public List<EventoEntity> GetAll() => _evento.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<EventoEntity> Get(int id)
        {
            var evento = _evento.Get(id);
            if (evento == null)
                return NotFound();

            return evento;
        }

        // POST action
        [HttpPost]
        public ActionResult Create(EventoEntity eventoEntity)
        {
            _evento.Add(eventoEntity);
            return CreatedAtAction(nameof(Get), new { id = eventoEntity.idEvento }, eventoEntity);
        }

        // // DELETE action
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var eventoEntity = _evento.Get(id);

            if (eventoEntity is null)
                return NotFound();

            _evento.Delete(id);
            return NoContent();
        }

        // // PUT action
        // [HttpPut("{id}")]
        // public IActionResult Update(int id, EventoEntity eventoEntity)
        // {
        //     if (id != eventoEntity.idEvento)
        //         return BadRequest();

        //     var existingEvento = EventoService.Get(id);
        //     if (existingEvento is null)
        //         return NotFound();

        //     EventoService.Update(eventoEntity);
        //     return NoContent();
        // }

        
    }
}