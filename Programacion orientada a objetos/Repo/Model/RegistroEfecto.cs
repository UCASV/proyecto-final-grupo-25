using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba03.SqlServerContext
{
    public partial class RegistroEfecto
    {
        public int Id { get; set; }
        public int IdEfectoSec { get; set; }
        public int IdVacuna { get; set; }
        public DateTime? FechaHora { get; set; }

        public virtual EfectoSec IdEfectoSecNavigation { get; set; }
        public virtual Vacuna IdVacunaNavigation { get; set; }
    }
}
