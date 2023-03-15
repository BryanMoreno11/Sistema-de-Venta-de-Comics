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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            customizeDesing();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminSerie frm = new AdminSerie();
            openChildForm(frm);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminEditorial frm = new AdminEditorial();
            openChildForm(frm);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminComic frm = new AdminComic();
            openChildForm(frm);
        }
        private void customizeDesing()
        {
            paneLComics.Visible = false;
            panelPersonas.Visible = false;
            panelReportes.Visible = false;
        }
        private void hideSubMenu()
        {
            if (paneLComics.Visible == true)
                paneLComics.Visible = false;
            if (panelPersonas.Visible == true)
                panelPersonas.Visible = false;
            if (panelReportes.Visible == true)
                panelReportes.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(paneLComics);
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminGenero frm = new AdminGenero();
            openChildForm(frm);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPersonas);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            showSubMenu(panelReportes);
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChild.Controls.Add(childForm);
            panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void panelChild_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            AdminAutor frm = new AdminAutor();
            openChildForm(frm);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AdminCliente frm = new AdminCliente();
            openChildForm(frm);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdminVentas frm = new AdminVentas();
            openChildForm(frm);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ReporteVentas frm = new ReporteVentas();
            openChildForm(frm);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ReporteSeriesVentas frm = new ReporteSeriesVentas();
            openChildForm(frm);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            GeneroVentas frm = new GeneroVentas();
            openChildForm(frm);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ClienteCompras frm = new ClienteCompras();
            openChildForm(frm);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ReporteClientesGastos frm = new ReporteClientesGastos();
            openChildForm(frm);
        }
  

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
        }


        
    }
}
