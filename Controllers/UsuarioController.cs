using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using projetoarquitetura.Interfaces;
using projetoarquitetura.Models;
using projetoarquitetura.Repositorys;
using projetoarquitetura.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace projetoarquitetura.Controllers
{
    [ApiController]
    [Route("api")]
    public class UsuarioController : Controller
    {
 
        private  readonly UsuarioContext _context;
        private  ServiceUsuario _service ; 
        public UsuarioController(UsuarioContext context)
        {
            this._context = context;
            this._service = new ServiceUsuario();
        }
      

        [HttpGet("find")]
        public async Task<ActionResult> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return Ok(usuarios);
        }




        [HttpPost("salvar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] Usuario usuario)
        {

            if (usuario.Nome.Contains("belem"))
            {
                return BadRequest();
            }

            usuario.Senha =  this._service.HashValue(usuario.Senha);
             
   
                 _context.Add(usuario);
                 await _context.SaveChangesAsync();

            Dictionary<string, object> mapa= new Dictionary<string, object>
            {
              { "usuario", usuario},
              { "status", "objeto criado" },
            };

            string json = JsonConvert.SerializeObject(mapa, Formatting.Indented);

            return Ok(mapa);
        }

        [Route("{id:int}/usuarios")]
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            Usuario usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }


       


    }
}
   

