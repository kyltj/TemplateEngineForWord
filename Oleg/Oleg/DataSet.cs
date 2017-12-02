using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Oleg
{
    public partial class DataSet : Form
    {
        public DataSet()
        {
            InitializeComponent();
        }

        private void DataSet_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Street' table. You can move, or remove it, as needed.
            if (ADDtextBox1.pct[Settings1.Default.ID].Text == "Адрес")
            {
                this.streetTableAdapter.Fill(this.database1DataSet.Street);
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.streetTableAdapter.Update(this.database1DataSet.Street);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ADDtextBox1.tex[Settings1.Default.ID].Text = (string)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value;
            this.Hide();
        }

        private void DataSet_Resize(object sender, EventArgs e)
        {
            dataGridView1.Size = new Size(this.Width - 16, this.Height - 45);
        }
    }
}
