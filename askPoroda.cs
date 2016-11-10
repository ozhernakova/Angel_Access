using System;
using System.Collections.Generic;
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
        }

         private void buttonOK_Click(object sender, EventArgs e)
        {
            dtd.idPoroda = (int)dtd.porodi.Select("[Порода] = '" + comboBox1.Text + "'")[0][0]; 
        }
        }
    }

