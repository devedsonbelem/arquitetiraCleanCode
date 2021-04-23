using Microsoft.EntityFrameworkCore;
using projetoarquitetura.Interfaces;
using projetoarquitetura.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace projetoarquitetura.Repositorys
{
    public class UsuarioContext : DbContext 
    {

        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios{get; set; }
 
       
    }
}
