using Microsoft.AspNetCore.Mvc;

namespace pruebaApi01.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OperacionMerchandisingController : ControllerBase
    {
        private readonly OperacionMerchandisingServiceInterface _operacionMerchandising;
        private readonly ILogger<OperacionMerchandisingController> _logger;
        public OperacionMerchandisingController(OperacionMerchandisingServiceInterface operacionMerchandising)
        {
            _operacionMerchandising = operacionMerchandising;
        }

        // GET all action
        [HttpGet]
        public List<OperacionMerchandisingEntity> GetAll() => _operacionMerchandising.GetAll();

        //Ordenar por fecha de compra ascendente o descendente
        [HttpGet("usuario/{idUsuario}")]
        public List<OperacionMerchandisingEntity> GetAll(int idUsuario, [FromQuery] string ordenarFecha)
        {
            var operacionesMerchandising = _operacionMerchandising.GetAll();
            operacionesMerchandising = operacionesMerchandising.Where(item => item.idUsuario == idUsuario).ToList();

            if (ordenarFecha != null)
            {
                if (ordenarFecha.ToLower().Equals("asc"))
                {
                    operacionesMerchandising = operacionesMerchandising.OrderBy(f => DateTime.Parse(f.fechaCompra)).ToList();
                }
                else if (ordenarFecha.ToLower().Equals("des"))
                {
                    operacionesMerchandising = operacionesMerchandising.OrderByDescending(f => DateTime.Parse(f.fechaCompra)).ToList();
                }
            }
            return operacionesMerchandising;
    }

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<OperacionMerchandisingEntity> Get(int id)
    {
        var operacion = _operacionMerchandising.Get(id);
        if (operacion == null)
            return NotFound();

        return operacion;
    }

    // POST action
    [HttpPost]
    public ActionResult Create(OperacionMerchandisingEntity operacionMerchandisingEntity)
    {
        _operacionMerchandising.Add(operacionMerchandisingEntity);
        return CreatedAtAction(nameof(Get), new { id = operacionMerchandisingEntity.idOperacionMerchandising }, operacionMerchandisingEntity);
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var operacionMerchandisingEntity = _operacionMerchandising.Get(id);

        if (operacionMerchandisingEntity is null)
            return NotFound();

        _operacionMerchandising.Delete(id);
        return NoContent();
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(OperacionMerchandisingEntity operacionMerchandisingEntity)
    {
        _operacionMerchandising.Update(operacionMerchandisingEntity);
        return NoContent();
    }


}
}