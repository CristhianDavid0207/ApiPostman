using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solucion.Models;
using solucion.Data;

namespace solucion.Controllers;
    [Route("api/[Controller]")]
    [ApiController]
    
    public class UsersController : Controller
    {
        private readonly BaseContext _context;
        public UsersController (BaseContext context)
        {
            _context = context;
        }


        //Listado de todos los usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> ListarUsuarios()
        {
            return await _context.users.ToListAsync();
        }

        //Detalles de un usuario en especifico
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> UsuarioId(int id)
        {
            var user = await _context.users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }


        //Crear Usuario
        [HttpPost]
        public async Task<ActionResult<User>> CrearUsuario(User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new {id = user.Id}, user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> EliminarUsuario(int id)
        {
            var user = await _context.users.FindAsync(id);

            if(user == null)
            {
                return NotFound();
            }

            _context.users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent(); 
        }

        //Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> ActualizarUsuario(int id, User user)
        {
            var usuario = await _context.users.FindAsync(id);
            if(usuario == null)
            {
                return NotFound();
            }
            
            _context.Entry(user).State = EntityState.Modified; //Entry= busacar en el modelo y sobreescribe state= cambio el estado pero no se almacenado Entitystate.Modifi= modifica
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new {id = user.Id}, user);

        }


    }


