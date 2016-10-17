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
        AngelDataList aDL;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            aC = new accessConnect();
            aDL = new AngelDataList();
          

            // TODO: проверить связь с базой акцесса. Если нет - предложить выбрать путь к ней.
            
            

            comboBoxHorizont.DataSource = aC.dtd.horizons;
            comboBoxHorizont.DisplayMember = "Горизонт";

           // comboBoxRegion.DataSource = aC.dtd.regions.Tables[0];
            comboBoxRegion.DataSource = aC.dtd.regions;
            comboBoxRegion.DisplayMember = "Участок";

            dateTimePicker1.Value = DateTime.Today;

    

        }

        private void buttonRegion_Click(object sender, EventArgs e)
        {
            string tmp1 = comboBoxHorizont.SelectedIndex.ToString();
            string tmp2 = comboBoxRegion.SelectedIndex.ToString();

            int lineNumber = aC.virabotka(tmp1, tmp2);
            NumberOfVirabot.Text = "Найдено выработок: " + lineNumber + " Добавить новую выработку в базу можно только через Access, программу ПЭЗ_И.accdb";
            if (lineNumber > 0)
            {

                comboBoxVirabotka.DataSource = aC.dtd.virabotki;
                comboBoxVirabotka.DisplayMember = "Выработка";
                groupBoxVirabotka.Visible = true;
                fillComboBox();

                //MessageBox.Show("выбрана выработка1" + comboBoxVirabotka.Text);

                this.comboBoxVirabotka.SelectedIndexChanged += new System.EventHandler(this.comboBoxVirabotka_SelectedIndexChanged);

                //comboBoxBlock.DataSource = aC.dtd.virabotki;
                //comboBoxBlock.DisplayMember = "Блок";

                //comboBoxPodetag.DataSource = aC.dtd.virabotki;
                //comboBoxPodetag.DisplayMember = "Подэтаж";
                
 


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
            // про dataview http://www.c-sharpcorner.com/article/dataview-in-C-Sharp/
            // и http://csharp.net-informations.com/dataview/create-dataview.htm
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
          //  MessageBox.Show("выбрана выработка2" + comboBoxVirabotka.Text);
            fillComboBox();

        }

        private void comboBoxPodetag_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonUploadData_Click(object sender, EventArgs e)
        {
            // загрузить файл с данными
            StreamReader file = null;
            openFileDialog1.InitialDirectory = "h:\\OLYA\\mulev\angel";
            openFileDialog1.Filter = "txt  (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    if (( openFileDialog1.OpenFile()) != null)
                    {
                        labelUploaded.Text = "Загружен файл с измерениями "+ openFileDialog1.FileName;
                        labelDataGridInfo.Text = "";
                        // зачистили контролы
                        dataGridViewAllAngel.DataSource = null;
                        listViewZameri.Clear();
                        aDL = new AngelDataList();
                       

                        file = new StreamReader(openFileDialog1.FileName);
                        int counter = 0;
                        string line;
                        while ((line = file.ReadLine()) != null)
                        {
                            System.Console.WriteLine(line);
                            aDL.addAngelData(line);
                            counter++;
                        }
                        int i = aDL.zameri();
                        labelUploaded.Text = labelUploaded.Text + " Выделено " + i + " отдельных замеров";

                    }

                    labelDataGridInfo.Text = "Считанный файл в табличной форме";
                    dataGridViewAllAngel.DataSource = aDL.adl;
                    dataGridViewAllAngel.Update();
                                    
                    // добавляем элемент в ListView
                    listViewZameri.Items.AddRange(aDL.lvi_list.ToArray());
                    // Create some column headers for the data. 
                    listViewZameriHeader();
            
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при чтении файла данных. Текст ошибки: " + ex.Message);
                }
            
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listViewZameri_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Какие замеры мы выбрали?
            ListView.SelectedListViewItemCollection choice = listViewZameri.SelectedItems;
            label8.Text = "";
            foreach ( ListViewItem item in choice )
	        {
		            label8.Text += item.SubItems[0].Text+" " ;
	        }

           

        }

        void listViewZameriHeader()
        {
            ColumnHeader columnheader = new ColumnHeader();
            columnheader.Text = "Замер ";
            this.listViewZameri.Columns.Add(columnheader);

            columnheader = new ColumnHeader();
            columnheader.Text = "Линия ";
            this.listViewZameri.Columns.Add(columnheader);

            columnheader = new ColumnHeader();
            columnheader.Text = "Пикет ";
            this.listViewZameri.Columns.Add(columnheader);

            // Loop through and size each column header to fit the column header text.
            foreach (ColumnHeader ch in this.listViewZameri.Columns)
            {
                ch.Width = -2;
            }

            this.listViewZameri.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            
        
        }
    }
}
