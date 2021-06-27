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
using System.Diagnostics;

namespace Prueba03
{
    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(13, 92, 236), Color.FromArgb(42, 50, 151), 0F))
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string password = txtPassword.Text;

            if (user.Length > 2 && password.Length > 2)
            {
                using VacunaDBContext db = new VacunaDBContext();

                var listaUsuarios = db.Gestors
                    .ToList();

                var resul = listaUsuarios.Where(
                        u => u.Contrasena.Equals(password) &&
                            u.Usuario.Equals(user)
                    ).ToList();

                if (resul.Count == 0)
                    MessageBox.Show("El usuario no existe o la contrasena es incorrecta!", "Gobierno de El Salvador",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                else //iniciando sesion
                {
                    //registrando inicio de sesion
                    Registro nuevo = new Registro()
                    {
                        IdCabina = 1,
                        IdGestor = resul[0].Identificador,
                        FechaHora = DateTime.Now
                    };
                    db.Add(nuevo);
                    db.SaveChanges();

                    //Abriendo la siguiente ventana
                    Form2 ventana = new Form2(resul[0].Identificador);
                    this.Hide();
                    ventana.Show();
                }
            }
            else
                MessageBox.Show("Datos no validos! Intente de nuevo.", "Gobierno de El Salvador",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            Form5 ventana = new Form5();
            ventana.ShowDialog();
        }

        private void facebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.facebook.com/salud.sv",
                UseShellExecute = true
            });
        }

        private void twitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://twitter.com/SaludSV",
                UseShellExecute = true
            });
        }

        private void Form0_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }

}
