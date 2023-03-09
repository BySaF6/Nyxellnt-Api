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

        //Filtrar por genero
        [HttpGet("genero/{genero}")]
        public List<EventoEntity> GetAll(string genero) {
            var evento = _evento.GetAll();
            return evento.Where(item => item.categoria.ToLower().Equals(genero.ToLower())).ToList();
        }

        //Ordenar por precio ascendente o descendente
        [HttpGet("ordenarPrecio/{ascendente}")]
        public List<EventoEntity> GetAll(Boolean ascendente) {
            var evento = _evento.GetAll();
            if(ascendente == true){
                return evento.OrderBy(item => item.precioEntrada).ToList();
            } else {
                return evento.OrderByDescending(item => item.precioEntrada).ToList();
            }
        }

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

        // DELETE action
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var eventoEntity = _evento.Get(id);

            if (eventoEntity is null)
                return NotFound();

            _evento.Delete(id);
            return NoContent();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(EventoEntity eventoEntity)
        {
            _evento.Update(eventoEntity);
            return NoContent();
        }
    }
}