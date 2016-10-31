using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Angel_Access
{
    public partial class askPoroda : Form
    {
        DataToDisplay dtd;
        public askPoroda(string question,DataToDisplay dtd)
        {
            InitializeComponent();
            label2.Text = question;
            comboBox1.DataSource = dtd.porodi;
            comboBox1.DisplayMember = "Порода";
            this.dtd = dtd;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            dtd.setidPoroda(comboBox1.Text);
            dtd.Poroda = comboBox1.Text;
        }
    }
}
