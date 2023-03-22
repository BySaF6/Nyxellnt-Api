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
        [HttpGet("usuario/{idUsuario}")]
        public List<OperacionEntity> GetAll(int idUsuario, [FromQuery] string ordenarFecha)
        {
            var operaciones = _operacion.GetAll();
            operaciones = operaciones.Where(item => item.idUsuario == idUsuario).ToList();

            if (ordenarFecha != null)
            {
                if (ordenarFecha.ToLower().Equals("asc"))
                {
                    operaciones = operaciones.OrderBy(f => DateTime.Parse(f.fechaCompra)).ToList();
                }
                else if (ordenarFecha.ToLower().Equals("des"))
                {
                    operaciones = operaciones.OrderByDescending(f => DateTime.Parse(f.fechaCompra)).ToList();
                }
            }
            return operaciones;
    }

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<OperacionEntity> Get(int id)
    {
        var operacion = _operacion.Get(id);
        if (operacion == null)
            return NotFound();

        return operacion;
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