using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace Diseño_ClientesCRUD
{
    public partial class Cliente_Contacto : Form
    {
        private Cliente_direcciones Formdirecciones;
        private Principal FormPrincipal;
        private Conexion con = new Conexion();

        public Cliente_Contacto(Cliente_direcciones Formdirecciones)
        {
            InitializeComponent();
            this.Formdirecciones = Formdirecciones;
            FormPrincipal = Formdirecciones.GetFormPrincipal();
        }

        private void btnSaliir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRetrocedes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Formdirecciones.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormPrincipal.Show();
            this.Hide();
        }

        private void btnDirec_Click(object sender, EventArgs e)
        {
            this.Hide();
            Formdirecciones.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string Numero = txtboxNumCont.Text;
            string Correo = txtboxCorreo.Text;

            string datosContacto = $"'{Numero}'," +$"'{Correo}',";
            string datosDirecciones = Formdirecciones.GetDatos();
            string datosPrincipal = FormPrincipal.GetDatos();
            string datosFechaNaci = FormPrincipal.GetDatosFecNac();
            string datosFecha = FormPrincipal.GetDatosFec();
            string datosTotales = $"{datosPrincipal}{datosDirecciones}{datosContacto}"+ $"'{datosFechaNaci}',"+"'Usuario1',"+$"'{datosFecha}',"+ "'11:00:00','192.146.1'";

            con.InsertarDatosCliente(datosTotales);
            MessageBox.Show(datosTotales, "Datos Totales");
        }
    }
}
