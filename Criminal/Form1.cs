using Criminal.Model;
using Criminal.Service;

namespace Criminal
{
    public partial class Form1 : Form
    {
        private readonly IDelincuente dbDelincuente = new RDelincuente();
        private int IndexRow=-5;
        private List<Delincuente> Delincuentes;
        public Form1()
        {
            InitializeComponent();
            this.label1.Text = Singleton.Instance.usuario.Nombre + " " +Singleton.Instance.usuario.Apellido;
            this.label3.Text = Singleton.Instance.usuario.UserEmail;
            LoadColumns();
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public async void LoadData()
        {
            this.dataGridView1.Rows.Clear();
            Delincuentes = await dbDelincuente.GetAll();
            for (int i = 0; i < Delincuentes.Count; i++)
            {
                string[] rowInfo = new string[] { Delincuentes[i].Nombre, Delincuentes[i].FechaNacimiento.ToShortDateString(), Delincuentes[i].RecompensaInicial.ToString(), Delincuentes[i].Aliases, Delincuentes[i].FechaPrimerDelito.ToShortDateString(), Delincuentes[i].CantidadDelitos.ToString() };
                this.dataGridView1.Rows.Add(rowInfo);
            }
            this.dataGridView1.ClearSelection();
            this.dataGridView1.Refresh();
        }
        private void LoadColumns()
        {
            DataGridViewColumn columnaNombre = new DataGridViewColumn();
            columnaNombre.Name = "Nombre";
            columnaNombre.CellTemplate = new DataGridViewTextBoxCell();
            columnaNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewColumn columnaFechaNacimiento = new DataGridViewColumn();
            columnaFechaNacimiento.Name = "Fecha Nacimiento";
            columnaFechaNacimiento.CellTemplate = new DataGridViewTextBoxCell();
            columnaFechaNacimiento.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewColumn columnaRecompensa = new DataGridViewColumn();
            columnaRecompensa.Name = "Recompensa ofrecida";
            columnaRecompensa.CellTemplate = new DataGridViewTextBoxCell();
            columnaRecompensa.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewColumn columnaAlias = new DataGridViewColumn();
            columnaAlias.Name = "Alias";
            columnaAlias.CellTemplate = new DataGridViewTextBoxCell();
            columnaAlias.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewColumn columnaFechaPDelito = new DataGridViewColumn();
            columnaFechaPDelito.Name = "Primer Delito";
            columnaFechaPDelito.CellTemplate = new DataGridViewTextBoxCell();
            columnaFechaPDelito.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewColumn columnaNumeroDelitos = new DataGridViewColumn();
            columnaNumeroDelitos.Name = "# Delitos";
            columnaNumeroDelitos.CellTemplate = new DataGridViewTextBoxCell();
            columnaNumeroDelitos.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.dataGridView1.Columns.Add(columnaNombre);
            this.dataGridView1.Columns.Add(columnaFechaNacimiento);
            this.dataGridView1.Columns.Add(columnaRecompensa);
            this.dataGridView1.Columns.Add(columnaAlias);
            this.dataGridView1.Columns.Add(columnaFechaPDelito);
            this.dataGridView1.Columns.Add(columnaNumeroDelitos);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.RowCount; i++)
            {
                if (this.dataGridView1.Rows[i].Selected)
                {
                    IndexRow = i;
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IndexRow==-5)
            {
                MessageBox.Show("Seleccione un delincuente", "Error", MessageBoxButtons.OK);
                return;
            }
            InfoDelincuente frmInfo = new InfoDelincuente(this,Delincuentes[IndexRow]);
            frmInfo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InfoDelincuente frmNuevo = new InfoDelincuente(this);
            frmNuevo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Agentes frmAgentes = new Agentes();
            frmAgentes.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Organizaciones frmOrganizciones = new Organizaciones();
            frmOrganizciones.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (IndexRow == -5)
            {
                MessageBox.Show("Seleccione un delincuente", "Error", MessageBoxButtons.OK);
                return;
            }
            HistorialOrganizaciones frmHistorial = new HistorialOrganizaciones(Delincuentes[IndexRow]);
            frmHistorial.Show();
        }
    }
}