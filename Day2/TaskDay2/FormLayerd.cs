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
    public partial class FormLayerd : Form
    {
        public FormLayerd()
        {
            InitializeComponent();
        }
        DataTable tblTopic = new DataTable();
        DataTable tblCourse = new DataTable();
        BusinessLayer bl = new BusinessLayer();
        databaselayer db = new databaselayer();
        private void FormLayerd_Load(object sender, EventArgs e)
        {
            loadDATA();
            loadTopic();
        }
        private void loadTopic()
        {
            
            cbTopic.DataSource = db.select("select * from Topic") ;
            cbTopic.DisplayMember = "Top_Name";
            cbTopic.ValueMember = "Top_Id";
        }
        private void loadDATA()
        {
            dataGridView1.DataSource = bl.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int affected = bl.Add(textBox1.Text,(int) nudDuration.Value, (int)cbTopic.SelectedValue);
                //db.execute("insert into Course([Crs_Name],[Crs_Duration],[Top_Id]) VALUES('" + textBox1.Text+"', "+nudDuration.Value+", "+cbTopic.SelectedValue+")");
            if (affected > 0)
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

            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "delete")
            {

                int num = bl.Delete((int)row.Cells[2].Value);
                    //db.execute("delete from Course where Crs_Id=" + row.Cells[2].Value + "");

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

                int num = bl.Update((int)row.Cells[2].Value, row.Cells[3].Value.ToString(),(int) row.Cells[4].Value,(int) row.Cells[5].Value);
                    //db.execute("UPDATE [dbo].[Course] SET [Crs_Name] ='" + row.Cells[3].Value + "' ,[Crs_Duration] =" + row.Cells[4].Value + " ,[Top_Id] =" + row.Cells[5].Value + " WHERE Crs_Id=" + row.Cells[2].Value + "");
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
