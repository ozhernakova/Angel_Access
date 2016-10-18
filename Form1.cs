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
        List <AngelData> chozenZameri;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            aDL = new AngelDataList();
            openFileDialogAccess.Filter = "Таблица с данными PEZ_tbl |*.accdb| файлы Access (*.accdb)|*.accdb";
                       
            // TODO: проверить связь с базой акцесса. Если нет - предложить выбрать путь к ней.

            string path = Properties.Settings.Default.path;
           
            if (File.Exists(path)) 
            {
                aC = new accessConnect(path);
                comboBoxHorizont.DataSource = aC.dtd.horizons;
                comboBoxHorizont.DisplayMember = "Горизонт";
                comboBoxRegion.DataSource = aC.dtd.regions;
                comboBoxRegion.DisplayMember = "Участок";
            }
            else 
            {
                if (openFileDialogAccess.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    path = openFileDialogAccess.FileName;
                    aC = new accessConnect(path);
                    comboBoxHorizont.DataSource = aC.dtd.horizons;
                    comboBoxHorizont.DisplayMember = "Горизонт";
                    comboBoxRegion.DataSource = aC.dtd.regions;
                    comboBoxRegion.DisplayMember = "Участок";
                    Properties.Settings.Default.path = path;
                    Properties.Settings.Default.Save();

                }

                 else
                {
                    labelMissingBase.Text = "путь к базе Access отсутствует. Нельзя определить место измерений, нельзя записать измерения в базу. Пожалуйста, найдите путь к таблице PEZ_tbl.accdb ";
                    button1.Visible = false;
                    comboBoxHorizont.DataSource = null;
                    comboBoxRegion.DataSource = null;
                    groupBoxRegion.Visible = false;
                   
                }
                
            }
  
       } 
    

        private void buttonRegion_Click(object sender, EventArgs e)
        {
            horizonQuery();
            
        }

        void horizonQuery() 
        {
            string tmp1 = comboBoxHorizont.SelectedIndex.ToString();
            string tmp2 = comboBoxRegion.SelectedIndex.ToString();

            int lineNumber = aC.virabotka(tmp1, tmp2);
            NumberOfVirabot.Text = "Найдено выработок: " + lineNumber + " Добавить новую выработку в базу можно только через Access, программу ПЭЗ_И.accdb";
            if (lineNumber > 0)
            {

                comboBoxVirabotka.DataSource = aC.dtd.virabotki;
                comboBoxVirabotka.DisplayMember = "Выработка";
                //groupBoxVirabotka.Visible = true;
                fillComboBox();

                

                //MessageBox.Show("выбрана выработка1" + comboBoxVirabotka.Text);

                this.comboBoxVirabotka.SelectedIndexChanged += new System.EventHandler(this.comboBoxVirabotka_SelectedIndexChanged);

                this.comboBoxHorizont.SelectedIndexChanged += new System.EventHandler(this.comboBoxRegion_SelectedIndexChanged);
                this.comboBoxRegion.SelectedIndexChanged += new System.EventHandler(this.comboBoxRegion_SelectedIndexChanged);



            }

            else
            {
                //groupBoxVirabotka.Visible = false;
                this.comboBoxVirabotka.SelectedIndexChanged -= this.comboBoxVirabotka_SelectedIndexChanged;
                this.comboBoxHorizont.SelectedIndexChanged -= new System.EventHandler(this.comboBoxRegion_SelectedIndexChanged);
                this.comboBoxRegion.SelectedIndexChanged -= new System.EventHandler(this.comboBoxRegion_SelectedIndexChanged);
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
            fillComboBox();
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
                        
                        // зачистили контролы
                        
                        listViewZameri.Clear();
                        aDL = new AngelDataList();
                        dataGridViewZamer.DataSource = null;
                        labelZamer.Text = "Выберите нужные замеры из списка";
                       

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
                        labelUploaded.Text = labelUploaded.Text + " Выделено " + i + " отдельных замеров. ";

                    }

                    
                                                        
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

        
        private void listViewZameri_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Какие замеры мы выбрали? 
            // https://msdn.microsoft.com/ru-ru/library/system.windows.forms.listview.selecteditems(v=vs.110).aspx
            ListView.SelectedListViewItemCollection choice = listViewZameri.SelectedItems;
            
            
            labelZamer.Text = "";
            List <int> ch = new List <int>();
            
            foreach ( ListViewItem item in choice )
	        {
		            labelZamer.Text += item.SubItems[0].Text+" " ;
                    ch.Add (item.Index);
	        }
            if (choice.Count > 0) { 
           chozenZameri = new List<AngelData>();
           chozenZameri = aDL.getchoosenZameri (ch.ToArray());
           dataGridViewZamer.DataSource = chozenZameri;}

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

        private void comboBoxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            horizonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // проверить что данные есть
            if (dataGridViewZamer.RowCount < 1 || comboBoxVirabotka.Text == "" || textBoxPriviazka.Text == "" || textBoxPriviazka.Text == "Привязка места измерения в рамках выработки, блока и подэтажа, выбранных сверху")
            { MessageBox.Show("данные не заполнены"); return; } 
        }

        
    }
}
