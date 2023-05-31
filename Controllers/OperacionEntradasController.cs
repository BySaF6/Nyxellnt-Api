using Microsoft.AspNetCore.Mvc;

namespace pruebaApi01.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OperacionEntradasController : ControllerBase
    {
        private readonly OperacionEntradasServiceInterface _operacionEntradas;
        public OperacionEntradasController(OperacionEntradasServiceInterface operacionEntradas)
        {
            _operacionEntradas = operacionEntradas;
        }

        // GET all action
        [HttpGet]
        public List<OperacionEntradasEntity> GetAll() => _operacionEntradas.GetAll();

        //Ordenar por fecha de compra ascendente o descendente
        [HttpGet("usuario/{idUsuario}")]
        public List<OperacionEntradasEntity> GetAll(int idUsuario, [FromQuery] string ordenarFecha)
        {
            var operacionesEntradas = _operacionEntradas.GetAll();
            operacionesEntradas = operacionesEntradas.Where(item => item.idUsuario == idUsuario).ToList();

            if (ordenarFecha != null)
            {
                if (ordenarFecha.ToLower().Equals("asc"))
                {
                    operacionesEntradas = operacionesEntradas.OrderBy(f => DateTime.Parse(f.fechaCompra)).ToList();
                }
                else if (ordenarFecha.ToLower().Equals("des"))
                {
                    operacionesEntradas = operacionesEntradas.OrderByDescending(f => DateTime.Parse(f.fechaCompra)).ToList();
                }
            }
            return operacionesEntradas;
    }

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<OperacionEntradasEntity> Get(int id)
    {
        var operacion = _operacionEntradas.Get(id);
        if (operacion == null)
            return NotFound();

        return operacion;
    }

    // POST action
    [HttpPost]
    public ActionResult Create(OperacionEntradasEntity operacionEntradasEntity)
    {
        _operacionEntradas.Add(operacionEntradasEntity);
        return CreatedAtAction(nameof(Get), new { id = operacionEntradasEntity.idOperacionEntradas }, operacionEntradasEntity);
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var operacionEntradasEntity = _operacionEntradas.Get(id);

        if (operacionEntradasEntity is null)
            return NotFound();

        _operacionEntradas.Delete(id);
        return NoContent();
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(OperacionEntradasEntity operacionEntradasEntity)
    {
        _operacionEntradas.Update(operacionEntradasEntity);
        return NoContent();
    }
}
}