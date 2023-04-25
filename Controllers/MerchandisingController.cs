using NyxellntAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace NyxellntAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MerchandisingController : ControllerBase
    {
        private readonly MerchandisingServiceInterface _merchandising;
        public MerchandisingController(MerchandisingServiceInterface merchandising)
        {
            _merchandising = merchandising;
        }

        // GET todos y por filtro
        [HttpGet]
        public List<MerchandisingEntity> GetAll()
        {
            var merchandising = _merchandising.GetAll();
            // if(genero != null){
            //     evento = evento.Where(item => item.categoria.ToLower().Equals(genero.ToLower())).ToList();
            // }
            // if(ordenarPrecio != null){
            //     if(ordenarPrecio.ToLower().Equals("asc"))
            //     {
            //         evento = evento.OrderBy(item => item.precioEntrada).ToList();
            //     }
            //     else if(ordenarPrecio.ToLower().Equals("des"))
            //     {
            //         evento = evento.OrderByDescending(item => item.precioEntrada).ToList();
            //     }
            // }
            return merchandising;
        }

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<MerchandisingEntity> Get(int id)
        {
            var merchandising = _merchandising.Get(id);
            if (merchandising == null)
                return NotFound();

            return merchandising;
        }

        // POST action
        [HttpPost]
        public ActionResult Create(MerchandisingEntity merchandisingEntity)
        {
            _merchandising.Add(merchandisingEntity);
            return CreatedAtAction(nameof(Get), new { id = merchandisingEntity.idEvento }, merchandisingEntity);
        }

        // DELETE action
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var merchandisingEntity = _merchandising.Get(id);

            if (merchandisingEntity is null)
                return NotFound();

            _merchandising.Delete(id);
            return NoContent();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(MerchandisingEntity merchandisingEntity)
        {
            _merchandising.Update(merchandisingEntity);
            return NoContent();
        }
    }
}