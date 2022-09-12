using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WriteIntoDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=DCS34-PC\DCS34;Initial Catalog=Test;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql="";
            string idNew = "'a03ot3'";
            string ipNew = "'142.124.31.3'";
          //sql = "INSERT INTO IP (ID, IP) VALUES('" + "a03ot4" + "', '" + "142.124.31.4" + "')";
          //sql = "INSERT INTO IP (ID, IP) VALUES('a03ot4', '142.124.31.4')";
            sql = "INSERT INTO IP (ID, IP) VALUES(" + idNew + "," + ipNew +")";
            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            MessageBox.Show("Data successfully inserted !");
            command.Dispose();
            cnn.Close();
        }
    }
}
