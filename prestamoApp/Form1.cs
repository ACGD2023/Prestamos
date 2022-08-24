using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prestamoApp
{
    public partial class Form1 : Form
    {
        clientes _clientes = new clientes();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cargar datos
            leer();
        }

        public void leer() {
            dataGridView1.DataSource = null;
            _clientes.listar();
            dataGridView1.DataSource = _clientes.dt; 
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sGrid = (DataGridView)sender;
            try
            {
                if (sGrid .Rows [e.RowIndex].Cells [e.ColumnIndex].Value !=null){
                    MessageBox.Show(_clientes.barrio());
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
