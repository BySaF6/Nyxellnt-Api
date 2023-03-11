using Microsoft.AspNetCore.Mvc;

namespace pruebaApi01.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OperacionController : ControllerBase
    {
        private readonly OperacionServiceInterface _operacion;
        public OperacionController(OperacionServiceInterface operacion)
        {
            _operacion = operacion;
        }

        // GET all action
        [HttpGet]
        public List<OperacionEntity> GetAll() => _operacion.GetAll();

        //Ordenar por fecha de compra ascendente o descendente
        [HttpGet("ordenarFecha/{ascendente}")]
        public List<OperacionEntity> GetAll(Boolean ascendente) {
            var operaciones = _operacion.GetAll();
            if(ascendente == true){
                return operaciones.OrderBy(f => DateTime.Parse(f.fechaCompra)).ToList(); 
            } else {
                return operaciones.OrderByDescending(f => DateTime.Parse(f.fechaCompra)).ToList();
            }
        }
        
        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<OperacionEntity> Get(int id)
        {
            var evento = _operacion.Get(id);
            if (evento == null)
                return NotFound();

            return evento;
        }

        // POST action
        [HttpPost]
        public ActionResult Create(OperacionEntity operacionEntity)
        {
            _operacion.Add(operacionEntity);
            return CreatedAtAction(nameof(Get), new { id = operacionEntity.idOperacion }, operacionEntity);
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var operacionEntity = _operacion.Get(id);

            if (operacionEntity is null)
                return NotFound();

            _operacion.Delete(id);
            return NoContent();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(OperacionEntity operacionEntity)
        {
            _operacion.Update(operacionEntity);
            return NoContent();
        }


    }
}