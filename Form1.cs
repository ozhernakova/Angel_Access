using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
            // размещаем форму повыше - чтобы лучше помещалась
            this.Location = new System.Drawing.Point(50, 1);
            // выделяем место под данные, которые отображаем
            aDL = new AngelDataList();

            // проверяем связь с базой акцесса PEZ_tbl. Если нет - нужно выбрать путь к ней и запомнить его в установках.
            string path = Properties.Settings.Default.path;
            if (File.Exists(path)) 
            {
                aC = new accessConnect(path);
                comboBoxes_Load();
            }
            else 
            {
                openFileDialog1.Filter = "Таблица PEZ_tbl |*.accdb| базы Access(*.accdb)|*.accdb";
                openFileDialog1.InitialDirectory = Application.StartupPath;
                openFileDialog1.FileName = "PEZ_tbl";
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    path = openFileDialog1.FileName;
                    aC = new accessConnect(path);
                    comboBoxes_Load();
                    Properties.Settings.Default.path = path;
                    Properties.Settings.Default.Save();
                }

                 else
                {
                    labelMissingBase.Text = "путь к базе Access отсутствует. Нельзя определить место измерений, нельзя записать измерения в базу. Пожалуйста, найдите путь к таблице PEZ_tbl.accdb и перезапустите программу. ";
                    button1.Visible = false;
                    comboBoxHorizont.DataSource = null;
                    comboBoxRegion.DataSource = null;
                    groupBoxRegion.Visible = false;
                    groupBoxVirabotka.Visible = false;
                }
                
            }
  
       }

        void comboBoxes_Load() 
        {
            comboBoxHorizont.DataSource = aC.dtd.horizons;
            comboBoxHorizont.DisplayMember = "Горизонт";
            comboBoxRegion.DataSource = aC.dtd.regions;
            comboBoxRegion.DisplayMember = "Участок";
            comboBoxNapravlenie.DataSource = aC.dtd.napravlenie;
            comboBoxNapravlenie.DisplayMember = "Направление";
        }

  

        private void buttonRegion_Click(object sender, EventArgs e)
        {
            horizonQuery();
        }

        void horizonQuery() 
        {
            
            int lineNumber = aC.virabotka(comboBoxHorizont.Text, comboBoxRegion.Text);

            NumberOfVirabot.Visible = true;
            NumberOfVirabot.Text = "Найдено выработок: " + lineNumber; 

            if (lineNumber > 0)
            {
                comboBoxVirabotka.DataSource = aC.dtd.virabotki;
                comboBoxVirabotka.DisplayMember = "Выработка";
                groupBoxVirabotka.Visible = true;
                fillComboBox();
                labelHor.Text = "Выработки для горизонта " + comboBoxHorizont.Text + " и участка " + comboBoxRegion.Text;
                this.comboBoxVirabotka.SelectedIndexChanged += new System.EventHandler(this.comboBoxVirabotka_SelectedIndexChanged);
                labelHor.Text = comboBoxHorizont.Text;
                labelReg.Text = comboBoxRegion.Text;
            }

            else
            {
                comboBoxVirabotka.DataSource = null;
                comboBoxPriviazka.Text = "";
                labelHor.Text = "";
                labelReg.Text = "";
                this.comboBoxVirabotka.SelectedIndexChanged -= this.comboBoxVirabotka_SelectedIndexChanged;
                MessageBox.Show(@"в базе не найдены выработки для горизонта  " + comboBoxHorizont.Text + " и участка " + comboBoxRegion.Text + "\n" + "Добавить новую выработку в базу можно только через форму ПЭЗ_И.accdb", "Выработки не найдены", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            
            // для привязок - показываем варианты выбора (их можно редактировать) и готовим новое поле для нового варианта
            EnumerableRowCollection<DataRow> query1 = from order in aC.dtd.priviazki.AsEnumerable()
                                                     where order.Field<String>("Выработка") == comboBoxVirabotka.Text
                                                     select order;
            DataView view1 = query1.AsDataView();

            comboBoxPriviazka.DataSource = view1;
            comboBoxPriviazka.DisplayMember = "Привязка";

            textBoxPriviazka.Text = "";
            
        }

        

        private void comboBoxVirabotka_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillComboBox();
        }

        private void buttonUploadData_Click(object sender, EventArgs e)
        {
            // загрузить файл с данными
            StreamReader file = null;
            openFileDialog1.InitialDirectory = Properties.Settings.Default.angelpath;
               // Application.StartupPath;  // поставить текущую
            openFileDialog1.Filter = "txt  (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.FileName = "";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.angelpath = Path.GetDirectoryName(openFileDialog1.FileName);
                Properties.Settings.Default.Save();
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
                           // System.Console.WriteLine(line);
                            aDL.addAngelData(line);
                            counter++;
                        }
                        int i = aDL.zameri();
                        labelUploaded.Text = labelUploaded.Text + " Найдено " + i + " отдельных замеров. ";

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

              

        private void updateSelectionData()
        {
                        // Какие замеры мы выбрали? 
            // https://msdn.microsoft.com/ru-ru/library/system.windows.forms.listview.selecteditems(v=vs.110).aspx
            // было на private void listViewZameri_SelectedIndexChanged(object sender, EventArgs e), но если выбирается много, очень медленно работает
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

        
        private void button1_Click(object sender, EventArgs e)
        {
            // проверить что данные есть
            int num = dataGridViewZamer.RowCount;
            if (num < 1)
                    { MessageBox.Show("замеры не выбраны"); return; }
            if (textBoxPriviazka.Text == "")
                { MessageBox.Show("Отсутствует привязка"); return; }

            string[] param = new string[] {num.ToString(), labelHor.Text, labelReg.Text, comboBoxVirabotka.Text, comboBoxBlock.Text, comboBoxPodetag.Text, textBoxPriviazka.Text, comboBoxNapravlenie.Text };
            string tmp = 
                string.Format("Записываем в базу все выбранные замеры. Количество записей: {0} \n Измерения были проведены в следующем месте: \n Горизонт: {1} \n Участок: {2} \n Выработка: {3} \n Блок: {4} \n Подэтаж: {5} \n Привязка: {6} \n Направление: {7}", param);
        
            DialogResult result = MessageBox.Show(tmp, "Подтвердите!", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK) 
            {
                // проверяем таблицу Центр и уточняем породу если требуется
                //aC.setAllids(param);
                if (aC.SaveAngel(chozenZameri, param)) MessageBox.Show ("Записали!");
                else MessageBox.Show("Запись не удалась");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // запуск Access 
            string pathtobase = Path.GetDirectoryName (Properties.Settings.Default.path);

            Process.Start(pathtobase + "\\ПЭЗ_И.accdb");

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void listViewZameri_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyValue != 16 && e.KeyValue != 17)
            {
                updateSelectionData();
            }
        
        }

        private void listViewZameri_Click(object sender, EventArgs e)
        {
            updateSelectionData();
        }

        private void comboBoxPriviazka_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxPriviazka.Text = comboBoxPriviazka.Text;
        }
        
    }
}
