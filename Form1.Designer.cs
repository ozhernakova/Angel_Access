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
            this.NumberOfVirabot = new System.Windows.Forms.Label();
            this.groupBoxRegion = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonRegion = new System.Windows.Forms.Button();
            this.groupBoxFromFile = new System.Windows.Forms.GroupBox();
            this.listViewZameri = new System.Windows.Forms.ListView();
            this.buttonUploadData = new System.Windows.Forms.Button();
            this.labelUploaded = new System.Windows.Forms.Label();
            this.groupBoxZamer = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewZamer = new System.Windows.Forms.DataGridView();
            this.labelZamer = new System.Windows.Forms.Label();
            this.labelMissingBase = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxPodetag = new System.Windows.Forms.ComboBox();
            this.comboBoxBlock = new System.Windows.Forms.ComboBox();
            this.comboBoxVirabotka = new System.Windows.Forms.ComboBox();
            this.comboBoxPriviazka = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxNapravlenie = new System.Windows.Forms.ComboBox();
            this.textBoxPriviazka = new System.Windows.Forms.TextBox();
            this.labelHor = new System.Windows.Forms.Label();
            this.labelReg = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBoxVirabotka = new System.Windows.Forms.GroupBox();
            this.groupBoxRegion.SuspendLayout();
            this.groupBoxFromFile.SuspendLayout();
            this.groupBoxZamer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewZamer)).BeginInit();
            this.groupBoxVirabotka.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
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
            this.comboBoxHorizont.Location = new System.Drawing.Point(78, 110);
            this.comboBoxHorizont.MaxDropDownItems = 12;
            this.comboBoxHorizont.Name = "comboBoxHorizont";
            this.comboBoxHorizont.Size = new System.Drawing.Size(179, 24);
            this.comboBoxHorizont.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
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
            this.comboBoxRegion.Location = new System.Drawing.Point(78, 59);
            this.comboBoxRegion.Name = "comboBoxRegion";
            this.comboBoxRegion.Size = new System.Drawing.Size(179, 24);
            this.comboBoxRegion.TabIndex = 3;
            // 
            // NumberOfVirabot
            // 
            this.NumberOfVirabot.AutoSize = true;
            this.NumberOfVirabot.Location = new System.Drawing.Point(6, 223);
            this.NumberOfVirabot.MaximumSize = new System.Drawing.Size(270, 0);
            this.NumberOfVirabot.Name = "NumberOfVirabot";
            this.NumberOfVirabot.Size = new System.Drawing.Size(141, 17);
            this.NumberOfVirabot.TabIndex = 11;
            this.NumberOfVirabot.Text = "Найдено выработок";
            // 
            // groupBoxRegion
            // 
            this.groupBoxRegion.Controls.Add(this.button2);
            this.groupBoxRegion.Controls.Add(this.buttonRegion);
            this.groupBoxRegion.Controls.Add(this.NumberOfVirabot);
            this.groupBoxRegion.Controls.Add(this.label2);
            this.groupBoxRegion.Controls.Add(this.comboBoxRegion);
            this.groupBoxRegion.Controls.Add(this.label1);
            this.groupBoxRegion.Controls.Add(this.comboBoxHorizont);
            this.groupBoxRegion.Location = new System.Drawing.Point(22, 6);
            this.groupBoxRegion.Name = "groupBoxRegion";
            this.groupBoxRegion.Size = new System.Drawing.Size(280, 321);
            this.groupBoxRegion.TabIndex = 12;
            this.groupBoxRegion.TabStop = false;
            this.groupBoxRegion.Text = "Выбор района";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 265);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(248, 42);
            this.button2.TabIndex = 12;
            this.button2.Text = "Запустить форму ПЭЗ_И для добавления выработок";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonRegion
            // 
            this.buttonRegion.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRegion.Location = new System.Drawing.Point(9, 158);
            this.buttonRegion.Name = "buttonRegion";
            this.buttonRegion.Size = new System.Drawing.Size(250, 50);
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
            this.groupBoxFromFile.Location = new System.Drawing.Point(22, 345);
            this.groupBoxFromFile.Name = "groupBoxFromFile";
            this.groupBoxFromFile.Size = new System.Drawing.Size(280, 464);
            this.groupBoxFromFile.TabIndex = 15;
            this.groupBoxFromFile.TabStop = false;
            this.groupBoxFromFile.Text = "Загрузить данные Ангела";
            // 
            // listViewZameri
            // 
            this.listViewZameri.FullRowSelect = true;
            this.listViewZameri.GridLines = true;
            this.listViewZameri.Location = new System.Drawing.Point(9, 153);
            this.listViewZameri.Name = "listViewZameri";
            this.listViewZameri.Size = new System.Drawing.Size(250, 286);
            this.listViewZameri.TabIndex = 17;
            this.listViewZameri.UseCompatibleStateImageBehavior = false;
            this.listViewZameri.View = System.Windows.Forms.View.Details;
            this.listViewZameri.Click += new System.EventHandler(this.listViewZameri_Click);
            this.listViewZameri.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewZameri_KeyUp);
            // 
            // buttonUploadData
            // 
            this.buttonUploadData.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonUploadData.Location = new System.Drawing.Point(9, 29);
            this.buttonUploadData.Name = "buttonUploadData";
            this.buttonUploadData.Size = new System.Drawing.Size(250, 50);
            this.buttonUploadData.TabIndex = 3;
            this.buttonUploadData.Text = "Загрузить данные";
            this.buttonUploadData.UseVisualStyleBackColor = false;
            this.buttonUploadData.Click += new System.EventHandler(this.buttonUploadData_Click);
            // 
            // labelUploaded
            // 
            this.labelUploaded.AutoSize = true;
            this.labelUploaded.Location = new System.Drawing.Point(14, 82);
            this.labelUploaded.MaximumSize = new System.Drawing.Size(250, 0);
            this.labelUploaded.Name = "labelUploaded";
            this.labelUploaded.Size = new System.Drawing.Size(0, 17);
            this.labelUploaded.TabIndex = 2;
            // 
            // groupBoxZamer
            // 
            this.groupBoxZamer.AutoSize = true;
            this.groupBoxZamer.Controls.Add(this.groupBoxVirabotka);
            this.groupBoxZamer.Controls.Add(this.button1);
            this.groupBoxZamer.Controls.Add(this.dataGridViewZamer);
            this.groupBoxZamer.Controls.Add(this.labelZamer);
            this.groupBoxZamer.Location = new System.Drawing.Point(325, 6);
            this.groupBoxZamer.Name = "groupBoxZamer";
            this.groupBoxZamer.Size = new System.Drawing.Size(637, 810);
            this.groupBoxZamer.TabIndex = 16;
            this.groupBoxZamer.TabStop = false;
            this.groupBoxZamer.Text = "Привязка измерений по месту";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(15, 739);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 50);
            this.button1.TabIndex = 6;
            this.button1.Text = "Записать в базу?";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewZamer
            // 
            this.dataGridViewZamer.AllowUserToAddRows = false;
            this.dataGridViewZamer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewZamer.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewZamer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewZamer.Location = new System.Drawing.Point(15, 413);
            this.dataGridViewZamer.Name = "dataGridViewZamer";
            this.dataGridViewZamer.RowHeadersVisible = false;
            this.dataGridViewZamer.RowTemplate.Height = 24;
            this.dataGridViewZamer.Size = new System.Drawing.Size(600, 320);
            this.dataGridViewZamer.TabIndex = 5;
            // 
            // labelZamer
            // 
            this.labelZamer.AutoSize = true;
            this.labelZamer.Location = new System.Drawing.Point(19, 331);
            this.labelZamer.MaximumSize = new System.Drawing.Size(600, 0);
            this.labelZamer.Name = "labelZamer";
            this.labelZamer.Size = new System.Drawing.Size(455, 17);
            this.labelZamer.TabIndex = 4;
            this.labelZamer.Text = "Выбранные замеры (выберите в списке слева один или несколько)";
            // 
            // labelMissingBase
            // 
            this.labelMissingBase.AutoSize = true;
            this.labelMissingBase.Location = new System.Drawing.Point(30, 30);
            this.labelMissingBase.MaximumSize = new System.Drawing.Size(700, 0);
            this.labelMissingBase.Name = "labelMissingBase";
            this.labelMissingBase.Size = new System.Drawing.Size(0, 17);
            this.labelMissingBase.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 184);
            this.label7.MaximumSize = new System.Drawing.Size(150, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 34);
            this.label7.TabIndex = 2;
            this.label7.Text = "Привязка замеров: (можно выбрать тут:)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Выработка";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Подэтаж";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Блок";
            // 
            // comboBoxPodetag
            // 
            this.comboBoxPodetag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPodetag.FormattingEnabled = true;
            this.comboBoxPodetag.Location = new System.Drawing.Point(250, 105);
            this.comboBoxPodetag.Name = "comboBoxPodetag";
            this.comboBoxPodetag.Size = new System.Drawing.Size(296, 24);
            this.comboBoxPodetag.TabIndex = 6;
            // 
            // comboBoxBlock
            // 
            this.comboBoxBlock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBlock.FormattingEnabled = true;
            this.comboBoxBlock.Location = new System.Drawing.Point(250, 75);
            this.comboBoxBlock.Name = "comboBoxBlock";
            this.comboBoxBlock.Size = new System.Drawing.Size(296, 24);
            this.comboBoxBlock.TabIndex = 4;
            // 
            // comboBoxVirabotka
            // 
            this.comboBoxVirabotka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVirabotka.FormattingEnabled = true;
            this.comboBoxVirabotka.Location = new System.Drawing.Point(250, 45);
            this.comboBoxVirabotka.Name = "comboBoxVirabotka";
            this.comboBoxVirabotka.Size = new System.Drawing.Size(296, 24);
            this.comboBoxVirabotka.TabIndex = 5;
            // 
            // comboBoxPriviazka
            // 
            this.comboBoxPriviazka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPriviazka.FormattingEnabled = true;
            this.comboBoxPriviazka.Location = new System.Drawing.Point(250, 206);
            this.comboBoxPriviazka.Name = "comboBoxPriviazka";
            this.comboBoxPriviazka.Size = new System.Drawing.Size(293, 24);
            this.comboBoxPriviazka.TabIndex = 11;
            this.comboBoxPriviazka.SelectedIndexChanged += new System.EventHandler(this.comboBoxPriviazka_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Направление";
            // 
            // comboBoxNapravlenie
            // 
            this.comboBoxNapravlenie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNapravlenie.FormattingEnabled = true;
            this.comboBoxNapravlenie.Location = new System.Drawing.Point(250, 246);
            this.comboBoxNapravlenie.Name = "comboBoxNapravlenie";
            this.comboBoxNapravlenie.Size = new System.Drawing.Size(162, 24);
            this.comboBoxNapravlenie.TabIndex = 13;
            // 
            // textBoxPriviazka
            // 
            this.textBoxPriviazka.Location = new System.Drawing.Point(250, 182);
            this.textBoxPriviazka.Name = "textBoxPriviazka";
            this.textBoxPriviazka.Size = new System.Drawing.Size(293, 22);
            this.textBoxPriviazka.TabIndex = 14;
            // 
            // labelHor
            // 
            this.labelHor.AutoSize = true;
            this.labelHor.Location = new System.Drawing.Point(250, 18);
            this.labelHor.Name = "labelHor";
            this.labelHor.Size = new System.Drawing.Size(0, 17);
            this.labelHor.TabIndex = 17;
            // 
            // labelReg
            // 
            this.labelReg.AutoSize = true;
            this.labelReg.Location = new System.Drawing.Point(370, 18);
            this.labelReg.Name = "labelReg";
            this.labelReg.Size = new System.Drawing.Size(0, 17);
            this.labelReg.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(224, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "Выбранные горизонт и участок: ";
            // 
            // groupBoxVirabotka
            // 
            this.groupBoxVirabotka.Controls.Add(this.label9);
            this.groupBoxVirabotka.Controls.Add(this.labelReg);
            this.groupBoxVirabotka.Controls.Add(this.labelHor);
            this.groupBoxVirabotka.Controls.Add(this.textBoxPriviazka);
            this.groupBoxVirabotka.Controls.Add(this.comboBoxNapravlenie);
            this.groupBoxVirabotka.Controls.Add(this.label6);
            this.groupBoxVirabotka.Controls.Add(this.comboBoxPriviazka);
            this.groupBoxVirabotka.Controls.Add(this.comboBoxVirabotka);
            this.groupBoxVirabotka.Controls.Add(this.comboBoxBlock);
            this.groupBoxVirabotka.Controls.Add(this.comboBoxPodetag);
            this.groupBoxVirabotka.Controls.Add(this.label3);
            this.groupBoxVirabotka.Controls.Add(this.label4);
            this.groupBoxVirabotka.Controls.Add(this.label5);
            this.groupBoxVirabotka.Controls.Add(this.label7);
            this.groupBoxVirabotka.Location = new System.Drawing.Point(7, 22);
            this.groupBoxVirabotka.Name = "groupBoxVirabotka";
            this.groupBoxVirabotka.Size = new System.Drawing.Size(623, 291);
            this.groupBoxVirabotka.TabIndex = 11;
            this.groupBoxVirabotka.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(974, 811);
            this.Controls.Add(this.labelMissingBase);
            this.Controls.Add(this.groupBoxZamer);
            this.Controls.Add(this.groupBoxFromFile);
            this.Controls.Add(this.groupBoxRegion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Запись данных прибора Ангел";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxRegion.ResumeLayout(false);
            this.groupBoxRegion.PerformLayout();
            this.groupBoxFromFile.ResumeLayout(false);
            this.groupBoxFromFile.PerformLayout();
            this.groupBoxZamer.ResumeLayout(false);
            this.groupBoxZamer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewZamer)).EndInit();
            this.groupBoxVirabotka.ResumeLayout(false);
            this.groupBoxVirabotka.PerformLayout();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewZamer;
        private System.Windows.Forms.Label labelZamer;
        private System.Windows.Forms.Label labelMissingBase;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBoxVirabotka;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelReg;
        private System.Windows.Forms.Label labelHor;
        private System.Windows.Forms.TextBox textBoxPriviazka;
        private System.Windows.Forms.ComboBox comboBoxNapravlenie;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxPriviazka;
        private System.Windows.Forms.ComboBox comboBoxVirabotka;
        private System.Windows.Forms.ComboBox comboBoxBlock;
        private System.Windows.Forms.ComboBox comboBoxPodetag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
    }
}

