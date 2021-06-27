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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(13, 92, 236), Color.FromArgb(42, 50, 151), 0F))
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            using VacunaDBContext db = new VacunaDBContext();

            List<TipoEmpleado> tipos = db.TipoEmpleados
                .ToList();

            cmbType.DataSource = tipos;
            cmbType.DisplayMember = "TipoEmpleado1";
            cmbType.ValueMember = "Id";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            bool verificar = txtUser.Text.Length > 3 &&
                            txtPass.Text.Length > 3 &&
                            txtPass2.Text.Length > 3 &&
                            txtName.Text.Length > 3 &&
                            txtEmail.Text.Length > 3 &&
                            txtAddress.Text.Length > 3;

            if (verificar)
            {
                if (txtPass.Text == txtPass2.Text) //verificando campos passwors
                {
                    using VacunaDBContext db = new VacunaDBContext();

                    var listaGestor = db.Gestors
                        .ToList();
                    var resu = listaGestor.Where(
                            g => g.Usuario.Equals(txtUser.Text)
                        ).ToList();

                    if (resu.Count > 0 ) //ya exite un usuario del Gestor
                        MessageBox.Show("El usuario ya existe", "Gobierno de El Salvador",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    else //se puede crear el Gestor
                    {
                        Gestor nuevo = new Gestor()
                        {
                            Identificador = listaGestor.Count + 86001,
                            Usuario = txtUser.Text,
                            Contrasena = txtPass.Text,
                            Nombre = txtName.Text,
                            Email = txtEmail.Text,
                            Direccion = txtAddress.Text,
                            IdTipoEmpleado = ((TipoEmpleado)cmbType.SelectedItem).Id
                        };

                        db.Add(nuevo);
                        db.SaveChanges();

                        MessageBox.Show("Usuario creado exitosamente!", "Gobierno de El Salvador",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }                        
                }
                else //en caso no sea igual ambos password nuevos
                    MessageBox.Show("La contrasena no es igual en ambos campos!", "Gobierno de El Salvador",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else //en caso en que los forms no tengas info
                MessageBox.Show("Por favor complete todo los campos.", "Gobierno de El Salvador",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
