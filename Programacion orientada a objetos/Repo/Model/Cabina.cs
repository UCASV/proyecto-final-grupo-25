using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba03.SqlServerContext
{
    public partial class Cabina
    {
        public Cabina()
        {
            Gestors = new HashSet<Gestor>();
            Registros = new HashSet<Registro>();
            Vacunas = new HashSet<Vacuna>();
        }

        public int Id { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Gestor> Gestors { get; set; }
        public virtual ICollection<Registro> Registros { get; set; }
        public virtual ICollection<Vacuna> Vacunas { get; set; }
    }
}
