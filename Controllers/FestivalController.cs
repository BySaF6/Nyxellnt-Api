using NyxellntAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace NyxellntAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FestivalController : ControllerBase
    {
        private readonly FestivalServiceInterface _festival;
        private readonly ILogger<FestivalController> _logger;
        public FestivalController(FestivalServiceInterface festival)
        {
            _festival = festival;
        }

        // GET todos y por filtro
        [HttpGet]
        public List<FestivalEntity> GetAll([FromQuery] string mes, [FromQuery] string ordenarFecha)
        {
            var festival = _festival.GetAll();
            if (mes != null)
            {
                festival = festival.Where(item => item.mes.ToLower().Equals(mes.ToLower())).ToList();
            }
            if (ordenarFecha != null)
            {
                if (ordenarFecha == "des")
                {
                    festival.Sort((a, b) =>
                    {
                        string[] dateA = a.fecha.Split("/");
                        DateTime finalDateA = new DateTime(int.Parse(dateA[2]), int.Parse(dateA[1]) - 1, int.Parse(dateA[0]));
                        string[] dateB = b.fecha.Split("/");
                        DateTime finalDateB = new DateTime(int.Parse(dateB[2]), int.Parse(dateB[1]) - 1, int.Parse(dateB[0]));

                        Console.WriteLine(finalDateA);

                        return finalDateB.CompareTo(finalDateA);
                    });
                }
                else if (ordenarFecha == "asc")
                {
                    festival.Sort((a, b) =>
                    {
                        string[] dateA = a.fecha.Split("/");
                        DateTime finalDateA = new DateTime(int.Parse(dateA[2]), int.Parse(dateA[1]) - 1, int.Parse(dateA[0]));
                        string[] dateB = b.fecha.Split("/");
                        DateTime finalDateB = new DateTime(int.Parse(dateB[2]), int.Parse(dateB[1]) - 1, int.Parse(dateB[0]));

                        return finalDateA.CompareTo(finalDateB);
                    });
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