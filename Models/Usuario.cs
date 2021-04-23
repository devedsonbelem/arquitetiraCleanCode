using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projetoarquitetura.Models
{
    [Table("usuarios")]
    public class Usuario
    {   [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        public string Nome { set; get; }

        public string Email { set; get; }

        public string Senha { set; get; }



    }
}
