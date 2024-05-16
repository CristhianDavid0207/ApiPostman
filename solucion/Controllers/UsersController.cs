using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using solucion.Data;
using solucion.Models;

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
        public IActionResult ListarUsuarios()
        {
            return View(_context.user.ToList());
        }

    }
