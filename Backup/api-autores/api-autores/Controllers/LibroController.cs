using api_autores.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_autores.Controllers
{

    [ApiController]
    [Route("api_autores/libro")]
    public class LibroController : ControllerBase
    {
        private readonly ApplicationDBContext context;

        public LibroController(ApplicationDBContext context)
        {
            this.context = context;
        }

        // Cuando queremos obtener informacion
        [HttpGet]
        public async Task<ActionResult<List<Libro>>> findAll()
        {
            return await context.Libro.Include(x => x.autor).ToListAsync();
        }


        // Cuando queremos obtener solo los habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<Libro>>> findAllCustom()
        {
            return await context.Libro.Include(x => x.autor).Where(x => x.estado == true).ToListAsync(); //Cambiar estado(traer true o false)
        }


        //cuando queremos guardar informacion
        [HttpPost]
        public async Task<ActionResult> add(Libro lb)
        {
            //Verificando existencia del autor
            var autorexiste = await context.Autor.AnyAsync(x => x.codigoautor == lb.codigoautor);

            if (!autorexiste)
            {
                return BadRequest($"No existe el autor con el código: {lb.codigoautor}");
            }
            context.Add(lb);
            await context.SaveChangesAsync();
            return Ok();
        }



        // Cuando queremos buscar informacion
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> findById(int id)
        {
            var libro = await context.Libro.
                FirstOrDefaultAsync(x => x.codigolibro == id);
            return libro;
        }


        //Cuando queremos actualizar informacion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(Libro lb, int id)
        {
            if (lb.codigolibro != id)
            {
                return BadRequest("No se encuentra el codigo correspondiente");
            }
            context.Update(lb);
            await context.SaveChangesAsync();
            return Ok();
        }




        [HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id)
        {
            var existe = await context.Libro.AnyAsync(x => x.codigolibro == id);
            if (!existe)
            {
                return NotFound();
            }
            var libro = await context.Libro.FirstOrDefaultAsync(x => x.codigolibro == id);
            libro.estado = false;
            context.Update(libro);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
