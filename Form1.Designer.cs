﻿namespace Angel_Access
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
            this.comboBoxBlock = new System.Windows.Forms.ComboBox();
            this.comboBoxVirabotka = new System.Windows.Forms.ComboBox();
            this.comboBoxPodetag = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NumberOfVirabot = new System.Windows.Forms.Label();
            this.groupBoxRegion = new System.Windows.Forms.GroupBox();
            this.buttonRegion = new System.Windows.Forms.Button();
            this.groupBoxVirabotka = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBoxFromFile = new System.Windows.Forms.GroupBox();
            this.listViewZameri = new System.Windows.Forms.ListView();
            this.buttonUploadData = new System.Windows.Forms.Button();
            this.labelUploaded = new System.Windows.Forms.Label();
            this.dataGridViewAllAngel = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBoxZamer = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelDataGridInfo = new System.Windows.Forms.Label();
            this.groupBoxRegion.SuspendLayout();
            this.groupBoxVirabotka.SuspendLayout();
            this.groupBoxFromFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllAngel)).BeginInit();
            this.groupBoxZamer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Горизонт";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // comboBoxHorizont
            // 
            this.comboBoxHorizont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHorizont.FormattingEnabled = true;
            this.comboBoxHorizont.Location = new System.Drawing.Point(78, 128);
            this.comboBoxHorizont.MaxDropDownItems = 12;
            this.comboBoxHorizont.Name = "comboBoxHorizont";
            this.comboBoxHorizont.Size = new System.Drawing.Size(147, 24);
            this.comboBoxHorizont.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Участок";
            // 
            // comboBoxRegion
            // 
            this.comboBoxRegion.CausesValidation = false;
            this.comboBoxRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRegion.FormattingEnabled = true;
            this.comboBoxRegion.Location = new System.Drawing.Point(78, 62);
            this.comboBoxRegion.Name = "comboBoxRegion";
            this.comboBoxRegion.Size = new System.Drawing.Size(147, 24);
            this.comboBoxRegion.TabIndex = 3;
            // 
            // comboBoxBlock
            // 
            this.comboBoxBlock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBlock.FormattingEnabled = true;
            this.comboBoxBlock.Location = new System.Drawing.Point(125, 120);
            this.comboBoxBlock.Name = "comboBoxBlock";
            this.comboBoxBlock.Size = new System.Drawing.Size(296, 24);
            this.comboBoxBlock.TabIndex = 4;
            // 
            // comboBoxVirabotka
            // 
            this.comboBoxVirabotka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVirabotka.FormattingEnabled = true;
            this.comboBoxVirabotka.Location = new System.Drawing.Point(125, 62);
            this.comboBoxVirabotka.Name = "comboBoxVirabotka";
            this.comboBoxVirabotka.Size = new System.Drawing.Size(296, 24);
            this.comboBoxVirabotka.TabIndex = 5;
            // 
            // comboBoxPodetag
            // 
            this.comboBoxPodetag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPodetag.FormattingEnabled = true;
            this.comboBoxPodetag.Location = new System.Drawing.Point(125, 181);
            this.comboBoxPodetag.Name = "comboBoxPodetag";
            this.comboBoxPodetag.Size = new System.Drawing.Size(296, 24);
            this.comboBoxPodetag.TabIndex = 6;
            this.comboBoxPodetag.SelectedIndexChanged += new System.EventHandler(this.comboBoxPodetag_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Блок";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Подэтаж";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Выработка";
            // 
            // NumberOfVirabot
            // 
            this.NumberOfVirabot.AutoSize = true;
            this.NumberOfVirabot.Location = new System.Drawing.Point(6, 241);
            this.NumberOfVirabot.MaximumSize = new System.Drawing.Size(400, 0);
            this.NumberOfVirabot.Name = "NumberOfVirabot";
            this.NumberOfVirabot.Size = new System.Drawing.Size(141, 17);
            this.NumberOfVirabot.TabIndex = 11;
            this.NumberOfVirabot.Text = "Найдено выработок";
            // 
            // groupBoxRegion
            // 
            this.groupBoxRegion.Controls.Add(this.buttonRegion);
            this.groupBoxRegion.Controls.Add(this.label2);
            this.groupBoxRegion.Controls.Add(this.comboBoxRegion);
            this.groupBoxRegion.Controls.Add(this.label1);
            this.groupBoxRegion.Controls.Add(this.comboBoxHorizont);
            this.groupBoxRegion.Location = new System.Drawing.Point(88, 29);
            this.groupBoxRegion.Name = "groupBoxRegion";
            this.groupBoxRegion.Size = new System.Drawing.Size(245, 291);
            this.groupBoxRegion.TabIndex = 12;
            this.groupBoxRegion.TabStop = false;
            this.groupBoxRegion.Text = "Выбор района";
            // 
            // buttonRegion
            // 
            this.buttonRegion.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRegion.Location = new System.Drawing.Point(9, 213);
            this.buttonRegion.Name = "buttonRegion";
            this.buttonRegion.Size = new System.Drawing.Size(216, 44);
            this.buttonRegion.TabIndex = 4;
            this.buttonRegion.Text = "Показать выработки для этого района";
            this.buttonRegion.UseVisualStyleBackColor = false;
            this.buttonRegion.Click += new System.EventHandler(this.buttonRegion_Click);
            // 
            // groupBoxVirabotka
            // 
            this.groupBoxVirabotka.Controls.Add(this.label3);
            this.groupBoxVirabotka.Controls.Add(this.label4);
            this.groupBoxVirabotka.Controls.Add(this.label5);
            this.groupBoxVirabotka.Controls.Add(this.NumberOfVirabot);
            this.groupBoxVirabotka.Controls.Add(this.comboBoxPodetag);
            this.groupBoxVirabotka.Controls.Add(this.comboBoxBlock);
            this.groupBoxVirabotka.Controls.Add(this.comboBoxVirabotka);
            this.groupBoxVirabotka.Location = new System.Drawing.Point(376, 29);
            this.groupBoxVirabotka.Name = "groupBoxVirabotka";
            this.groupBoxVirabotka.Size = new System.Drawing.Size(444, 291);
            this.groupBoxVirabotka.TabIndex = 13;
            this.groupBoxVirabotka.TabStop = false;
            this.groupBoxVirabotka.Text = "Место измерения";
            this.groupBoxVirabotka.Visible = false;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(899, 38);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(67, 282);
            this.treeView1.TabIndex = 14;
            // 
            // groupBoxFromFile
            // 
            this.groupBoxFromFile.Controls.Add(this.labelDataGridInfo);
            this.groupBoxFromFile.Controls.Add(this.listViewZameri);
            this.groupBoxFromFile.Controls.Add(this.buttonUploadData);
            this.groupBoxFromFile.Controls.Add(this.labelUploaded);
            this.groupBoxFromFile.Controls.Add(this.dataGridViewAllAngel);
            this.groupBoxFromFile.Location = new System.Drawing.Point(86, 369);
            this.groupBoxFromFile.Name = "groupBoxFromFile";
            this.groupBoxFromFile.Size = new System.Drawing.Size(425, 645);
            this.groupBoxFromFile.TabIndex = 15;
            this.groupBoxFromFile.TabStop = false;
            this.groupBoxFromFile.Text = "Загрузить данные Ангела";
            // 
            // listViewZameri
            // 
            this.listViewZameri.FullRowSelect = true;
            this.listViewZameri.GridLines = true;
            this.listViewZameri.Location = new System.Drawing.Point(9, 144);
            this.listViewZameri.Name = "listViewZameri";
            this.listViewZameri.Size = new System.Drawing.Size(401, 206);
            this.listViewZameri.TabIndex = 17;
            this.listViewZameri.UseCompatibleStateImageBehavior = false;
            this.listViewZameri.View = System.Windows.Forms.View.Details;
            this.listViewZameri.SelectedIndexChanged += new System.EventHandler(this.listViewZameri_SelectedIndexChanged);
            // 
            // buttonUploadData
            // 
            this.buttonUploadData.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonUploadData.Location = new System.Drawing.Point(9, 42);
            this.buttonUploadData.Name = "buttonUploadData";
            this.buttonUploadData.Size = new System.Drawing.Size(216, 35);
            this.buttonUploadData.TabIndex = 3;
            this.buttonUploadData.Text = "Загрузить данные";
            this.buttonUploadData.UseVisualStyleBackColor = false;
            this.buttonUploadData.Click += new System.EventHandler(this.buttonUploadData_Click);
            // 
            // labelUploaded
            // 
            this.labelUploaded.AutoSize = true;
            this.labelUploaded.Location = new System.Drawing.Point(14, 82);
            this.labelUploaded.MaximumSize = new System.Drawing.Size(400, 0);
            this.labelUploaded.Name = "labelUploaded";
            this.labelUploaded.Size = new System.Drawing.Size(0, 17);
            this.labelUploaded.TabIndex = 2;
            // 
            // dataGridViewAllAngel
            // 
            this.dataGridViewAllAngel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewAllAngel.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewAllAngel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllAngel.Location = new System.Drawing.Point(11, 397);
            this.dataGridViewAllAngel.Name = "dataGridViewAllAngel";
            this.dataGridViewAllAngel.RowHeadersVisible = false;
            this.dataGridViewAllAngel.RowTemplate.Height = 24;
            this.dataGridViewAllAngel.Size = new System.Drawing.Size(401, 118);
            this.dataGridViewAllAngel.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Дата измерения";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(9, 55);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // groupBoxZamer
            // 
            this.groupBoxZamer.AutoSize = true;
            this.groupBoxZamer.Controls.Add(this.button1);
            this.groupBoxZamer.Controls.Add(this.dataGridView1);
            this.groupBoxZamer.Controls.Add(this.label8);
            this.groupBoxZamer.Controls.Add(this.textBox1);
            this.groupBoxZamer.Controls.Add(this.label7);
            this.groupBoxZamer.Controls.Add(this.dateTimePicker1);
            this.groupBoxZamer.Controls.Add(this.label6);
            this.groupBoxZamer.Location = new System.Drawing.Point(547, 369);
            this.groupBoxZamer.Name = "groupBoxZamer";
            this.groupBoxZamer.Size = new System.Drawing.Size(549, 566);
            this.groupBoxZamer.TabIndex = 16;
            this.groupBoxZamer.TabStop = false;
            this.groupBoxZamer.Text = "Привязка измерений по дате и месту";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(9, 500);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(270, 45);
            this.button1.TabIndex = 6;
            this.button1.Text = "Записать в базу?";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 249);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(386, 215);
            this.dataGridView1.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 204);
            this.label8.MaximumSize = new System.Drawing.Size(400, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Выбранные замеры";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 121);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(377, 54);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Введите подробное описание места измерения";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Привязка";
            // 
            // labelDataGridInfo
            // 
            this.labelDataGridInfo.AutoSize = true;
            this.labelDataGridInfo.Location = new System.Drawing.Point(13, 371);
            this.labelDataGridInfo.Name = "labelDataGridInfo";
            this.labelDataGridInfo.Size = new System.Drawing.Size(0, 17);
            this.labelDataGridInfo.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1176, 946);
            this.Controls.Add(this.groupBoxZamer);
            this.Controls.Add(this.groupBoxFromFile);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.groupBoxVirabotka);
            this.Controls.Add(this.groupBoxRegion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Запись данных прибора Ангел";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxRegion.ResumeLayout(false);
            this.groupBoxRegion.PerformLayout();
            this.groupBoxVirabotka.ResumeLayout(false);
            this.groupBoxVirabotka.PerformLayout();
            this.groupBoxFromFile.ResumeLayout(false);
            this.groupBoxFromFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllAngel)).EndInit();
            this.groupBoxZamer.ResumeLayout(false);
            this.groupBoxZamer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox comboBoxHorizont;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxRegion;
        private System.Windows.Forms.ComboBox comboBoxBlock;
        private System.Windows.Forms.ComboBox comboBoxVirabotka;
        private System.Windows.Forms.ComboBox comboBoxPodetag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label NumberOfVirabot;
        private System.Windows.Forms.GroupBox groupBoxRegion;
        private System.Windows.Forms.Button buttonRegion;
        private System.Windows.Forms.GroupBox groupBoxVirabotka;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBoxFromFile;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonUploadData;
        private System.Windows.Forms.Label labelUploaded;
        private System.Windows.Forms.DataGridView dataGridViewAllAngel;
        private System.Windows.Forms.ListView listViewZameri;
        private System.Windows.Forms.GroupBox groupBoxZamer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelDataGridInfo;
    }
}

