using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Angel_Access
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            accessConnect aC = new accessConnect();
          

            // TODO: проверить связь с базой акцесса. Если нет - предложить выбрать путь к ней.
            
            // TODO: This line of code loads data into the 'пЭЗ_ИDataSet.Горизонт' table. You can move, or remove it, as needed.
            this.горизонтTableAdapter.Fill(this.пЭЗ_ИDataSet.Горизонт);
            // TODO: This line of code loads data into the 'пЭЗ_ИDataSet.Участок' table. You can move, or remove it, as needed.
            this.участокTableAdapter.Fill(this.пЭЗ_ИDataSet.Участок);

            comboBox1.DataSource = aC.dtd.hor.Tables[0];
            comboBox1.DisplayMember = "Горизонт";

        }
    }
}
