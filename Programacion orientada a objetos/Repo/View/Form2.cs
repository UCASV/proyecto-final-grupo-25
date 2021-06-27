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

namespace Prueba03
{
    public partial class Form2 : Form
    {
        private int idGestor { get; set; }
        public Form2(int idGestor)
        {
            InitializeComponent();
            this.idGestor = idGestor;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(13, 92, 236), Color.FromArgb(42, 50, 151), 0F))
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        private void btnVerCita_Click(object sender, EventArgs e)
        {
            Form3 ventana = new Form3(idGestor);
            this.Hide();
            ventana.Show();
        }

        private void btnEstadistica_Click(object sender, EventArgs e)
        {
            Form6 ventana2 = new Form6(idGestor);
            this.Hide();
            ventana2.Show();
        }

        private void bttn1_Click(object sender, EventArgs e)
        {
            Form1 ventana1 = new Form1(idGestor: idGestor);
            this.Hide();
            ventana1.Show();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
