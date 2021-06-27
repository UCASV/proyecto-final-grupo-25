using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba03.SqlServerContext
{
    public partial class Ciudadano
    {
        public Ciudadano()
        {
            Enfermedads = new HashSet<Enfermedad>();
            Vacunas = new HashSet<Vacuna>();
        }

        public int Dui { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int? IdentificadorInst { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Enfermedad> Enfermedads { get; set; }
        public virtual ICollection<Vacuna> Vacunas { get; set; }
    }
}
