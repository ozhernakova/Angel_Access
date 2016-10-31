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
        AccessConnect baseConnection;
        AngelDataList dataToDisplay;
        List <AngelData> chozenZameri;
        string pathToAccess;  // путь к таблице с данными о выработках
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            pathToAccess = Properties.Settings.Default.path;
            // размещаем форму повыше - чтобы лучше помещалась
            this.Location = new System.Drawing.Point(50, 1);
            // выделяем место под данные, которые отображаем
            dataToDisplay = new AngelDataList();

            // проверяем связь с базой акцесса PEZ_tbl. Если нет - нужно выбрать путь к ней и запомнить его в установках.
            // pathToAccess = Properties.Settings.Default.path;//Application.StartupPath;//
            if (File.Exists(pathToAccess + AccessConnect.MAINTABLE)) 
            {
                baseConnection = new AccessConnect(pathToAccess);
                comboBoxes_Load();
            }
            else 
            {
                openFileDialog1.Filter = "Таблица PEZ_tbl |*.accdb| базы Access(*.accdb)|*.accdb";
                openFileDialog1.InitialDirectory = Application.StartupPath;
                openFileDialog1.FileName = "PEZ_tbl";
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pathToAccess = Path.GetDirectoryName(openFileDialog1.FileName);
                    baseConnection = new AccessConnect(pathToAccess);
                    comboBoxes_Load();
                    Properties.Settings.Default.path = pathToAccess;
                    Properties.Settings.Default.Save();
                }

                 else
                {
                    labelMissingBase.Text = "путь к базе Access отсутствует. Нельзя определить место измерений, нельзя записать измерения в базу. Пожалуйста, найдите путь к таблице PEZ_tbl.accdb и перезапустите программу. ";
                    btnWriteToBase.Visible = false;
                    comboBoxHorizont.DataSource = null;
                    comboBoxRegion.DataSource = null;
                    groupBoxRegion.Visible = false;
                    groupBoxVirabotka.Visible = false;
                }
                           
               
            }
            comboBoxPoroda.Visible = false;
            labelPoroda.Visible = false;
            //comboBoxNapravlenie.Visible = false;
            //labelNapravlenie.Visible = false;
        }

        void comboBoxes_Load() 
        {
            comboBoxHorizont.DataSource = baseConnection.dtd.horizons;
            comboBoxHorizont.DisplayMember = "Горизонт";
            comboBoxRegion.DataSource = baseConnection.dtd.regions;
            comboBoxRegion.DisplayMember = "Участок";
            comboBoxNapravlenie.DataSource = baseConnection.dtd.napravlenie;
            comboBoxNapravlenie.DisplayMember = "Направление";
            comboBoxPoroda.DataSource = baseConnection.dtd.porodi;
            comboBoxPoroda.DisplayMember = "Порода";
        }

  

        private void buttonRegion_Click(object sender, EventArgs e)
        {
            horizonQuery();
        }

        void horizonQuery() 
        {
            
            int lineNumber = baseConnection.virabotka(comboBoxHorizont.Text, comboBoxRegion.Text);

            NumberOfVirabot.Visible = true;
            NumberOfVirabot.Text = "Найдено выработок: " + lineNumber; 

            if (lineNumber > 0)
            {
                comboBoxVirabotka.DataSource = baseConnection.dtd.virabotki;
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
            EnumerableRowCollection<DataRow> query = from order in baseConnection.dtd.virabotki.AsEnumerable()
                                                     where order.Field<String>("Выработка") == comboBoxVirabotka.Text
                                                     select order;

            DataView view = query.AsDataView();

            comboBoxBlock.DataSource = view;
            comboBoxBlock.DisplayMember = "Блок";

            comboBoxPodetag.DataSource = view;
            comboBoxPodetag.DisplayMember = "Подэтаж";

            
            // для привязок - показываем варианты выбора (их можно редактировать) и готовим новое поле для нового варианта
            EnumerableRowCollection<DataRow> query1 = from order in baseConnection.dtd.priviazki.AsEnumerable()
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
            openFileDialog1.InitialDirectory = Application.StartupPath; //@"H:\OLYA\mulev\PEZ\PEZ_tbl.accdb";//Properties.Settings.Default.angelpath;
            openFileDialog1.Filter = "txt  (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.FileName = "";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
            //    Properties.Settings.Default.angelpath = Path.GetDirectoryName(openFileDialog1.FileName);
             //   Properties.Settings.Default.Save();
                try
                {
                    if (( openFileDialog1.OpenFile()) != null)
                    {
                        labelUploaded.Text = "Загружен файл с измерениями "+ openFileDialog1.FileName;
                        
                        // зачистили контролы
                        
                        listViewZameri.Clear();
                        dataToDisplay = new AngelDataList();
                        dataGridViewZamer.DataSource = null;
                        labelZamer.Text = "Выберите нужные замеры из списка";
                       
                        file = new StreamReader(openFileDialog1.FileName);
                       
                        string line;
                        while ((line = file.ReadLine()) != null)
                        {
                            dataToDisplay.addAngelData(line);
                        }
                        dataToDisplay.divideIntoZameri();

                    }
                                                      
                    // добавляем элемент в ListView
                    listViewZameri.Items.AddRange(dataToDisplay.lvi_list.ToArray());
                    // Create some column headers for the data. 
                    listViewZameriHeader();
                    labelUploaded.Text = labelUploaded.Text + " Выделено " + listViewZameri.Items.Count + " отдельных замеров. ";
                   
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
           chozenZameri = dataToDisplay.collectSelectedZameri (ch.ToArray());
           dataGridViewZamer.DataSource = chozenZameri;}
        }

        void hideSelectedZameri() 
        {
            foreach (ListViewItem item in listViewZameri.SelectedItems)
            {
                listViewZameri.Items.Remove(item);
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

        
        private void button1_Click(object sender, EventArgs e)
        {
            printAndsendToAccess();
        }
        void printAndsendToAccess(){
            // проверить что данные есть
            int num = dataGridViewZamer.RowCount;
            if (num < 1)
                    { MessageBox.Show("замеры не выбраны"); return; }
            if (textBoxPriviazka.Text == "")
                { MessageBox.Show("Отсутствует привязка"); return; }

            string[] param = new string[] { num.ToString(), labelHor.Text, labelReg.Text, comboBoxVirabotka.Text, comboBoxBlock.Text, comboBoxPodetag.Text, textBoxPriviazka.Text, comboBoxNapravlenie.Text, listViewZameri.SelectedItems.Count.ToString() };
            string tmp =
                string.Format("Записываем в базу все выбранные замеры. \n \n Количество отдельных замеров {8}, общее количество записей: {0},  \n Измерения были проведены в следующем месте: \n Горизонт: {1} \n Участок: {2} \n Выработка: {3} \n Блок: {4} \n Подэтаж: {5} \n Привязка: {6} \n Направление: {7} ", param);
        
            DialogResult result = MessageBox.Show(tmp, "Подтвердите!", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK) 
            {
                // проверяем таблицу Центр и уточняем породу если требуется
                baseConnection.setAllids(param);
                if (baseConnection.check_Porodaid(param[6]) == -1)                     // и нужно запустить окно для выбора породы
                {
                    string question = string.Format("В параметрах места замера выбраны Выработка: {3}, Привязка: {6}, Направление: {7}. В базе данных не найдено такого сочетания параметров. Чтобы добавить этот центр измерений в базу, пожалуйста, уточните породу:", param);

                    askPoroda Cdialog = new askPoroda(question, baseConnection.dtd);
                    if ( Cdialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;
                }
                if (baseConnection.SaveAngel(chozenZameri, param))
                { 
                    MessageBox.Show("Записали!");
                    hideSelectedZameri();
                    printingDialog();
                }
                else MessageBox.Show("Запись не удалась, поэтому на печать тоже не отправляли");
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // запуск Access 
            string path = Path.GetDirectoryName (pathToAccess);//Properties.Settings.Default.path

            Process.Start(path + AccessConnect.TABLETOADD);

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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            

            Graphics g = e.Graphics;

            Font font = new Font("Courier New", 14); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = e.MarginBounds.X;
            int endX = e.MarginBounds.Right;
            int startY = e.MarginBounds.Y;
            int offset = startY;
            SolidBrush sb = new SolidBrush(Color.Black);
            Pen pen = new Pen (sb);

            Font fb = new Font("Courier New", 12, FontStyle.Bold);
            Font fontSmall = new Font("Courier New", 10);
            float fontSmallHeight = fontSmall.GetHeight();

            // дата измерений - chozenZameri[0].Dt
            g.DrawString(string.Format("Дата замера: {0:f}, прибор \"Ангел\" №_____", DateTime.Now), new Font("Courier New", 15), sb, startX, offset);
            offset = offset + (int)fontHeight*2; 
            g.DrawString("Участок: " + labelReg.Text, font, sb, startX, offset);
            offset = offset + (int)fontHeight;  
            g.DrawString("Горизонт: " + labelHor.Text + "  Блок № " + comboBoxBlock.Text, font, sb, startX, offset);
            offset = offset + (int)fontHeight;  
            g.DrawString("Выработка: " + comboBoxVirabotka.Text, font, sb, startX, offset);
            offset = offset + (int)fontHeight;  
            g.DrawString("Диаметр: 2,5  3,5 другой(_______________) ", font, sb, startX, offset);
            offset = offset + (int)fontHeight;  
            g.DrawString("Привязка: " + textBoxPriviazka.Text, font, sb, startX, offset);
            offset = offset + (int)fontHeight;
            string poroda = "n/a";
            if (baseConnection.dtd.Poroda != null) poroda = baseConnection.dtd.Poroda;
            g.DrawString("Порода: " +poroda , font, sb, startX, offset);
            offset = offset + (int)fontHeight; 
            g.DrawString("P норм, Ом/м _________Оператор ______________"  , font, sb, startX, offset);
            offset = offset + (int)fontHeight*2; 

    
            Rectangle one = new Rectangle(startX, offset, e.MarginBounds.Width / 4, (int)fontHeight * 2);
            g.DrawString("Вдоль выработки", font, sb, one);
            g.DrawRectangle(pen, one);

            Rectangle two = new Rectangle(startX + e.MarginBounds.Width / 4, offset, e.MarginBounds.Width / 4, (int)fontHeight * 2);
            g.DrawString("Поперек выработки", font, sb, two);
            g.DrawRectangle(pen, two);

            Rectangle three = new Rectangle(startX + e.MarginBounds.Width / 2, offset, e.MarginBounds.Width / 4, (int)fontHeight * 2);
            g.DrawString("Вертикально", font, sb, three);
            g.DrawRectangle(pen, three);

            Rectangle four = new Rectangle(startX + 3 * e.MarginBounds.Width / 4, offset, e.MarginBounds.Width / 4, (int)fontHeight * 2);
            g.DrawString("Категория удароопасности", fontSmall, sb, four);
            g.DrawRectangle(pen, four);

            offset = offset + (int)fontHeight * 2;

            Rectangle five = new Rectangle(startX, offset, e.MarginBounds.Width / 8, (int)fontHeight * 4);
            g.DrawString(" normal", fontSmall, sb, five);
            g.DrawRectangle(pen, five);

            Rectangle six = new Rectangle(startX + e.MarginBounds.Width / 8, offset, e.MarginBounds.Width / 8, (int)fontHeight * 4);
            g.DrawString(" danger", fontSmall, sb, six);
            g.DrawRectangle(pen, six);

            Rectangle seven = new Rectangle(startX + e.MarginBounds.Width / 4, offset, e.MarginBounds.Width / 8, (int)fontHeight * 4);
            g.DrawString(" normal", fontSmall, sb, seven);
            g.DrawRectangle(pen, seven);

            Rectangle eight = new Rectangle(startX + 3 * e.MarginBounds.Width / 8, offset, e.MarginBounds.Width / 8, (int)fontHeight * 4);
            g.DrawString(" danger", fontSmall, sb, eight);
            g.DrawRectangle(pen, eight);

            Rectangle nine = new Rectangle(startX + e.MarginBounds.Width / 2, offset, e.MarginBounds.Width / 8, (int)fontHeight * 4);
            g.DrawString(" normal", fontSmall, sb, nine);
            g.DrawRectangle(pen, nine);

            Rectangle ten = new Rectangle(startX + 5 * e.MarginBounds.Width / 8, offset, e.MarginBounds.Width / 8, (int)fontHeight * 4);
            g.DrawString(" danger", fontSmall, sb, ten);
            g.DrawRectangle(pen, ten);

            Rectangle eleven = new Rectangle(startX + 3 * e.MarginBounds.Width / 4, offset, e.MarginBounds.Width / 4, (int)fontHeight * 4);
            g.DrawRectangle(pen, eleven);

            g.DrawLine(pen, new Point(startX, offset + (int)fontSmallHeight), new Point(endX, offset + (int)fontSmallHeight));
            offset = offset + (int)fontHeight * 2;
            Rectangle twelve = new Rectangle(startX + 3 * e.MarginBounds.Width / 4, offset, e.MarginBounds.Width / 4, (int)fontHeight * 4);
            g.DrawString(" неопасно опасно", fontSmall, sb, twelve);
            offset = offset + (int)fontHeight * 3;


            //foreach (AngelData item in chozenZameri)
            //{
                //create the string to print on the reciept
                //string productDescription = item;
                //string productTotal = item.Substring(item.Length - 6, 6);
                


                //    graphic.DrawString(productLine, new Font("Courier New", 12, FontStyle.Italic), new SolidBrush(Color.Red), startX, startY + offset);

                //    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                //}
                //else
                //{
                //    string productLine = productDescription;

                //    graphic.DrawString(productLine, font, new SolidBrush(Color.Black), startX, startY + offset);

                //    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                //}

           // }



            ////when we have drawn all of the items add the total

            //offset = offset + 20; //make some room so that the total stands out.

            //graphic.DrawString("Total to pay ".PadRight(30) + String.Format("{0:c}", totalprice), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

            //offset = offset + 30; //make some room so that the total stands out.
            //graphic.DrawString("CASH ".PadRight(30) + String.Format("{0:c}", cash), font, new SolidBrush(Color.Black), startX, startY + offset);
            //offset = offset + 15;
            //graphic.DrawString("CHANGE ".PadRight(30) + String.Format("{0:c}", change), font, new SolidBrush(Color.Black), startX, startY + offset);
            //offset = offset + 30; //make some room so that the total stands out.
            //graphic.DrawString("     Thank-you for your custom,", font, new SolidBrush(Color.Black), startX, startY + offset);
            //offset = offset + 15;
            //graphic.DrawString("       please come back soon!", font, new SolidBrush(Color.Black), startX, startY + offset);
            g.DrawLine(pen, new Point(startX, offset), new Point(endX, offset));
            offset = offset + (int)fontHeight;

            g.DrawString(string.Format("ш. Таштагольская, дата распечатки: {0:f} ", DateTime.Now), new Font("Courier New", 12, FontStyle.Italic), sb, startX, offset);
  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printingDialog();
        }
        void printingDialog() 
        {
            PrintDialog pdi = new PrintDialog();
            pdi.Document = printDocument1;
            if (pdi.ShowDialog() == DialogResult.OK)
            {
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                    MessageBox.Show("Отправлено на печать");
                }
            }
            else
            {
                MessageBox.Show("Печать отменена");
            }
        }

        private void textBoxPriviazka_Validating(object sender, CancelEventArgs e)
        {
            // смотрим что там такое введено и проверяем таблицу с привязками - есть ли там такой вариант

        }

                
    }
}
