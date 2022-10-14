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
    public partial class log_in : Form
    {
        private readonly IUsuario db = new RUsuario();
        public log_in()
        {
            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string Username = this.textBox1.Text;
            string Password = this.textBox2.Text;
            var response = await db.Login(Username, Password);
            if (response.IsSuccess)
            {
                Singleton.Instance.usuario = (Usuario)response.Result;
                this.Hide();
                Bienvenida frmBienvenida = new Bienvenida();
                frmBienvenida.ShowDialog();
                Form1 frmPrincipal = new Form1();
                frmPrincipal.Show();
            }
            else
            {
                MessageBox.Show(response.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            registrarme frmRegistro = new registrarme();
            frmRegistro.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_mostrarPass.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
