using Criminal.Model;
using Criminal.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Criminal
{
    public partial class Organizaciones : Form
    {
        List<Organizacion> LOrganizaciones;
        ROrganizacion dbOrganizacion = new ROrganizacion();
        public Organizaciones()
        {
            InitializeComponent();
            LoadColumns();
            LoadData();
        }

        private void LoadColumns()
        {
            DataGridViewColumn columnaNombre = new DataGridViewColumn();
            columnaNombre.Name = "Nombre";
            columnaNombre.CellTemplate = new DataGridViewTextBoxCell();
            columnaNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns.Add(columnaNombre);

            DataGridViewColumn cObjetivo = new DataGridViewColumn();
            cObjetivo.Name = "Objetivo";
            cObjetivo.CellTemplate = new DataGridViewTextBoxCell();
            cObjetivo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns.Add(cObjetivo);

        }

        private async void LoadData()
        {
            this.dataGridView1.Rows.Clear();
            LOrganizaciones= await dbOrganizacion.GetAll();
            for (int i = 0; i < LOrganizaciones.Count; i++)
            {
                string[] rowInfo = new string[] { LOrganizaciones[i].Nombre, LOrganizaciones[i].Objetivo };
                this.dataGridView1.Rows.Add(rowInfo);
            }
            this.dataGridView1.Refresh();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Organizacion item = new Organizacion()
            {
                Nombre = this.txtNombre.Text,
                Descripcion = this.txtDescripcion.Text,
                FechaCreacion = DateTime.Parse(this.txtFecha.Text),
                Objetivo = this.txtObjetivo.Text,
                Relaciones = this.txtRelaciones.Text
            };
            var resp = await dbOrganizacion.Post(item);
            if (resp.IsSuccess)
            {
                MessageBox.Show("Organizacion registrado", "", MessageBoxButtons.OK);
                LoadData();
            }
            else
            {
                MessageBox.Show("No se pudo registrar la organizacion", "", MessageBoxButtons.OK);
            }
        }
    }
}
