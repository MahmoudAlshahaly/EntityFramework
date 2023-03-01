using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2.Models;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        ITISContext db;
        public Form1()
        {
            InitializeComponent();
            db = new ITISContext();
        }

        public void fillTopic()
        {
            cbxtopic.DataSource = db.Topics.ToList();
            cbxtopic.DisplayMember = "TopName";
            cbxtopic.ValueMember = "TopId";

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var data = db.Topics.ToList();
            dataGridView1.DataSource = data;
            fillTopic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Topic t = new Topic();
            t.TopId =Convert.ToInt32( txtid.Text);
            t.TopName = txtname.Text;
            db.Topics.Add(t);
            db.SaveChanges();
            Form1_Load(null,null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var id =Convert.ToInt32( cbxtopic.SelectedValue);
            var data = db.Topics.Where(a=> a.TopId == id).FirstOrDefault();

            db.Topics.Remove(data);
            db.SaveChanges();
            Form1_Load(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var id =Convert.ToInt32( cbxtopic.SelectedValue);
            var data = db.Topics.Where(a=> a.TopId == id).FirstOrDefault();
           
            data.TopId = Convert.ToInt32(txtid.Text);
            data.TopName= txtname.Text;
           
            db.Topics.Update(data);
            db.SaveChanges();
            Form1_Load(null, null);
        }

        private void cbxtopic_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(cbxtopic.SelectedValue);
            var data = db.Topics.Where(a => a.TopId == id).FirstOrDefault();
            txtid.Text = data.TopId.ToString();
            txtname.Text = data.TopName.ToString();
        }
    }
}
