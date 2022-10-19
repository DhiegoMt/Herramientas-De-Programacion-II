using api_autores.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_autores.Controllers
{
    //Indicamos que es un controlador
    [ApiController]
    //Es definir la ruta de acceso al controlador
    [Route("api_autores/autor")]

    //: ControllerBase es una herencia para que sea un controlador
    public class AutorControllers : ControllerBase
    {
        private readonly ApplicationDBContext context;

        //creamos el metodo constructos
        public AutorControllers(ApplicationDBContext context)
        {
            this.context = context;
        }

        // Cuando queremos obtener informacion
        [HttpGet]
        public async Task<ActionResult<List<Autor>>> findAll()
        {
            return await context.Autor.ToListAsync();
        }

        // Cuando queremos obtener solo los habilitados
        [HttpGet("custom")]
        public async Task<ActionResult<List<Autor>>> findAllCustom()
        {
            return await context.Autor.Where(x=> x.estado == true).ToListAsync(); //Cambiar estado(traer true o false)
        }



        //cuando queremos guardar informacion
        [HttpPost]
        public async Task<ActionResult> add(Autor a)
        {
            context.Add(a);
            await context.SaveChangesAsync();
            return Ok();
        }

        // Cuando queremos buscar informacion
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Autor>> findById(int id)
        {
            var autor = await context.Autor.
                FirstOrDefaultAsync(x => x.codigoautor == id);
            return autor;
        }

        //Cuando queremos actualizar informacion
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(Autor a, int id)
        {
            if (a.codigoautor != id)
            {
                return BadRequest("No se encuentra el codigo correspondiente");
            }
            context.Update(a);
            await context.SaveChangesAsync();
            return Ok();
        }

        //Cuando queremos eliminar informacion   (BORRA DE LA BASE DE DATOS)
        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult> delete(int id)
        //{
        //    var exite = await context.Autor.AnyAsync(x => x.codigo == id);
        //    if (!exite)
        //    {
        //        return NotFound();
        //    }

        //    context.Remove(new Autor(){ codigo = id });
        //    await context.SaveChangesAsync();
        //    return Ok();
        //}

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> delete(int id)
        {
            var exite = await context.Autor.AnyAsync(x => x.codigoautor == id);
            if (!exite)
            {
                return NotFound();
            }
            var autor = await context.Autor.FirstOrDefaultAsync(x => x.codigoautor == id);
            autor.estado = false;
            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
