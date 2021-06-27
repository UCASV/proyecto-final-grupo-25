using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba03.SqlServerContext
{
    public partial class Enfermedad
    {
        public int Id { get; set; }
        public int IdCiudadano { get; set; }
        public string EnfermedadCronica { get; set; }

        public virtual Ciudadano IdCiudadanoNavigation { get; set; }
    }
}
