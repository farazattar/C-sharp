using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectingControlsToData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSetOriginal.IP' table. You can move, or remove it, as needed.
            this.iPTableAdapter2.Fill(this.testDataSetOriginal.IP);
            // TODO: This line of code loads data into the 'testDataSet1.IP' table. You can move, or remove it, as needed.
            this.iPTableAdapter1.Fill(this.testDataSet1.IP);
            // TODO: This line of code loads data into the 'testDataSet.IP' table. You can move, or remove it, as needed.
            this.iPTableAdapter.Fill(this.testDataSet.IP);

        }

        private void iPBindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
