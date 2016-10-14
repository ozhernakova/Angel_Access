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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.comboBoxHorizont = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxRegion = new System.Windows.Forms.ComboBox();
            this.comboBoxBlock = new System.Windows.Forms.ComboBox();
            this.comboBoxVirabotka = new System.Windows.Forms.ComboBox();
            this.comboBoxPodetag = new System.Windows.Forms.ComboBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxRegion = new System.Windows.Forms.GroupBox();
            this.buttonRegion = new System.Windows.Forms.Button();
            this.groupBoxVirabotka = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBoxRegion.SuspendLayout();
            this.groupBoxVirabotka.SuspendLayout();
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
            this.comboBoxBlock.Location = new System.Drawing.Point(125, 132);
            this.comboBoxBlock.Name = "comboBoxBlock";
            this.comboBoxBlock.Size = new System.Drawing.Size(263, 24);
            this.comboBoxBlock.TabIndex = 4;
            // 
            // comboBoxVirabotka
            // 
            this.comboBoxVirabotka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVirabotka.FormattingEnabled = true;
            this.comboBoxVirabotka.Location = new System.Drawing.Point(125, 66);
            this.comboBoxVirabotka.Name = "comboBoxVirabotka";
            this.comboBoxVirabotka.Size = new System.Drawing.Size(263, 24);
            this.comboBoxVirabotka.TabIndex = 5;
            // 
            // comboBoxPodetag
            // 
            this.comboBoxPodetag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPodetag.FormattingEnabled = true;
            this.comboBoxPodetag.Location = new System.Drawing.Point(125, 194);
            this.comboBoxPodetag.Name = "comboBoxPodetag";
            this.comboBoxPodetag.Size = new System.Drawing.Size(263, 24);
            this.comboBoxPodetag.TabIndex = 6;
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(865, 283);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(121, 24);
            this.comboBox6.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Блок";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Подэтаж";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Выработка";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(777, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "label6";
            // 
            // groupBoxRegion
            // 
            this.groupBoxRegion.Controls.Add(this.buttonRegion);
            this.groupBoxRegion.Controls.Add(this.label2);
            this.groupBoxRegion.Controls.Add(this.comboBoxRegion);
            this.groupBoxRegion.Controls.Add(this.label1);
            this.groupBoxRegion.Controls.Add(this.comboBoxHorizont);
            this.groupBoxRegion.Location = new System.Drawing.Point(12, 29);
            this.groupBoxRegion.Name = "groupBoxRegion";
            this.groupBoxRegion.Size = new System.Drawing.Size(245, 278);
            this.groupBoxRegion.TabIndex = 12;
            this.groupBoxRegion.TabStop = false;
            this.groupBoxRegion.Text = "Выбор района";
            // 
            // buttonRegion
            // 
            this.buttonRegion.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRegion.Location = new System.Drawing.Point(9, 201);
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
            this.groupBoxVirabotka.Controls.Add(this.comboBoxPodetag);
            this.groupBoxVirabotka.Controls.Add(this.comboBoxBlock);
            this.groupBoxVirabotka.Controls.Add(this.comboBoxVirabotka);
            this.groupBoxVirabotka.Location = new System.Drawing.Point(300, 29);
            this.groupBoxVirabotka.Name = "groupBoxVirabotka";
            this.groupBoxVirabotka.Size = new System.Drawing.Size(407, 278);
            this.groupBoxVirabotka.TabIndex = 13;
            this.groupBoxVirabotka.TabStop = false;
            this.groupBoxVirabotka.Text = "Место измерения";
            this.groupBoxVirabotka.Visible = false;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(745, 42);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(121, 157);
            this.treeView1.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1022, 419);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.groupBoxVirabotka);
            this.Controls.Add(this.groupBoxRegion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxRegion.ResumeLayout(false);
            this.groupBoxRegion.PerformLayout();
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
        private System.Windows.Forms.ComboBox comboBoxBlock;
        private System.Windows.Forms.ComboBox comboBoxVirabotka;
        private System.Windows.Forms.ComboBox comboBoxPodetag;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxRegion;
        private System.Windows.Forms.Button buttonRegion;
        private System.Windows.Forms.GroupBox groupBoxVirabotka;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TreeView treeView1;
    }
}

