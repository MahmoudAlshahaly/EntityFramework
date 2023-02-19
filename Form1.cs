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

namespace TaskDAY1
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        public Form1()
        {
            InitializeComponent();
             con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ITIS;Integrated Security=True");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadDATA();
            loadTopic();
        }
        private void loadTopic()
        {
            SqlCommand cmd = new SqlCommand("select * from Topic", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            List<topic> topics = new List<topic>();
            while (sdr.Read())
            {
                topic t = new topic();
                t.Top_Id = (int)sdr[0];
                t.Top_Name = sdr[1].ToString();

                topics.Add(t);
            }
            con.Close();
            cbTopic.DataSource = topics;
            cbTopic.DisplayMember = "Top_Name";
            cbTopic.ValueMember = "Top_Id";
        }
        private void loadDATA()
        {
            SqlCommand cmd = new SqlCommand("select * from Course", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            List<course> cousces = new List<course>();

            while (sdr.Read())
            {
                course c = new course();
                c.Crs_Id = (int)sdr[0];
                c.Crs_Name = sdr[1].ToString();
                c.Crs_Duration = (int)sdr[2];
                c.Top_Id = (int)sdr[3];

                cousces.Add(c);
            }
            con.Close();

            dataGridView1.DataSource = cousces;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Course ([Crs_Name],[Crs_Duration],[Top_Id]) VALUES('" + textBox1.Text+"',"+nudDuration.Value+","+cbTopic.SelectedValue+")", con);
            con.Open();
            int num= cmd.ExecuteNonQuery();
            con.Close();
            if(num>0)
            {

                MessageBox.Show("inserted success");
                loadDATA();
            }
            else
            {
                MessageBox.Show("error during insert");

            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            if (dataGridView1.Columns[e.ColumnIndex].HeaderText=="delete")
            {
                SqlCommand cmd = new SqlCommand("delete from Course where Crs_Id=" + row.Cells[2].Value + "", con);
                con.Open();
                int num = cmd.ExecuteNonQuery();
                con.Close();
                if (num > 0)
                {

                    MessageBox.Show("deleted success");
                    loadDATA();
                }
                else
                {
                    MessageBox.Show("error during delete");

                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "edit")
            {
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Course] SET [Crs_Name] ='"+ row.Cells[3].Value + "' ,[Crs_Duration] ="+ row.Cells[4].Value + " ,[Top_Id] ="+ row.Cells[5].Value + " WHERE Crs_Id="+ row.Cells[2].Value + "", con);
                con.Open();
                int num = cmd.ExecuteNonQuery();
                con.Close();
                if (num > 0)
                {

                    MessageBox.Show("Edit success");
                    loadDATA();
                }
                else
                {
                    MessageBox.Show("error during Edit");

                }
            }
        }
    }
}
