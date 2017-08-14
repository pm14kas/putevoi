namespace putevoi
{
    partial class MainForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPutevoi = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboSelectCar = new System.Windows.Forms.ComboBox();
            this.comboSelectEngine = new System.Windows.Forms.ComboBox();
            this.comboSelectDriver = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabGSM = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabPutevoi.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPutevoi);
            this.tabControl.Controls.Add(this.tabGSM);
            this.tabControl.Location = new System.Drawing.Point(-1, -1);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(725, 409);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPutevoi
            // 
            this.tabPutevoi.Controls.Add(this.panel1);
            this.tabPutevoi.Location = new System.Drawing.Point(4, 22);
            this.tabPutevoi.Name = "tabPutevoi";
            this.tabPutevoi.Padding = new System.Windows.Forms.Padding(3);
            this.tabPutevoi.Size = new System.Drawing.Size(717, 383);
            this.tabPutevoi.TabIndex = 0;
            this.tabPutevoi.Text = "Путевые листы";
            this.tabPutevoi.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboSelectCar);
            this.panel1.Controls.Add(this.comboSelectEngine);
            this.panel1.Controls.Add(this.comboSelectDriver);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(9, 237);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(699, 140);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(575, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Создать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(359, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Прицеп";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Автомобиль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Водитель";
            // 
            // comboSelectCar
            // 
            this.comboSelectCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSelectCar.FormattingEnabled = true;
            this.comboSelectCar.Location = new System.Drawing.Point(359, 44);
            this.comboSelectCar.Name = "comboSelectCar";
            this.comboSelectCar.Size = new System.Drawing.Size(121, 21);
            this.comboSelectCar.TabIndex = 3;
            // 
            // comboSelectEngine
            // 
            this.comboSelectEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSelectEngine.FormattingEnabled = true;
            this.comboSelectEngine.Location = new System.Drawing.Point(185, 43);
            this.comboSelectEngine.Name = "comboSelectEngine";
            this.comboSelectEngine.Size = new System.Drawing.Size(121, 21);
            this.comboSelectEngine.TabIndex = 2;
            // 
            // comboSelectDriver
            // 
            this.comboSelectDriver.DisplayMember = "value";
            this.comboSelectDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSelectDriver.FormattingEnabled = true;
            this.comboSelectDriver.Location = new System.Drawing.Point(6, 44);
            this.comboSelectDriver.Name = "comboSelectDriver";
            this.comboSelectDriver.Size = new System.Drawing.Size(121, 21);
            this.comboSelectDriver.TabIndex = 1;
            this.comboSelectDriver.ValueMember = "id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Создать путевой лист";
            // 
            // tabGSM
            // 
            this.tabGSM.Location = new System.Drawing.Point(4, 22);
            this.tabGSM.Name = "tabGSM";
            this.tabGSM.Padding = new System.Windows.Forms.Padding(3);
            this.tabGSM.Size = new System.Drawing.Size(717, 383);
            this.tabGSM.TabIndex = 1;
            this.tabGSM.Text = "Расчет ГСМ";
            this.tabGSM.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 408);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "Расчет путевых листов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPutevoi.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPutevoi;
        private System.Windows.Forms.TabPage tabGSM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboSelectDriver;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboSelectCar;
        private System.Windows.Forms.ComboBox comboSelectEngine;


    }
}

