using Microsoft.AspNetCore.Mvc;

namespace pruebaApi01.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OperacionEntradasController : ControllerBase
    {
        private readonly OperacionEntradasServiceInterface _operacionEntradas;
        private readonly ILogger<OperacionEntradasController> _logger;
        public OperacionEntradasController(OperacionEntradasServiceInterface operacionEntradas)
        {
            _operacionEntradas = operacionEntradas;
        }

        // GET all action
        [HttpGet]
        public List<OperacionEntradasEntity> GetAll() => _operacionEntradas.GetAll();

        //Ordenar por fecha de compra ascendente o descendente
        [HttpGet("usuario/{idUsuario}")]
        public List<OperacionEntradasEntity> GetAll(int idUsuario, [FromQuery] string ordenarPrecio, [FromQuery] string ordenarFecha)
        {
            var operacionesEntradas = _operacionEntradas.GetAll();
            operacionesEntradas = operacionesEntradas.Where(item => item.idUsuario == idUsuario).ToList();

            if(ordenarPrecio != null){
                if(ordenarPrecio.ToLower().Equals("asc"))
                {
                    operacionesEntradas = operacionesEntradas.OrderBy(item => item.precioTotalEntradas).ToList();
                }
                else if(ordenarPrecio.ToLower().Equals("des"))
                {
                    operacionesEntradas = operacionesEntradas.OrderByDescending(item => item.precioTotalEntradas).ToList();
                }
            } else if (ordenarFecha != null)
            {
                if (ordenarFecha == "des")
                {
                    operacionesEntradas.Sort((a, b) =>
                    {
                        string[] dateA = a.fechaCompra.Split("/");
                        DateTime finalDateA = new DateTime(int.Parse(dateA[2]), int.Parse(dateA[1]) - 1, int.Parse(dateA[0]));
                        string[] dateB = b.fechaCompra.Split("/");
                        DateTime finalDateB = new DateTime(int.Parse(dateB[2]), int.Parse(dateB[1]) - 1, int.Parse(dateB[0]));

                        Console.WriteLine(finalDateA);

                        return finalDateB.CompareTo(finalDateA);
                    });
                }
                else if (ordenarFecha == "asc")
                {
                    operacionesEntradas.Sort((a, b) =>
                    {
                        string[] dateA = a.fechaCompra.Split("/");
                        DateTime finalDateA = new DateTime(int.Parse(dateA[2]), int.Parse(dateA[1]) - 1, int.Parse(dateA[0]));
                        string[] dateB = b.fechaCompra.Split("/");
                        DateTime finalDateB = new DateTime(int.Parse(dateB[2]), int.Parse(dateB[1]) - 1, int.Parse(dateB[0]));

                        return finalDateA.CompareTo(finalDateB);
                    });
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