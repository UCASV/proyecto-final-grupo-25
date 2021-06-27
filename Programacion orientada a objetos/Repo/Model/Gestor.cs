using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba03.SqlServerContext
{
    public partial class Gestor
    {
        public Gestor()
        {
            Registros = new HashSet<Registro>();
            Vacunas = new HashSet<Vacuna>();
        }

        public int Identificador { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public int IdTipoEmpleado { get; set; }
        public int? IdCabinaAdmin { get; set; }

        public virtual Cabina IdCabinaAdminNavigation { get; set; }
        public virtual TipoEmpleado IdTipoEmpleadoNavigation { get; set; }
        public virtual ICollection<Registro> Registros { get; set; }
        public virtual ICollection<Vacuna> Vacunas { get; set; }
    }
}
