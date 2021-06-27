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
    public partial class Form3 : Form
    {
        private int idVacuna = 0;
        private string statusMsg = "";
        private int idGestor { get; set; }
        public Form3(int idGestor)
        {
            InitializeComponent();
            this.idGestor = idGestor;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(13, 92, 236), Color.FromArgb(42, 50, 151), 0F))
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        private void limpiarCampos()
        {
            lblNombre.Text = "";
            lblNacimiento.Text = "";
            lblDireccion.Text = "";
            lblStatus1.Text = "";
            lblDate1.Text = "";
            lblStatus2.Text = "";
            lblDate2.Text = "";
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            statusMsg = "";

            int temp = 0;
            if (int.TryParse(txtDui.Text, out temp)) //verificando datos de dui sean validos
            {
                int dui = Convert.ToInt32(txtDui.Text);
                
                using VacunaDBContext db = new VacunaDBContext();

                var listaVacuna = db.Vacunas
                    .OrderBy(v => v.IdTipoVacuna)
                    .ToList();
                var resu = listaVacuna.Where(
                        v => v.IdCiudadano.Equals(dui)
                    ).ToList();

                if (resu.Count == 0) //ninguna vacuna(cita)
                {
                    MessageBox.Show("El ciudadano no tiene cita programada", "Gobierno de El Salvador",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpiarCampos();
                    txtDui.Text = "";
                }
                else if (resu.Count == 1) //existe una vacuna(cita) esta en resu[0]
                {
                    //info de ciudadano
                    Ciudadano cbd = db.Set<Ciudadano>()
                    .Where(c => c.Dui == dui)
                    .FirstOrDefault();
                    lblNombre.Text = cbd.Nombre;
                    lblNacimiento.Text = cbd.FechaNacimiento.Date.ToString("d"); //formato 20-Jul-74

                    //info de lugar de vacunacion
                    Cabina cabd = db.Set<Cabina>()
                        .Where(ca => ca.Id == resu[0].IdCabina)
                        .FirstOrDefault();
                    lblDireccion.Text = cabd.Direccion;

                    if (resu[0].VacunaFechaHora.HasValue) // existe una cita(vacuna) y ya se ha vacunado
                    {
                        lblStatus1.Text = "Vacunado en:";
                        lblDate1.Text = resu[0].VacunaFechaHora.Value.ToString();
                        statusMsg = "No se tiene programada la Segundo Dosis!";
                    }
                    else // existe una cita(vacuna) pero no se ha puesto la vacuna
                    {
                        lblStatus1.Text = "Programada para:";
                        lblDate1.Text = resu[0].CitaFechaHora.Value.ToString();
                        idVacuna = resu[0].Id;
                    }                

                }
                else //dos vacunas(citas) [0] [1]
                {
                    //info de ciudadano
                    Ciudadano cbd = db.Set<Ciudadano>()
                    .Where(c => c.Dui == dui)
                    .FirstOrDefault();
                    lblNombre.Text = cbd.Nombre;
                    lblNacimiento.Text = cbd.FechaNacimiento.Date.ToString("d");

                    //info de lugar de vacunacion
                    Cabina cabd = db.Set<Cabina>()
                        .Where(ca => ca.Id == resu[1].IdCabina) //ojo se usa el lugar de la segunda
                        .FirstOrDefault();
                    lblDireccion.Text = cabd.Direccion;

                    if (resu[1].VacunaFechaHora.HasValue) // ya tiene las dos vacunas
                    {
                        lblStatus1.Text = "Vacunado en:";
                        lblDate1.Text = resu[0].VacunaFechaHora.Value.ToString();
                        lblStatus2.Text = "Vacunado en:";
                        lblDate2.Text = resu[1].VacunaFechaHora.Value.ToString();
                        statusMsg = "El ciudadano ya tiene las dos vacunas!";
                    }
                    else // exiten dos citas(vacunas) pero le falta ponerse la ultima
                    {
                        lblStatus1.Text = "Vacunado en:";
                        lblDate1.Text = resu[0].VacunaFechaHora.Value.ToString();
                        lblStatus2.Text = "Programada para:";
                        lblDate2.Text = resu[1].CitaFechaHora.Value.ToString();
                        idVacuna = resu[1].Id;
                    }
                }

            }
            else //dui no valido
            {
                limpiarCampos();
                txtDui.Text = "";
                MessageBox.Show("Dato no valido! Intente ingresar el DUI sin guion", "Gobierno de El Salvador",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bttn3frm4_Click(object sender, EventArgs e)
        {

            if (statusMsg.Length > 0)
                MessageBox.Show(statusMsg, "Gobierno de El Salvador",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (idVacuna > 0)
                {
                    Form4 ventana = new Form4(idVacuna, idGestor);
                    this.Hide();
                    ventana.Show();
                }
                else
                    MessageBox.Show("Se tiene que validar el DUI del ciudadano!", "Gobierno de El Salvador",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form2 ventana = new Form2(idGestor);
            this.Close();
            ventana.Show();
        }
    }
}
