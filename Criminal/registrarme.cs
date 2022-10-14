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
    public partial class registrarme : Form
    {
        private readonly IUsuario dbUser = new RUsuario();
        public registrarme()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox4.Text!=this.textBox5.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK);
                return;
            }
            Usuario item = new Usuario
            {
                Apellido = this.textBox2.Text,
                Nombre = this.textBox1.Text,
                Pass=this.textBox4.Text,
                UserEmail=this.textBox3.Text
            };
            var response = await dbUser.Register(item);
            if (!response.IsSuccess)
            {
                MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK);
                return;
            }
            MessageBox.Show("Usuario Registrado", "Exito", MessageBoxButtons.OK);

            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_mostrar.Checked == true)
            {
                this.textBox4.UseSystemPasswordChar = false;
                this.textBox5.UseSystemPasswordChar = false;
            }
            else
            {
                this.textBox4.UseSystemPasswordChar = true;
                this.textBox5.UseSystemPasswordChar = true;
            }
        }
    }
}
