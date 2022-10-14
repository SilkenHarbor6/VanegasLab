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
    public partial class InfoDelincuente : Form
    {
        private Delincuente delincuente;
        private Form1 padre;
        private readonly IDelincuente db = new RDelincuente();
        private RAgente dbAgente = new RAgente();
        List<Agente> LAgente;
        private int AIndex = -5;
        public InfoDelincuente(Form1 padre, Delincuente item = null)
        {
            InitializeComponent();
            this.padre = padre;
            delincuente = item;
            LoadAgents();
            if (item != null)
            {
                PrepareData(delincuente.TipoDelincuente, delincuente.EsPeligroso);
                this.button1.Text = "Actualizar";
                this.txtAlias.Text = delincuente.Aliases;
                this.txtAumento.Text = delincuente.IncrementoRecompensa.ToString();
                this.txtDelitos.Text = delincuente.CantidadDelitos.ToString();
                this.txtDescripcion.Text = delincuente.Descripcion;
                this.txtEspecialidad.Text = delincuente.Especialidad;
                this.txtNacimiento.Text = delincuente.FechaNacimiento.ToShortDateString();
                this.txtNombre.Text = delincuente.Nombre;
                this.txtPais.Text = delincuente.PaisOrigen;
                this.txtPrimerDelito.Text = delincuente.FechaPrimerDelito.ToShortDateString();
                this.txtRecompensa.Text = delincuente.RecompensaInicial.ToString();
                this.txtTipoEstafador.Text = delincuente.TipoEstafador;
                this.txtVictimas.Text = delincuente.Victimas.ToString();
            }
            else
            {
                PrepareData("Ladron", false);
                this.button1.Text = "Agregar";
            }
            DataGridViewColumn columnaNombre = new DataGridViewColumn();
            columnaNombre.Name = "Nombre";
            columnaNombre.CellTemplate = new DataGridViewTextBoxCell();
            columnaNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns.Add(columnaNombre);

        }

        private async void LoadAgents()
        {
            LAgente = await dbAgente.GetAll();
            if (delincuente != null)
            {
                this.label14.Text = "Agente " + (from c in LAgente
                                                 where c.Nif == delincuente.CodigoAgente
                                                 select c.Nombre).FirstOrDefault();
            }
            for (int i = 0; i < LAgente.Count; i++)
            {
                this.dataGridView1.Rows.Add(LAgente[i].Nombre);
            }
            this.dataGridView1.Refresh();
        }

        private void PrepareData(string tipo, bool peligroso)
        {
            switch (tipo)
            {
                case "Estafador":
                    this.gAsesino.Visible = false;
                    this.gEstafador.Visible = true;
                    this.gFalsificador.Visible = false;
                    this.txtTipoEstafador.Text = "";
                    this.txtEspecialidad.Text = "";
                    this.txtPais.Text = "";
                    this.txtPrimerDelito.Text = "";
                    this.cmbTipo.SelectedIndex = 2;
                    this.checkBox1.Visible = false;
                    this.checkBox1.Checked = false;
                    peligroso = false;
                    break;
                case "Violador":
                    this.gAsesino.Visible = false;
                    this.gEstafador.Visible = false;
                    this.gFalsificador.Visible = false;
                    this.txtTipoEstafador.Text = "";
                    this.txtEspecialidad.Text = "";
                    this.txtPais.Text = "";
                    this.txtPrimerDelito.Text = "";
                    this.txtDescripcion.Text = "";
                    this.cmbTipo.SelectedIndex = 1;
                    peligroso = true;
                    this.checkBox1.Visible = true;
                    break;
                case "Falsificador":
                    this.gAsesino.Visible = false;
                    this.gEstafador.Visible = false;
                    this.gFalsificador.Visible = true;
                    this.txtTipoEstafador.Text = "";
                    this.txtEspecialidad.Text = "";
                    this.cmbTipo.SelectedIndex = 3;
                    this.checkBox1.Visible = false;
                    this.checkBox1.Checked = false;
                    peligroso = false;
                    break;
                case "Asesino":
                    this.gAsesino.Visible = true;
                    this.gEstafador.Visible = false;
                    this.gFalsificador.Visible = false;
                    this.txtPais.Text = "";
                    this.txtPrimerDelito.Text = "";
                    this.cmbTipo.SelectedIndex = 4;
                    this.checkBox1.Visible = true;
                    peligroso = true;
                    break;
                case "Ladron":
                    this.gAsesino.Visible = false;
                    this.gEstafador.Visible = false;
                    this.gFalsificador.Visible = false;
                    this.txtTipoEstafador.Text = "";
                    this.txtEspecialidad.Text = "";
                    this.txtPais.Text = "";
                    this.checkBox1.Visible = false;
                    peligroso = false;
                    this.checkBox1.Checked = false;
                    this.txtPrimerDelito.Text = "";
                    this.txtDescripcion.Text = "";
                    this.cmbTipo.SelectedIndex = 0;
                    break;
            }
            if (peligroso)
            {
                this.checkBox1.Checked = true;
                this.gPeligroso.Visible = true;
            }
            else
            {
                this.checkBox1.Checked = false;
                this.gPeligroso.Visible = false;
                this.txtVictimas.Text = "0";
                this.txtAumento.Text = "0";
                this.AIndex = -5;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.gPeligroso.Visible = true;
            }
            else
            {
                this.gPeligroso.Visible = false;
                this.txtVictimas.Text = "";
                this.txtAumento.Text = "";
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrepareData((sender as ComboBox).SelectedItem.ToString(), this.checkBox1.Checked);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Delincuente nDelincuente = new Delincuente();
            nDelincuente.Aliases = this.txtAlias.Text;
            nDelincuente.CantidadDelitos = Convert.ToInt32(this.txtDelitos.Text);
            nDelincuente.Descripcion = this.txtDescripcion.Text;
            nDelincuente.Especialidad = this.txtEspecialidad.Text;
            nDelincuente.EsPeligroso = this.checkBox1.Checked;
            nDelincuente.FechaNacimiento = DateTime.Parse(this.txtNacimiento.Text);
            if (this.txtPrimerDelito.Text != "")
            {
                nDelincuente.FechaPrimerDelito = DateTime.Parse(this.txtPrimerDelito.Text);
            }
            nDelincuente.IncrementoRecompensa = Convert.ToInt32(this.txtAumento.Text);
            nDelincuente.Nombre = this.txtNombre.Text;
            nDelincuente.PaisOrigen = this.txtPais.Text;
            nDelincuente.RecompensaInicial = Convert.ToInt32(this.txtRecompensa.Text);
            nDelincuente.TipoDelincuente = this.cmbTipo.SelectedItem.ToString();
            nDelincuente.TipoEstafador = this.txtTipoEstafador.Text;
            nDelincuente.Victimas = Convert.ToInt32(this.txtVictimas.Text);
            if (this.checkBox1.Checked && this.AIndex == -5)
            {
                MessageBox.Show("Seleccione un agente", "", MessageBoxButtons.OK);
                return;
            }
            if (this.checkBox1.Checked)
            {
                nDelincuente.CodigoAgente = LAgente[AIndex].Nif;
            }
            Response resp;
            if (delincuente == null)
            {
                resp = await db.Post(nDelincuente);
            }
            else
            {
                resp = await db.Put(nDelincuente);
            }
            MessageBox.Show(resp.Message, "", MessageBoxButtons.OK);
            padre.LoadData();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.RowCount; i++)
            {
                if (this.dataGridView1.Rows[i].Selected)
                {
                    AIndex = i;
                    break;
                }
            }
        }
    }
}
