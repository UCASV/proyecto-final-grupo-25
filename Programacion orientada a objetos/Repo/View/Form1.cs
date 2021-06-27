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
    public partial class Form1 : Form
    {
        private int idGestor { get; set; }

        public Form1(int idGestor)
        {
            InitializeComponent();
            this.idGestor = idGestor;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(13, 92, 236), Color.FromArgb(42, 50, 151), 0F))
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool duiVef = true, institutionVef = true;

            if (duiVerification(successOrNot: duiVef) && institutionVerification(successOrNot: institutionVef))
            {
                int dui = int.Parse(txtBox1.Text);
                int idInstitution = int.Parse(txtBox7.Text);

                var VaccineDbContext = new VacunaDBContext();
                
                Ciudadano newCitizen = new Ciudadano()
                {
                    Dui = dui,
                    Nombre = txtBox2.Text,
                    FechaNacimiento = pickerNacimiento.Value,
                    Direccion = txtBox4.Text,
                    Telefono = txtBox5.Text,
                    Email = txtBox6.Text,
                    IdentificadorInst = idInstitution
                };

                Enfermedad newDisease = new Enfermedad()
                {
                    IdCiudadano = dui,
                    EnfermedadCronica = richTxtBox1.Text
                };

                Cabina cabinRef = new Cabina();
                cabinRef.Id = ((Cabina)cmbBox1.SelectedItem).Id;

                var vaccineDbContext = new VacunaDBContext();
                Cabina cabinDb = vaccineDbContext.Set<Cabina>()
                    .SingleOrDefault(cabin => cabin.Id == cabinRef.Id);

                Vacuna newVaccine = new Vacuna()
                {
                    IdTipoVacuna = 1,
                    IdCabina= cabinRef.Id,
                    IdGestor = this.idGestor,
                    IdCiudadano = dui,
                    CitaFechaHora = pickerCita2.Value,
                    ColaFechaHora = null,
                    VacunaFechaHora = null
                };

                VaccineDbContext.Add(newCitizen);
                VaccineDbContext.Add(newDisease);
                VaccineDbContext.Add(newVaccine);

                VaccineDbContext.SaveChanges();

                MessageBox.Show("¡Se ha registrado la información con éxito!", "Gobierno de El Salvador", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clearAllFormObjects();
            }
            else
            {
                txtBox1.Text = "";

                MessageBox.Show("Dato no valido! Intente ingresar el DUI sin guion", "Gobierno de El Salvador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 window = new Form2(idGestor: idGestor);
            window.Show();
        }

        private void clearAllFormObjects()
        {
            txtBox1.Text = "";
            txtBox2.Text = "";
            txtBox4.Text = "";
            txtBox5.Text = "";
            txtBox6.Text = "";
            txtBox7.Text = "";
            cmbBox1.Text = "";
            richTxtBox1.Text = "";
            pickerCita2.Value = DateTime.Now.AddDays(2);
            pickerNacimiento.Value = new DateTime(1990, 01, 01);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("A continuación, digite cada enfermedad línea por línea.", "Gobierno de El Salvador.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                richTxtBox1.Show();
                richTxtBox1.Text = "Digite acá";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && radioButton2.Checked)
            {
                MessageBox.Show("Por favor, continue completando el formulario.", "Gobierno de El Salvador.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                richTxtBox1.Hide();
                richTxtBox1.Text = "N/A";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Fecha Nacimiento, solo para +18 anios
            pickerNacimiento.MaxDate = DateTime.Today.AddYears(-18);
            pickerNacimiento.Value = new DateTime(1990, 01, 01);

            //Fecha minima para segunda cita
            pickerCita2.MinDate = DateTime.Today;
            pickerCita2.Value = DateTime.Now.AddDays(2);

            using (var vaccineDbContext = new VacunaDBContext())
            {
                cmbBox1.DataSource = vaccineDbContext.Cabinas.ToList();
                cmbBox1.DisplayMember = "direccion";
                cmbBox1.ValueMember = "id";
            }
        }
        
        private bool duiVerification(bool successOrNot)
        {
            int txtBox1Aux = 0;
            bool duiVerification =
                int.TryParse(txtBox1.Text, out txtBox1Aux);

            successOrNot = duiVerification;

            return successOrNot;
        }

        private bool institutionVerification(bool successOrNot)
        {
            int txtBox7Aux = 0;
            bool institutionVerification =
                int.TryParse(txtBox7.Text, out txtBox7Aux);

            successOrNot = institutionVerification;

            return successOrNot;
        }
    }
}