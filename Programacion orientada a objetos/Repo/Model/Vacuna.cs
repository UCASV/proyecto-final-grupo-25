using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba03.SqlServerContext
{
    public partial class Vacuna
    {
        public Vacuna()
        {
            RegistroEfectos = new HashSet<RegistroEfecto>();
        }

        public int Id { get; set; }
        public int IdTipoVacuna { get; set; }
        public int IdCabina { get; set; }
        public int IdGestor { get; set; }
        public int IdCiudadano { get; set; }
        public DateTime? CitaFechaHora { get; set; }
        public DateTime? ColaFechaHora { get; set; }
        public DateTime? VacunaFechaHora { get; set; }

        public virtual Cabina IdCabinaNavigation { get; set; }
        public virtual Ciudadano IdCiudadanoNavigation { get; set; }
        public virtual Gestor IdGestorNavigation { get; set; }
        public virtual TipoVacuna IdTipoVacunaNavigation { get; set; }
        public virtual ICollection<RegistroEfecto> RegistroEfectos { get; set; }
    }
}
