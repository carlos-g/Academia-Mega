using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;

[ApiController]
[ApiVersion("1.0")]
[Route("api/[controller]")]  //api/productos

public class ProductosController : ControllerBase
{
    // Aqui seria la lectura de datos en BD
    public static readonly List<Producto> _datos = new()
    {
        new Producto {id = 1, Nombre = "iPhone 16", Precio = 20000.0m},
        new Producto {id = 2, Nombre = "Galazi S25 Edge", Precio = 18000.0m}
    };


    //create
    [HttpPost]  // POST /api/productos
    public ActionResult<Producto> Create(Producto nuevo)
    {
        nuevo.id = _datos.Max(p => p.id) + 1;
        _datos.Add(nuevo);
        return CreatedAtAction(nameof(GetById), new { id = nuevo.id }, nuevo);
    }

    // read
    [HttpGet]  // GET /api/productos
    public ActionResult<IEnumerable<Producto>> GetAll()
    {
        return Ok(_datos);
    }

    [HttpGet("{id}")] // GET /api/productos/1

    public ActionResult<Producto> GetById(int id)
    {
        var product = _datos.FirstOrDefault(p => p.id == id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    //update
    [HttpPut("{id}")]  // put /api/productos/1
    public IActionResult Update(int id, Producto actualizado)
    {
        var producto = _datos.FirstOrDefault(p => p.id == id);
        if (producto == null) return NotFound();

        producto.Nombre = actualizado.Nombre;
        producto.Precio = actualizado.Precio;

        return NoContent();
    }

    // delete   
    [HttpDelete("{id}")] // delete/api/productos/1
    public IActionResult Delete(int id)
    {
        var producto = _datos.FirstOrDefault(p => p.id == id);
        if (producto == null) return NotFound();

        _datos.Remove(producto);
        return Ok("El valor se ha eliminado correcatmente");

    }

}

// Modelo producto
public class Producto
{
    public int id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
}