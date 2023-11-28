using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AltaOrdenesServicio
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        Sucursales suc = new Sucursales();


        private void frmLogin_Load(object sender, EventArgs e)
        {
            cmbSucursal.DataSource = suc.CargarCombo();
            cmbSucursal.DisplayMember = "NOMBRE";
            cmbSucursal.ValueMember = "ID";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {

        }
    }
}
