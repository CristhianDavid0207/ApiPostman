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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> ListarUsuarios()
        {
            return await _context.users.ToListAsync();
        }

    }


