namespace Angel_Access
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.comboBoxHorizont = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxRegion = new System.Windows.Forms.ComboBox();
            this.NumberOfVirabot = new System.Windows.Forms.Label();
            this.groupBoxRegion = new System.Windows.Forms.GroupBox();
            this.btnAccessStart = new System.Windows.Forms.Button();
            this.buttonRegion = new System.Windows.Forms.Button();
            this.groupBoxFromFile = new System.Windows.Forms.GroupBox();
            this.listViewZameri = new System.Windows.Forms.ListView();
            this.buttonUploadData = new System.Windows.Forms.Button();
            this.labelUploaded = new System.Windows.Forms.Label();
            this.groupBoxZamer = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBoxVirabotka = new System.Windows.Forms.GroupBox();
            this.labelDiametr = new System.Windows.Forms.Label();
            this.comboBoxPoroda = new System.Windows.Forms.ComboBox();
            this.labelPoroda = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelReg = new System.Windows.Forms.Label();
            this.labelHor = new System.Windows.Forms.Label();
            this.textBoxPriviazka = new System.Windows.Forms.TextBox();
            this.comboBoxPriviazka = new System.Windows.Forms.ComboBox();
            this.comboBoxNapravlenie = new System.Windows.Forms.ComboBox();
            this.labelNapravlenie = new System.Windows.Forms.Label();
            this.comboBoxVirabotka = new System.Windows.Forms.ComboBox();
            this.comboBoxBlock = new System.Windows.Forms.ComboBox();
            this.comboBoxPodetag = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnWriteToBase = new System.Windows.Forms.Button();
            this.dataGridViewZamer = new System.Windows.Forms.DataGridView();
            this.labelZamer = new System.Windows.Forms.Label();
            this.labelMissingBase = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.groupBoxRegion.SuspendLayout();
            this.groupBoxFromFile.SuspendLayout();
            this.groupBoxZamer.SuspendLayout();
            this.groupBoxVirabotka.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewZamer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Горизонт";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = " ";
            // 
            // comboBoxHorizont
            // 
            this.comboBoxHorizont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHorizont.FormattingEnabled = true;
            this.comboBoxHorizont.Location = new System.Drawing.Point(58, 89);
            this.comboBoxHorizont.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxHorizont.MaxDropDownItems = 12;
            this.comboBoxHorizont.Name = "comboBoxHorizont";
            this.comboBoxHorizont.Size = new System.Drawing.Size(135, 21);
            this.comboBoxHorizont.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Участок";
            // 
            // comboBoxRegion
            // 
            this.comboBoxRegion.CausesValidation = false;
            this.comboBoxRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRegion.FormattingEnabled = true;
            this.comboBoxRegion.Location = new System.Drawing.Point(58, 48);
            this.comboBoxRegion.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxRegion.Name = "comboBoxRegion";
            this.comboBoxRegion.Size = new System.Drawing.Size(135, 21);
            this.comboBoxRegion.TabIndex = 3;
            // 
            // NumberOfVirabot
            // 
            this.NumberOfVirabot.AutoSize = true;
            this.NumberOfVirabot.Location = new System.Drawing.Point(4, 181);
            this.NumberOfVirabot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NumberOfVirabot.MaximumSize = new System.Drawing.Size(202, 0);
            this.NumberOfVirabot.Name = "NumberOfVirabot";
            this.NumberOfVirabot.Size = new System.Drawing.Size(109, 13);
            this.NumberOfVirabot.TabIndex = 11;
            this.NumberOfVirabot.Text = "Найдено выработок";
            // 
            // groupBoxRegion
            // 
            this.groupBoxRegion.Controls.Add(this.btnAccessStart);
            this.groupBoxRegion.Controls.Add(this.buttonRegion);
            this.groupBoxRegion.Controls.Add(this.NumberOfVirabot);
            this.groupBoxRegion.Controls.Add(this.label2);
            this.groupBoxRegion.Controls.Add(this.comboBoxRegion);
            this.groupBoxRegion.Controls.Add(this.label1);
            this.groupBoxRegion.Controls.Add(this.comboBoxHorizont);
            this.groupBoxRegion.Location = new System.Drawing.Point(16, 2);
            this.groupBoxRegion.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxRegion.Name = "groupBoxRegion";
            this.groupBoxRegion.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxRegion.Size = new System.Drawing.Size(210, 261);
            this.groupBoxRegion.TabIndex = 12;
            this.groupBoxRegion.TabStop = false;
            this.groupBoxRegion.Text = "Выбор района";
            // 
            // btnAccessStart
            // 
            this.btnAccessStart.Location = new System.Drawing.Point(7, 215);
            this.btnAccessStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccessStart.Name = "btnAccessStart";
            this.btnAccessStart.Size = new System.Drawing.Size(186, 34);
            this.btnAccessStart.TabIndex = 12;
            this.btnAccessStart.Text = "Запустить форму ПЭЗ_И для добавления выработок";
            this.btnAccessStart.UseVisualStyleBackColor = true;
            this.btnAccessStart.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonRegion
            // 
            this.buttonRegion.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRegion.Location = new System.Drawing.Point(7, 128);
            this.buttonRegion.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRegion.Name = "buttonRegion";
            this.buttonRegion.Size = new System.Drawing.Size(188, 41);
            this.buttonRegion.TabIndex = 4;
            this.buttonRegion.Text = "Показать выработки для этого района";
            this.buttonRegion.UseVisualStyleBackColor = false;
            this.buttonRegion.Click += new System.EventHandler(this.buttonRegion_Click);
            // 
            // groupBoxFromFile
            // 
            this.groupBoxFromFile.Controls.Add(this.listViewZameri);
            this.groupBoxFromFile.Controls.Add(this.buttonUploadData);
            this.groupBoxFromFile.Controls.Add(this.labelUploaded);
            this.groupBoxFromFile.Location = new System.Drawing.Point(16, 280);
            this.groupBoxFromFile.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxFromFile.Name = "groupBoxFromFile";
            this.groupBoxFromFile.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxFromFile.Size = new System.Drawing.Size(210, 332);
            this.groupBoxFromFile.TabIndex = 15;
            this.groupBoxFromFile.TabStop = false;
            this.groupBoxFromFile.Text = "Загрузить данные Ангела";
            // 
            // listViewZameri
            // 
            this.listViewZameri.FullRowSelect = true;
            this.listViewZameri.GridLines = true;
            this.listViewZameri.Location = new System.Drawing.Point(7, 120);
            this.listViewZameri.Margin = new System.Windows.Forms.Padding(2);
            this.listViewZameri.Name = "listViewZameri";
            this.listViewZameri.Size = new System.Drawing.Size(188, 174);
            this.listViewZameri.TabIndex = 17;
            this.listViewZameri.UseCompatibleStateImageBehavior = false;
            this.listViewZameri.View = System.Windows.Forms.View.Details;
            this.listViewZameri.Click += new System.EventHandler(this.listViewZameri_Click);
            this.listViewZameri.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewZameri_KeyUp);
            // 
            // buttonUploadData
            // 
            this.buttonUploadData.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonUploadData.Location = new System.Drawing.Point(7, 24);
            this.buttonUploadData.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUploadData.Name = "buttonUploadData";
            this.buttonUploadData.Size = new System.Drawing.Size(188, 41);
            this.buttonUploadData.TabIndex = 3;
            this.buttonUploadData.Text = "Загрузить данные";
            this.buttonUploadData.UseVisualStyleBackColor = false;
            this.buttonUploadData.Click += new System.EventHandler(this.buttonUploadData_Click);
            // 
            // labelUploaded
            // 
            this.labelUploaded.AutoSize = true;
            this.labelUploaded.Location = new System.Drawing.Point(10, 67);
            this.labelUploaded.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUploaded.MaximumSize = new System.Drawing.Size(188, 0);
            this.labelUploaded.Name = "labelUploaded";
            this.labelUploaded.Size = new System.Drawing.Size(0, 13);
            this.labelUploaded.TabIndex = 2;
            // 
            // groupBoxZamer
            // 
            this.groupBoxZamer.AutoSize = true;
            this.groupBoxZamer.Controls.Add(this.button3);
            this.groupBoxZamer.Controls.Add(this.groupBoxVirabotka);
            this.groupBoxZamer.Controls.Add(this.btnWriteToBase);
            this.groupBoxZamer.Controls.Add(this.dataGridViewZamer);
            this.groupBoxZamer.Controls.Add(this.labelZamer);
            this.groupBoxZamer.Location = new System.Drawing.Point(244, 5);
            this.groupBoxZamer.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxZamer.Name = "groupBoxZamer";
            this.groupBoxZamer.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxZamer.Size = new System.Drawing.Size(518, 608);
            this.groupBoxZamer.TabIndex = 16;
            this.groupBoxZamer.TabStop = false;
            this.groupBoxZamer.Text = "Привязка измерений по месту";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(286, 516);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(176, 40);
            this.button3.TabIndex = 12;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBoxVirabotka
            // 
            this.groupBoxVirabotka.Controls.Add(this.labelDiametr);
            this.groupBoxVirabotka.Controls.Add(this.comboBoxPoroda);
            this.groupBoxVirabotka.Controls.Add(this.labelPoroda);
            this.groupBoxVirabotka.Controls.Add(this.label9);
            this.groupBoxVirabotka.Controls.Add(this.labelReg);
            this.groupBoxVirabotka.Controls.Add(this.labelHor);
            this.groupBoxVirabotka.Controls.Add(this.textBoxPriviazka);
            this.groupBoxVirabotka.Controls.Add(this.comboBoxPriviazka);
            this.groupBoxVirabotka.Controls.Add(this.comboBoxNapravlenie);
            this.groupBoxVirabotka.Controls.Add(this.labelNapravlenie);
            this.groupBoxVirabotka.Controls.Add(this.comboBoxVirabotka);
            this.groupBoxVirabotka.Controls.Add(this.comboBoxBlock);
            this.groupBoxVirabotka.Controls.Add(this.comboBoxPodetag);
            this.groupBoxVirabotka.Controls.Add(this.label3);
            this.groupBoxVirabotka.Controls.Add(this.label4);
            this.groupBoxVirabotka.Controls.Add(this.label5);
            this.groupBoxVirabotka.Controls.Add(this.label7);
            this.groupBoxVirabotka.Location = new System.Drawing.Point(5, 18);
            this.groupBoxVirabotka.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxVirabotka.Name = "groupBoxVirabotka";
            this.groupBoxVirabotka.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxVirabotka.Size = new System.Drawing.Size(505, 194);
            this.groupBoxVirabotka.TabIndex = 11;
            this.groupBoxVirabotka.TabStop = false;
            // 
            // labelDiametr
            // 
            this.labelDiametr.AutoSize = true;
            this.labelDiametr.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDiametr.Location = new System.Drawing.Point(485, 41);
            this.labelDiametr.Name = "labelDiametr";
            this.labelDiametr.Size = new System.Drawing.Size(15, 13);
            this.labelDiametr.TabIndex = 22;
            this.labelDiametr.Text = "D";
            // 
            // comboBoxPoroda
            // 
            this.comboBoxPoroda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPoroda.FormattingEnabled = true;
            this.comboBoxPoroda.Location = new System.Drawing.Point(363, 154);
            this.comboBoxPoroda.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxPoroda.Name = "comboBoxPoroda";
            this.comboBoxPoroda.Size = new System.Drawing.Size(122, 21);
            this.comboBoxPoroda.TabIndex = 21;
            // 
            // labelPoroda
            // 
            this.labelPoroda.AutoSize = true;
            this.labelPoroda.Location = new System.Drawing.Point(303, 158);
            this.labelPoroda.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPoroda.Name = "labelPoroda";
            this.labelPoroda.Size = new System.Drawing.Size(45, 13);
            this.labelPoroda.TabIndex = 20;
            this.labelPoroda.Text = "Порода";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 15);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(172, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Выбранные горизонт и участок: ";
            // 
            // labelReg
            // 
            this.labelReg.AutoSize = true;
            this.labelReg.Location = new System.Drawing.Point(278, 15);
            this.labelReg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelReg.Name = "labelReg";
            this.labelReg.Size = new System.Drawing.Size(0, 13);
            this.labelReg.TabIndex = 18;
            // 
            // labelHor
            // 
            this.labelHor.AutoSize = true;
            this.labelHor.Location = new System.Drawing.Point(188, 15);
            this.labelHor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHor.Name = "labelHor";
            this.labelHor.Size = new System.Drawing.Size(0, 13);
            this.labelHor.TabIndex = 17;
            // 
            // textBoxPriviazka
            // 
            this.textBoxPriviazka.Location = new System.Drawing.Point(164, 124);
            this.textBoxPriviazka.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPriviazka.Name = "textBoxPriviazka";
            this.textBoxPriviazka.Size = new System.Drawing.Size(304, 20);
            this.textBoxPriviazka.TabIndex = 14;
            this.textBoxPriviazka.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPriviazka_Validating);
            // 
            // comboBoxPriviazka
            // 
            this.comboBoxPriviazka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPriviazka.FormattingEnabled = true;
            this.comboBoxPriviazka.Location = new System.Drawing.Point(188, 124);
            this.comboBoxPriviazka.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxPriviazka.Name = "comboBoxPriviazka";
            this.comboBoxPriviazka.Size = new System.Drawing.Size(298, 21);
            this.comboBoxPriviazka.TabIndex = 11;
            this.comboBoxPriviazka.SelectedIndexChanged += new System.EventHandler(this.comboBoxPriviazka_SelectedIndexChanged);
            // 
            // comboBoxNapravlenie
            // 
            this.comboBoxNapravlenie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNapravlenie.FormattingEnabled = true;
            this.comboBoxNapravlenie.Location = new System.Drawing.Point(164, 155);
            this.comboBoxNapravlenie.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxNapravlenie.Name = "comboBoxNapravlenie";
            this.comboBoxNapravlenie.Size = new System.Drawing.Size(122, 21);
            this.comboBoxNapravlenie.TabIndex = 13;
            // 
            // labelNapravlenie
            // 
            this.labelNapravlenie.AutoSize = true;
            this.labelNapravlenie.Location = new System.Drawing.Point(10, 158);
            this.labelNapravlenie.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNapravlenie.Name = "labelNapravlenie";
            this.labelNapravlenie.Size = new System.Drawing.Size(75, 13);
            this.labelNapravlenie.TabIndex = 12;
            this.labelNapravlenie.Text = "Направление";
            // 
            // comboBoxVirabotka
            // 
            this.comboBoxVirabotka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVirabotka.FormattingEnabled = true;
            this.comboBoxVirabotka.Location = new System.Drawing.Point(164, 37);
            this.comboBoxVirabotka.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxVirabotka.Name = "comboBoxVirabotka";
            this.comboBoxVirabotka.Size = new System.Drawing.Size(321, 21);
            this.comboBoxVirabotka.TabIndex = 5;
            // 
            // comboBoxBlock
            // 
            this.comboBoxBlock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBlock.FormattingEnabled = true;
            this.comboBoxBlock.Location = new System.Drawing.Point(164, 61);
            this.comboBoxBlock.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxBlock.Name = "comboBoxBlock";
            this.comboBoxBlock.Size = new System.Drawing.Size(321, 21);
            this.comboBoxBlock.TabIndex = 4;
            // 
            // comboBoxPodetag
            // 
            this.comboBoxPodetag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPodetag.FormattingEnabled = true;
            this.comboBoxPodetag.Location = new System.Drawing.Point(164, 82);
            this.comboBoxPodetag.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxPodetag.Name = "comboBoxPodetag";
            this.comboBoxPodetag.Size = new System.Drawing.Size(321, 21);
            this.comboBoxPodetag.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Блок";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Подэтаж";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 39);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Выработка";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 125);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.MaximumSize = new System.Drawing.Size(150, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 26);
            this.label7.TabIndex = 2;
            this.label7.Text = "Привязка замеров: (введите или выберите)";
            // 
            // btnWriteToBase
            // 
            this.btnWriteToBase.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnWriteToBase.Location = new System.Drawing.Point(11, 515);
            this.btnWriteToBase.Margin = new System.Windows.Forms.Padding(2);
            this.btnWriteToBase.Name = "btnWriteToBase";
            this.btnWriteToBase.Size = new System.Drawing.Size(188, 41);
            this.btnWriteToBase.TabIndex = 6;
            this.btnWriteToBase.Text = "Записать в базу и распечатать?";
            this.btnWriteToBase.UseVisualStyleBackColor = false;
            this.btnWriteToBase.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewZamer
            // 
            this.dataGridViewZamer.AllowUserToAddRows = false;
            this.dataGridViewZamer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewZamer.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewZamer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewZamer.Location = new System.Drawing.Point(11, 280);
            this.dataGridViewZamer.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewZamer.Name = "dataGridViewZamer";
            this.dataGridViewZamer.RowHeadersVisible = false;
            this.dataGridViewZamer.RowTemplate.Height = 24;
            this.dataGridViewZamer.Size = new System.Drawing.Size(492, 231);
            this.dataGridViewZamer.TabIndex = 5;
            // 
            // labelZamer
            // 
            this.labelZamer.AutoSize = true;
            this.labelZamer.Location = new System.Drawing.Point(15, 228);
            this.labelZamer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelZamer.MaximumSize = new System.Drawing.Size(450, 0);
            this.labelZamer.Name = "labelZamer";
            this.labelZamer.Size = new System.Drawing.Size(353, 13);
            this.labelZamer.TabIndex = 4;
            this.labelZamer.Text = "Выбранные замеры (выберите в списке слева один или несколько)";
            // 
            // labelMissingBase
            // 
            this.labelMissingBase.AutoSize = true;
            this.labelMissingBase.Location = new System.Drawing.Point(255, 24);
            this.labelMissingBase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMissingBase.MaximumSize = new System.Drawing.Size(300, 0);
            this.labelMissingBase.Name = "labelMissingBase";
            this.labelMissingBase.Size = new System.Drawing.Size(0, 13);
            this.labelMissingBase.TabIndex = 17;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(763, 566);
            this.Controls.Add(this.labelMissingBase);
            this.Controls.Add(this.groupBoxZamer);
            this.Controls.Add(this.groupBoxFromFile);
            this.Controls.Add(this.groupBoxRegion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Запись данных прибора Ангел";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxRegion.ResumeLayout(false);
            this.groupBoxRegion.PerformLayout();
            this.groupBoxFromFile.ResumeLayout(false);
            this.groupBoxFromFile.PerformLayout();
            this.groupBoxZamer.ResumeLayout(false);
            this.groupBoxZamer.PerformLayout();
            this.groupBoxVirabotka.ResumeLayout(false);
            this.groupBoxVirabotka.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewZamer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox comboBoxHorizont;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxRegion;
        private System.Windows.Forms.Label NumberOfVirabot;
        private System.Windows.Forms.GroupBox groupBoxRegion;
        private System.Windows.Forms.Button buttonRegion;
        private System.Windows.Forms.GroupBox groupBoxFromFile;
        private System.Windows.Forms.Button buttonUploadData;
        private System.Windows.Forms.Label labelUploaded;
        private System.Windows.Forms.ListView listViewZameri;
        private System.Windows.Forms.GroupBox groupBoxZamer;
        private System.Windows.Forms.Button btnWriteToBase;
        private System.Windows.Forms.DataGridView dataGridViewZamer;
        private System.Windows.Forms.Label labelZamer;
        private System.Windows.Forms.Label labelMissingBase;
        private System.Windows.Forms.Button btnAccessStart;
        private System.Windows.Forms.GroupBox groupBoxVirabotka;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelReg;
        private System.Windows.Forms.Label labelHor;
        private System.Windows.Forms.TextBox textBoxPriviazka;
        private System.Windows.Forms.ComboBox comboBoxNapravlenie;
        private System.Windows.Forms.Label labelNapravlenie;
        private System.Windows.Forms.ComboBox comboBoxPriviazka;
        private System.Windows.Forms.ComboBox comboBoxVirabotka;
        private System.Windows.Forms.ComboBox comboBoxBlock;
        private System.Windows.Forms.ComboBox comboBoxPodetag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBoxPoroda;
        private System.Windows.Forms.Label labelPoroda;
        private System.Windows.Forms.Label labelDiametr;
    }
}

