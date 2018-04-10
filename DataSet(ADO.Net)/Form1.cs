using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace DataSet_ADO.Net_
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter dtAdptr=null;
        DataSet dtSt = null;
        SqlCommandBuilder SqlcmdBldr = null;
        

        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);

        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            try
            {
                string query = txtBxQuery.Text;
                dtAdptr = new SqlDataAdapter(query, conn);
                SqlcmdBldr = new SqlCommandBuilder(dtAdptr);
                dtSt = new DataSet();
                dtAdptr.Fill(dtSt, "mybook");
                dataGridView1.DataSource = dtSt.Tables["mybook"];
            }
            catch { throw new Exception(); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            dtAdptr.Update(dtSt,"mybook");

        }
    }
}
