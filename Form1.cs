using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Angel_Access
{
    public partial class Form1 : Form
    {
        accessConnect aC;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            aC = new accessConnect();
          

            // TODO: проверить связь с базой акцесса. Если нет - предложить выбрать путь к ней.
            
            

            comboBoxHorizont.DataSource = aC.dtd.horizons;
            comboBoxHorizont.DisplayMember = "Горизонт";

           // comboBoxRegion.DataSource = aC.dtd.regions.Tables[0];
            comboBoxRegion.DataSource = aC.dtd.regions;
            comboBoxRegion.DisplayMember = "Участок";

        }

        private void buttonRegion_Click(object sender, EventArgs e)
        {
            string tmp1 = comboBoxHorizont.SelectedIndex.ToString();
            string tmp2 = comboBoxRegion.SelectedIndex.ToString();

            int lineNumber = aC.virabotka(tmp1, tmp2);

            if (lineNumber > 0)
            {
                this.comboBoxVirabotka.SelectedIndexChanged += new System.EventHandler(this.comboBoxVirabotka_SelectedIndexChanged);

                comboBoxVirabotka.DataSource = aC.dtd.virabotki;
                comboBoxVirabotka.DisplayMember = "Выработка";
                fillComboBox();

 
                //comboBoxBlock.DataSource = aC.dtd.virabotki;
                //comboBoxBlock.DisplayMember = "Блок";

                //comboBoxPodetag.DataSource = aC.dtd.virabotki;
                //comboBoxPodetag.DisplayMember = "Подэтаж";
                groupBoxVirabotka.Visible = true;
 


            }
                
            else 
            { 
                groupBoxVirabotka.Visible = false;
                this.comboBoxVirabotka.SelectedIndexChanged -= this.comboBoxVirabotka_SelectedIndexChanged;
                MessageBox.Show(@"в базе не найдены выработки для горизонта  " + comboBoxHorizont.Text + " и участка " + comboBoxRegion.Text + "\n" + "Добавить новую выработку в базу можно только через Access, программу ПЭЗ_И.accdb", "Выработки не найдены", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
               
            
        }

        void fillComboBox() 
        {
            // Выборка запросом - см https://msdn.microsoft.com/ru-ru/library/bb669073(v=vs.110).aspx
            EnumerableRowCollection<DataRow> query = from order in aC.dtd.virabotki.AsEnumerable()
                                                     where order.Field<String>("Выработка") == comboBoxVirabotka.Text
                                                     select order;

            DataView view = query.AsDataView();

            comboBoxBlock.DataSource = view;
            comboBoxBlock.DisplayMember = "Блок";

            comboBoxPodetag.DataSource = view;
            comboBoxPodetag.DisplayMember = "Подэтаж";
        
        }

        private void comboBoxVirabotka_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("выбрана выработка" + comboBoxVirabotka.Text);
            fillComboBox();

        }
    }
}
