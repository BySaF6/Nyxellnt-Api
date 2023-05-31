using NyxellntAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace NyxellntAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FestivalController : ControllerBase
    {
        private readonly FestivalServiceInterface _festival;
        public FestivalController(FestivalServiceInterface festival)
        {
            _festival = festival;
        }

        // GET todos y por filtro
        [HttpGet]
        public List<FestivalEntity> GetAll([FromQuery] string mes, [FromQuery] string ordenarPrecio, [FromQuery] string ordenarPrecioVip)
        {
            var festival = _festival.GetAll();
            if(mes != null){
                festival = festival.Where(item => item.mes.ToLower().Equals(mes.ToLower())).ToList();
            }
            if(ordenarPrecio != null){
                if(ordenarPrecio.ToLower().Equals("asc"))
                {
                    festival = festival.OrderBy(item => item.precioEntrada).ToList();
                }
                else if(ordenarPrecio.ToLower().Equals("des"))
                {
                    festival = festival.OrderByDescending(item => item.precioEntrada).ToList();
                }
            } else if(ordenarPrecioVip != null){
                if(ordenarPrecioVip.ToLower().Equals("asc"))
                {
                    festival = festival.OrderBy(item => item.precioEntradaVip).ToList();
                }
                else if(ordenarPrecioVip.ToLower().Equals("des"))
                {
                    festival = festival.OrderByDescending(item => item.precioEntradaVip).ToList();
                }
            }
            return festival;
        }

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<FestivalEntity> Get(int id)
        {
            var festival = _festival.Get(id);
            if (festival == null)
                return NotFound();

            return festival;
        }

        // POST action
        [HttpPost]
        public ActionResult Create(FestivalEntity festivalEntity)
        {
            _festival.Add(festivalEntity);
            return CreatedAtAction(nameof(Get), new { id = festivalEntity.idFestival }, festivalEntity);
        }

        // DELETE action
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var festivalEntity = _festival.Get(id);

            if (festivalEntity is null)
                return NotFound();

            _festival.Delete(id);
            return NoContent();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(FestivalEntity festivalEntity)
        {
            _festival.Update(festivalEntity);
            return NoContent();
        }
    }
}