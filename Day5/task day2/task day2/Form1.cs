using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using task_day2.Models;

namespace task_day2
{
    public partial class Form1 : Form
    {
        UniversityContext db;
        public Form1()
        {
            InitializeComponent();
            db = new UniversityContext();
        }
        public void fillAuthors()
        {
            cbx.DataSource = db.authors.ToList();
            cbx.DisplayMember = "name";
            cbx.ValueMember = "id";

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var data1 = db.newss.Include(a=>a.author).ToList().Select(a=> new {id=a.id,name=a.name,authorname=a.author.name }).ToList();
            dataGridView1.DataSource = data1;
            fillAuthors();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            news t = new news();
            var auth = db.authors.Where(a=>a.id==Convert.ToInt32(cbx.SelectedValue)).FirstOrDefault();
            t.name = txtname.Text;
            t.author = auth;
            db.newss.Add(t);
            db.SaveChanges();
            Form1_Load(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            var data = db.newss.Where(a => a.id == id).FirstOrDefault();

            db.newss.Remove(data);
            db.SaveChanges();
            Form1_Load(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(txtid.Text);
            var data = db.newss.Where(a => a.id == id).FirstOrDefault();
            var auth = db.authors.Where(a => a.id == Convert.ToInt32(cbx.SelectedValue)).FirstOrDefault();

            data.name = txtname.Text;
            data.author = auth;

            db.newss.Update(data);
            db.SaveChanges();
            Form1_Load(null, null);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbx.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
