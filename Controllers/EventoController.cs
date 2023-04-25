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

        // GET todos y por filtro
        [HttpGet]
        public List<EventoEntity> GetAll([FromQuery] string genero, [FromQuery] string ordenarPrecio, [FromQuery] string ordenarPrecioVip)
        {
            var evento = _evento.GetAll();
            if(genero != null){
                evento = evento.Where(item => item.categoria.ToLower().Equals(genero.ToLower())).ToList();
            }
            if(ordenarPrecio != null){
                if(ordenarPrecio.ToLower().Equals("asc"))
                {
                    evento = evento.OrderBy(item => item.precioEntrada).ToList();
                }
                else if(ordenarPrecio.ToLower().Equals("des"))
                {
                    evento = evento.OrderByDescending(item => item.precioEntrada).ToList();
                }
            } else if(ordenarPrecioVip != null){
                if(ordenarPrecioVip.ToLower().Equals("asc"))
                {
                    evento = evento.OrderBy(item => item.precioEntradaVip).ToList();
                }
                else if(ordenarPrecioVip.ToLower().Equals("des"))
                {
                    evento = evento.OrderByDescending(item => item.precioEntradaVip).ToList();
                }
            }
            return evento;
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