using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba03.SqlServerContext
{
    public partial class EfectoSec
    {
        public EfectoSec()
        {
            RegistroEfectos = new HashSet<RegistroEfecto>();
        }

        public int Id { get; set; }
        public string EfectoSec1 { get; set; }

        public virtual ICollection<RegistroEfecto> RegistroEfectos { get; set; }
    }
}
