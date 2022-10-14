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
    public partial class Agentes : Form
    {
        private RAgente db = new RAgente();
        private List<Agente> LAgente = new List<Agente>();
        public Agentes()
        {
            InitializeComponent();
            DataGridViewColumn columnaNombre = new DataGridViewColumn();
            columnaNombre.Name = "Nombre";
            columnaNombre.CellTemplate = new DataGridViewTextBoxCell();
            columnaNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns.Add(columnaNombre);
            LoadData();
        }
        private async void LoadData()
        {
            this.dataGridView1.Rows.Clear();
            LAgente = await db.GetAll();
            for (int i = 0; i < LAgente.Count; i++)
            {
                this.dataGridView1.Rows.Add(LAgente[i].Nombre);
            }
            this.dataGridView1.Refresh();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Agente item = new Agente()
            {
                Direccion = this.txtDireccion.Text,
                Nif = Convert.ToInt32(this.txtNif.Text),
                Nombre = this.txtNombre.Text,
                NumeroAgente = Convert.ToInt32(this.txtNAgente.Text),
                Telefono = this.txtTelefono.Text
            };
            var resp = await db.Post(item);
            if (resp.IsSuccess)
            {
                MessageBox.Show("Agente agregado", "", MessageBoxButtons.OK);
                LoadData();
                item = new Agente();
            }
            else
            {
                MessageBox.Show(resp.Message, "", MessageBoxButtons.OK);
            }
        }
    }
}
