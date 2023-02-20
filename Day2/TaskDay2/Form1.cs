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

namespace TaskDay2

{
    public partial class Form1 : Form
    {
        SqlConnection con;
        public Form1()
        {
            InitializeComponent();
             con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ITIS;Integrated Security=True");
        }
        DataTable tblTopic = new DataTable();
        DataTable tblCourse = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
        {
            loadDATA();
            loadTopic();
        }
        private void loadTopic()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Topic", con);
            da.Fill(tblTopic);
            cbTopic.DataSource = tblTopic;
            cbTopic.DisplayMember = "Top_Name";
            cbTopic.ValueMember = "Top_Id";
        }
        private void loadDATA()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Course", con);
            da.Fill(tblCourse);
            dataGridView1.DataSource = tblCourse;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow dr = tblCourse.NewRow();
            dr[1] = textBox1.Text;
            dr[2] = nudDuration.Value;
            dr[3] = cbTopic.SelectedValue;
            tblCourse.Rows.Add(dr);
            MessageBox.Show("inserted success");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            foreach (DataRow item in tblCourse.Rows)
            {
                int id = Convert.ToInt32(row.Cells[2].Value);

                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "edit")
                {
                    if (Convert.ToInt32(item[0]) == id)
                    {
                        item[1] = row.Cells[3].Value;
                        item[2] = row.Cells[4].Value;
                        item[3] = row.Cells[5].Value;
                        MessageBox.Show("Edit success");
                    }
                }
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "delete")
                {
                    if (Convert.ToInt32(item[0]) == id)
                    {
                        item.Delete();
                        MessageBox.Show("deleted success");
                    }
                }
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
                SqlCommand add = new SqlCommand("insert into Course ([Crs_Name],[Crs_Duration],[Top_Id]) VALUES(@Crs_Name,@Crs_Duration,@Top_Id)", con);
            add.Parameters.Add("Crs_Name",SqlDbType.NVarChar,50, "Crs_Name");
            add.Parameters.Add("Crs_Duration", SqlDbType.Int,4, "Crs_Duration");
            add.Parameters.Add("Top_Id", SqlDbType.Int,4, "Top_Id");
            SqlCommand delete = new SqlCommand("delete from Course where Crs_Id=@Top_Id", con);

            delete.Parameters.Add("Top_Id", SqlDbType.Int, 4, "Top_Id");
             SqlCommand update  = new SqlCommand("UPDATE [dbo].[Course] SET [Crs_Name] =@Crs_Name ,[Crs_Duration] =@Crs_Duration ,[Top_Id] =@Top_Id WHERE Crs_Id=@Crs_Id", con);
            update.Parameters.Add("Crs_Name", SqlDbType.NVarChar, 50, "Crs_Name");
            update.Parameters.Add("Crs_Duration", SqlDbType.Int, 4, "Crs_Duration");
            update.Parameters.Add("Top_Id", SqlDbType.Int, 4, "Top_Id");

            SqlDataAdapter sqlDa = new SqlDataAdapter();
            sqlDa.InsertCommand = add;
            sqlDa.DeleteCommand = delete;
            sqlDa.UpdateCommand = update;
            sqlDa.Update(tblCourse);
        }
    }
}
