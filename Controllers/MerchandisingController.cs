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
        public List<MerchandisingEntity> GetAll([FromQuery] string tipoProducto, [FromQuery] string precioProducto)
        {
            var merchandising = _merchandising.GetAll();
            if(tipoProducto != null){
                merchandising = merchandising.Where(item => item.tipoProducto.ToLower().Equals(tipoProducto.ToLower())).ToList();
            }
            if(precioProducto != null){
                if(precioProducto.ToLower().Equals("asc"))
                {
                    merchandising = merchandising.OrderBy(item => item.precioProducto).ToList();
                }
                else if(precioProducto.ToLower().Equals("des"))
                {
                    merchandising = merchandising.OrderByDescending(item => item.precioProducto).ToList();
                }
            }
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
            return CreatedAtAction(nameof(Get), new { id = merchandisingEntity.idMerchandising }, merchandisingEntity);
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