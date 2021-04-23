using Microsoft.EntityFrameworkCore;
using projetoarquitetura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetoarquitetura.Interfaces
{
    public interface IServiceUsuario  
    {
        public string HashValue(string value);
  

    }
}
