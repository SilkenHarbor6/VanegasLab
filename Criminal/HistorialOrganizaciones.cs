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
    public partial class HistorialOrganizaciones : Form
    {
        private List<Organizacion> LOrganizaciones = new List<Organizacion>();
        private List<DelincuenteOrg> LHistorial = new List<DelincuenteOrg>();
        private RHistorial historial = new RHistorial();
        private ROrganizacion dbOrganizacion = new ROrganizacion();
        Delincuente delincuente;
        public HistorialOrganizaciones(Delincuente item)
        {
            InitializeComponent();
            PrepareColumns();
            delincuente=item;
            LoadData(delincuente.CodigoDelincuente);
        }

        private async void LoadData(int id)
        {
            this.dataGridView1.Rows.Clear();
            LOrganizaciones=await  dbOrganizacion.GetAll();
            LHistorial = await historial.GetAll(id);
            this.comboBox1.DataSource = (from c in LOrganizaciones
                                         select c.Nombre).ToList();
            for (int i = 0; i < LHistorial.Count; i++)
            {
                string[] rowInfo = new string[] { LHistorial[i].FechaIngreso.ToShortTimeString(), LHistorial[i].FechaSalida.ToShortTimeString(), (from c in LOrganizaciones where c.CodigoOrg == LHistorial[i].CodigoOrg select c.Nombre).FirstOrDefault() };
                this.dataGridView1.Rows.Add(rowInfo);
            }
            this.dataGridView1.Refresh();
        }

        private void PrepareColumns()
        {
            DataGridViewColumn FechaInicio = new DataGridViewColumn();
            FechaInicio.Name = "Fecha inicio";
            FechaInicio.CellTemplate = new DataGridViewTextBoxCell();
            FechaInicio.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns.Add(FechaInicio);

            DataGridViewColumn FechaFin = new DataGridViewColumn();
            FechaFin.Name = "Fecha fin";
            FechaFin.CellTemplate = new DataGridViewTextBoxCell();
            FechaFin.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns.Add(FechaFin);

            DataGridViewColumn Organizacon = new DataGridViewColumn();
            Organizacon.Name = "Organizacion";
            Organizacon.CellTemplate = new DataGridViewTextBoxCell();
            Organizacon.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns.Add(Organizacon);


        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DelincuenteOrg Dorg = new DelincuenteOrg()
            {
                FechaIngreso = DateTime.Parse(this.textBox1.Text),
                FechaSalida = DateTime.Parse(this.textBox2.Text),
                CodigoOrg = LOrganizaciones[this.comboBox1.SelectedIndex].CodigoOrg,
                CodigoDelincuente=delincuente.CodigoDelincuente
            };

            //Almacenar el historial
            var resp = await historial.post(Dorg);
            if (resp)
            {
                MessageBox.Show("Historial registrado", "", MessageBoxButtons.OK);
                LoadData(delincuente.CodigoDelincuente);
            }
            else
            {
                MessageBox.Show("No se pudo registrar el historial", "", MessageBoxButtons.OK);
            }
        }
    }
}
