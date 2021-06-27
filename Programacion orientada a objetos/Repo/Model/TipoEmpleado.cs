using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba03.SqlServerContext
{
    public partial class TipoEmpleado
    {
        public TipoEmpleado()
        {
            Gestors = new HashSet<Gestor>();
        }

        public int Id { get; set; }
        public string TipoEmpleado1 { get; set; }

        public virtual ICollection<Gestor> Gestors { get; set; }
    }
}
