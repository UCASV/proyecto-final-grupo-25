using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba03.SqlServerContext
{
    public partial class TipoVacuna
    {
        public TipoVacuna()
        {
            Vacunas = new HashSet<Vacuna>();
        }

        public int Id { get; set; }
        public string TipoVacuna1 { get; set; }

        public virtual ICollection<Vacuna> Vacunas { get; set; }
    }
}
