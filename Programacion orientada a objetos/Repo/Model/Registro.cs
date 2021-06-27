using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba03.SqlServerContext
{
    public partial class Registro
    {
        public int Id { get; set; }
        public int IdCabina { get; set; }
        public int IdGestor { get; set; }
        public DateTime FechaHora { get; set; }

        public virtual Cabina IdCabinaNavigation { get; set; }
        public virtual Gestor IdGestorNavigation { get; set; }
    }
}
