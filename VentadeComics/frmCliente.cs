using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentadeComics
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }
        //variables globales
        public int id_persona;
        ClienteLN ocl = new ClienteLN();
        public void listarCliente(string valor)
        {
            dataGridView1.DataSource = ocl.ViewClienteFiltro(valor).ToList();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            listarCliente(textBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listarCliente(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            id_persona = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            DialogResult = DialogResult.OK;
            this.Hide();
        }
    }
}
