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
        public List<FestivalEntity> GetAll([FromQuery] string mes, [FromQuery] string ordenarFecha)
        {
            var festival = _festival.GetAll();
            if(mes != null){
                festival = festival.Where(item => item.mes.ToLower().Equals(mes.ToLower())).ToList();
            }
            if(ordenarFecha != null){
                if(ordenarFecha.ToLower().Equals("asc"))
                {
                    festival = festival.OrderBy(item => DateTime.Parse(item.fecha)).ToList();
                }
                else if(ordenarFecha.ToLower().Equals("des"))
                {
                    festival = festival.OrderByDescending(item => DateTime.Parse(item.fecha)).ToList();
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