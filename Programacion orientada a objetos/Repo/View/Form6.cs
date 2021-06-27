using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prueba03.SqlServerContext;

namespace Prueba03
{
    public partial class Form6 : Form
    {
        private int idGestor { get; set; }
        public Form6(int idGestor)
        {
            InitializeComponent();
            this.idGestor = idGestor;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(13, 92, 236), Color.FromArgb(42, 50, 151), 0F))
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            using VacunaDBContext db = new VacunaDBContext();

            var listaVacuna = db.Vacunas
                    .OrderBy(v => v.IdTipoVacuna)
                    .ToList();
            var listaPrimeraDosis = listaVacuna.Where(
                    v => v.IdTipoVacuna.Equals(1)
                ).ToList();
            var listaSegundaDosis = listaVacuna.Where(
                    v => v.IdTipoVacuna.Equals(2)
                ).ToList();

            int total1dosis = listaPrimeraDosis.Count;
            int total2dosis = listaSegundaDosis.Count;

            lbl1.Text = total1dosis.ToString();
            lbl2.Text = total2dosis.ToString();

            List<double> tiempos = new List<double>();
            int[] array = new int[4];

            foreach (Vacuna v in listaVacuna)
            {
                if (v.VacunaFechaHora.HasValue)
                {
                    TimeSpan ts = (TimeSpan)(v.VacunaFechaHora - v.ColaFechaHora);
                    tiempos.Add(ts.TotalMinutes);
                    if (ts.TotalMinutes > 60)
                        array[3]++;
                    else if (ts.TotalMinutes > 30)
                        array[2]++;
                    else if (ts.TotalMinutes > 15)
                        array[1]++;
                    else
                        array[0]++;
                }
            }

            lblt4.Text = array[3].ToString();
            lblt3.Text = array[2].ToString();
            lblt2.Text = array[1].ToString();
            lblt1.Text = array[0].ToString();

            var listaRegistro = db.RegistroEfectos
                .OrderBy(r => r.IdEfectoSec)
                .ToList();

            int[] cuenta = new int[8];
            for (int i = 0; i < 8; i++)
                cuenta[i] = listaRegistro.Count(r => r.IdEfectoSec.Equals(i));

            var listaEfectos = db.EfectoSecs
                .OrderBy(e => e.Id)
                .ToList();

            lbln1.Text = listaEfectos[0].EfectoSec1;
            lbln2.Text = listaEfectos[1].EfectoSec1;
            lbln3.Text = listaEfectos[2].EfectoSec1;
            lbln4.Text = listaEfectos[3].EfectoSec1;
            lbln5.Text = listaEfectos[4].EfectoSec1;
            lbln6.Text = listaEfectos[5].EfectoSec1;
            lbln7.Text = listaEfectos[6].EfectoSec1;
            lbln8.Text = listaEfectos[7].EfectoSec1;

            lblc1.Text = cuenta[0].ToString();
            lblc2.Text = cuenta[1].ToString();
            lblc3.Text = cuenta[2].ToString();
            lblc4.Text = cuenta[3].ToString();
            lblc5.Text = cuenta[4].ToString();
            lblc6.Text = cuenta[5].ToString();
            lblc7.Text = cuenta[6].ToString();
            lblc8.Text = cuenta[7].ToString();

            lbltpromedio.Text = Math.Round(tiempos.Average(), 2).ToString();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 ventana = new Form2(idGestor);
            this.Close();
            ventana.Show();
        }

        private void lbltpromedio_Click(object sender, EventArgs e)
        {

        }
    }
}
