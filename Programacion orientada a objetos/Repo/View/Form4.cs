using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Prueba03.SqlServerContext;       

namespace Prueba03
{
    public partial class Form4 : Form
    {
        private int idVacuna { get; set; }
        private int idGestor { get; set; }

        public Form4(int idVacuna, int idGestor)
        {
            InitializeComponent();
            this.idVacuna = idVacuna;
            this.idGestor = idGestor;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(13, 92, 236), Color.FromArgb(42, 50, 151), 0F))
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            using VacunaDBContext db = new VacunaDBContext();

            //poblando la lista de efectos secundarios
            List<EfectoSec> listaEfectos = db.EfectoSecs
                .ToList();
            cmbEfectos.DataSource = listaEfectos;
            cmbEfectos.DisplayMember = "EfectoSec1";
            cmbEfectos.ValueMember = "Id";

            //obteniendo los datos de Vacuna
            var listaVacuna = db.Vacunas
                .OrderBy(v => v.IdTipoVacuna)
                .ToList();
            var resu = listaVacuna.Where(
                    v => v.Id.Equals(idVacuna)
                ).ToList();

            //verificando el tipo de vacuna
            if (resu[0].IdTipoVacuna == 2)
            {
                lbl2daCita.Hide();
                btnProgramar.Hide();
                pickerDate.Hide();
            }
            lblCola.Text = "";
            lblVacunado.Text = "";
            pickerDate.MinDate = DateTime.Today;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Form3 ventana = new Form3(idGestor);
            this.Close();
            ventana.Show();
        }

        private void btnCola_Click(object sender, EventArgs e)
        {
            using VacunaDBContext db = new VacunaDBContext();

            //obteniendo vacuna
            var vac = db.Set<Vacuna>()
                .SingleOrDefault(v => v.Id == idVacuna);

            if (vac.ColaFechaHora.HasValue)
            {
                MessageBox.Show("Dato ya se ingresado!", "Gobierno de El Salvador",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblCola.Text = vac.ColaFechaHora.Value.ToString();
            }
            else
            {
                vac.ColaFechaHora = DateTime.Now;
                db.SaveChanges();
                MessageBox.Show("Dato ingresado correctamente.", "Gobierno de El Salvador",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblCola.Text = vac.ColaFechaHora.Value.ToString();
            }
        }
        private void btnVacuando_Click(object sender, EventArgs e)
        {
            using VacunaDBContext db = new VacunaDBContext();

            //obteniendo vacuna
            var vac = db.Set<Vacuna>()
                .SingleOrDefault(v => v.Id == idVacuna);

            if (vac.VacunaFechaHora.HasValue)
            {
                MessageBox.Show("Dato ya se ingresado!", "Gobierno de El Salvador",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblVacunado.Text = vac.VacunaFechaHora.Value.ToString();
            }
            else
            {
                vac.VacunaFechaHora = DateTime.Now;
                db.SaveChanges();
                MessageBox.Show("Dato ingresado correctamente.", "Gobierno de El Salvador",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblVacunado.Text = vac.VacunaFechaHora.Value.ToString();
            }
        }

        private void btnEfecto_Click(object sender, EventArgs e)
        {
            using VacunaDBContext db = new VacunaDBContext();

            RegistroEfecto nuevo = new RegistroEfecto()
            {
                IdEfectoSec = ((EfectoSec)cmbEfectos.SelectedItem).Id,
                IdVacuna = idVacuna,
                FechaHora = DateTime.Now
            };

            db.RegistroEfectos.Add(nuevo);
            db.SaveChanges();
            MessageBox.Show("Dato ingresado correctamente.", "Gobierno de El Salvador",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnProgramar_Click(object sender, EventArgs e)
        {
            using VacunaDBContext db = new VacunaDBContext();

            //obteniendo vacuna1
            var vac1 = db.Set<Vacuna>()
                .SingleOrDefault(v => v.Id == idVacuna);

            if (vac1.VacunaFechaHora.HasValue && vac1.ColaFechaHora.HasValue)
            {
                //creando vacuna2
                Vacuna vac2 = new Vacuna()
                {
                    IdTipoVacuna = 2,
                    IdCabina = vac1.IdCabina,
                    IdGestor = idGestor,
                    IdCiudadano = vac1.IdCiudadano,
                    CitaFechaHora = pickerDate.Value,
                    ColaFechaHora = null,
                    VacunaFechaHora = null
                };

                db.Add(vac2);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Debe el inicio de cola y momento de vacunacion!", "Gobierno de El Salvador",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
