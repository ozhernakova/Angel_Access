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
        dataToDisplay dtd;
        public askPoroda(string Virabotka, string Priviazka, string Napravlenie, dataToDisplay dtd)
        {
            InitializeComponent();
            label2.Text = string.Format ("В параметрах места замера выбраны Выработка: {0}, Привязка: {1}, Направление: {2}. В базе данных не найдено такого сочетания параметров. Чтобы добавить этот центр измерений в базу, пожалуйста, уточните породу:", Virabotka,  Priviazka,  Napravlenie );
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
        }
    }
}
