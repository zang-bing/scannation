﻿namespace Scanation
{
    partial class Scanation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scanation));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dpiTb1 = new System.Windows.Forms.TextBox();
            this.removeFrameBtn = new System.Windows.Forms.Button();
            this.addFrameBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.printDevicesCb1 = new System.Windows.Forms.ComboBox();
            this.button11 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.printDevicesCb2 = new System.Windows.Forms.ComboBox();
            this.dpiTb2 = new System.Windows.Forms.TextBox();
            this.btnRemoveDrop2 = new System.Windows.Forms.Button();
            this.btnAddDrop2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.decisionBtn = new System.Windows.Forms.Button();
            this.previewBtn = new System.Windows.Forms.Button();
            this.scanBtn = new System.Windows.Forms.Button();
            this.preScanBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(74, 89);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(798, 621);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dpiTb1);
            this.tabPage1.Controls.Add(this.removeFrameBtn);
            this.tabPage1.Controls.Add(this.addFrameBtn);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.printDevicesCb1);
            this.tabPage1.Controls.Add(this.button11);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.textBoxName);
            this.tabPage1.Controls.Add(this.textBoxId);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft PhagsPa", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(790, 591);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "遺影";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dpiTb1
            // 
            this.dpiTb1.Enabled = false;
            this.dpiTb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpiTb1.Location = new System.Drawing.Point(295, 368);
            this.dpiTb1.Margin = new System.Windows.Forms.Padding(2);
            this.dpiTb1.Name = "dpiTb1";
            this.dpiTb1.Size = new System.Drawing.Size(297, 31);
            this.dpiTb1.TabIndex = 36;
            this.dpiTb1.TextChanged += new System.EventHandler(this.DpiTb_TextChanged);
            this.dpiTb1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DpiTb_KeyPress);
            // 
            // removeFrameBtn
            // 
            this.removeFrameBtn.Enabled = false;
            this.removeFrameBtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.removeFrameBtn.FlatAppearance.BorderSize = 2;
            this.removeFrameBtn.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeFrameBtn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.removeFrameBtn.Location = new System.Drawing.Point(618, 480);
            this.removeFrameBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.removeFrameBtn.Name = "removeFrameBtn";
            this.removeFrameBtn.Size = new System.Drawing.Size(129, 37);
            this.removeFrameBtn.TabIndex = 7;
            this.removeFrameBtn.Text = "選択枠を削除";
            this.removeFrameBtn.UseVisualStyleBackColor = true;
            this.removeFrameBtn.Click += new System.EventHandler(this.RemoveFrameBtn_Click);
            // 
            // addFrameBtn
            // 
            this.addFrameBtn.Enabled = false;
            this.addFrameBtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.addFrameBtn.FlatAppearance.BorderSize = 2;
            this.addFrameBtn.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addFrameBtn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.addFrameBtn.Location = new System.Drawing.Point(425, 480);
            this.addFrameBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addFrameBtn.Name = "addFrameBtn";
            this.addFrameBtn.Size = new System.Drawing.Size(129, 37);
            this.addFrameBtn.TabIndex = 6;
            this.addFrameBtn.Text = "選択枠を追加";
            this.addFrameBtn.UseVisualStyleBackColor = true;
            this.addFrameBtn.Click += new System.EventHandler(this.AddFrameBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(20, 371);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 35;
            this.label1.Text = "解像度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(614, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "dpi";
            // 
            // printDevicesCb1
            // 
            this.printDevicesCb1.Enabled = false;
            this.printDevicesCb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printDevicesCb1.FormattingEnabled = true;
            this.printDevicesCb1.Location = new System.Drawing.Point(295, 295);
            this.printDevicesCb1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.printDevicesCb1.Name = "printDevicesCb1";
            this.printDevicesCb1.Size = new System.Drawing.Size(297, 33);
            this.printDevicesCb1.TabIndex = 3;
            // 
            // button11
            // 
            this.button11.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.button11.FlatAppearance.BorderSize = 2;
            this.button11.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button11.Location = new System.Drawing.Point(618, 295);
            this.button11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(129, 32);
            this.button11.TabIndex = 4;
            this.button11.Text = "選択";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(20, 298);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 25);
            this.label8.TabIndex = 30;
            this.label8.Text = "ディバイス";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(617, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 25);
            this.label9.TabIndex = 29;
            this.label9.Text = "家";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(25, 137);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxName.Multiline = true;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(567, 101);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxId
            // 
            this.textBoxId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxId.Location = new System.Drawing.Point(119, 57);
            this.textBoxId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(628, 31);
            this.textBoxId.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(20, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 25);
            this.label10.TabIndex = 26;
            this.label10.Text = "コード";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.printDevicesCb2);
            this.tabPage2.Controls.Add(this.dpiTb2);
            this.tabPage2.Controls.Add(this.btnRemoveDrop2);
            this.tabPage2.Controls.Add(this.btnAddDrop2);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI Historic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(790, 591);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "メモリアル";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(20, 371);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 25);
            this.label11.TabIndex = 54;
            this.label11.Text = "解像度";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Historic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(614, 375);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 20);
            this.label12.TabIndex = 53;
            this.label12.Text = "dpi";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(20, 298);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 25);
            this.label13.TabIndex = 52;
            this.label13.Text = "ディバイス";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(617, 176);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 25);
            this.label14.TabIndex = 51;
            this.label14.Text = "家";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(20, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 25);
            this.label15.TabIndex = 50;
            this.label15.Text = "コード";
            // 
            // printDevicesCb2
            // 
            this.printDevicesCb2.Enabled = false;
            this.printDevicesCb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printDevicesCb2.FormattingEnabled = true;
            this.printDevicesCb2.Location = new System.Drawing.Point(295, 295);
            this.printDevicesCb2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.printDevicesCb2.Name = "printDevicesCb2";
            this.printDevicesCb2.Size = new System.Drawing.Size(297, 33);
            this.printDevicesCb2.TabIndex = 49;
            // 
            // dpiTb2
            // 
            this.dpiTb2.Enabled = false;
            this.dpiTb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpiTb2.Location = new System.Drawing.Point(295, 368);
            this.dpiTb2.Margin = new System.Windows.Forms.Padding(2);
            this.dpiTb2.Name = "dpiTb2";
            this.dpiTb2.Size = new System.Drawing.Size(297, 31);
            this.dpiTb2.TabIndex = 48;
            // 
            // btnRemoveDrop2
            // 
            this.btnRemoveDrop2.Enabled = false;
            this.btnRemoveDrop2.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnRemoveDrop2.FlatAppearance.BorderSize = 2;
            this.btnRemoveDrop2.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveDrop2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnRemoveDrop2.Location = new System.Drawing.Point(618, 480);
            this.btnRemoveDrop2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveDrop2.Name = "btnRemoveDrop2";
            this.btnRemoveDrop2.Size = new System.Drawing.Size(129, 37);
            this.btnRemoveDrop2.TabIndex = 7;
            this.btnRemoveDrop2.Text = "選択枠を削除";
            this.btnRemoveDrop2.UseVisualStyleBackColor = true;
            this.btnRemoveDrop2.Click += new System.EventHandler(this.BtnRemoveDrop2_Click);
            // 
            // btnAddDrop2
            // 
            this.btnAddDrop2.Enabled = false;
            this.btnAddDrop2.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnAddDrop2.FlatAppearance.BorderSize = 2;
            this.btnAddDrop2.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDrop2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnAddDrop2.Location = new System.Drawing.Point(425, 480);
            this.btnAddDrop2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddDrop2.Name = "btnAddDrop2";
            this.btnAddDrop2.Size = new System.Drawing.Size(129, 37);
            this.btnAddDrop2.TabIndex = 6;
            this.btnAddDrop2.Text = "選択枠を追加";
            this.btnAddDrop2.UseVisualStyleBackColor = true;
            this.btnAddDrop2.Click += new System.EventHandler(this.BtnAddDrop2_Click);
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.button4.FlatAppearance.BorderSize = 2;
            this.button4.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button4.Location = new System.Drawing.Point(618, 295);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(129, 32);
            this.button4.TabIndex = 4;
            this.button4.Text = "選択";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(25, 137);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(567, 101);
            this.textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(119, 57);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(628, 35);
            this.textBox4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.decisionBtn);
            this.panel5.Controls.Add(this.previewBtn);
            this.panel5.Controls.Add(this.scanBtn);
            this.panel5.Controls.Add(this.preScanBtn);
            this.panel5.Controls.Add(this.closeBtn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 834);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1727, 81);
            this.panel5.TabIndex = 1;
            // 
            // decisionBtn
            // 
            this.decisionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.decisionBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.decisionBtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.decisionBtn.FlatAppearance.BorderSize = 2;
            this.decisionBtn.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decisionBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.decisionBtn.Location = new System.Drawing.Point(1474, 22);
            this.decisionBtn.Margin = new System.Windows.Forms.Padding(2);
            this.decisionBtn.Name = "decisionBtn";
            this.decisionBtn.Size = new System.Drawing.Size(151, 38);
            this.decisionBtn.TabIndex = 29;
            this.decisionBtn.Text = "決定";
            this.decisionBtn.UseVisualStyleBackColor = false;
            this.decisionBtn.Click += new System.EventHandler(this.DecisionBtn_Click);
            // 
            // previewBtn
            // 
            this.previewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.previewBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.previewBtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.previewBtn.FlatAppearance.BorderSize = 2;
            this.previewBtn.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.previewBtn.Location = new System.Drawing.Point(1181, 22);
            this.previewBtn.Margin = new System.Windows.Forms.Padding(2);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(151, 38);
            this.previewBtn.TabIndex = 28;
            this.previewBtn.Text = "プレビュー";
            this.previewBtn.UseVisualStyleBackColor = false;
            this.previewBtn.Click += new System.EventHandler(this.PreviewBtn_Click);
            // 
            // scanBtn
            // 
            this.scanBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.scanBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.scanBtn.Enabled = false;
            this.scanBtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.scanBtn.FlatAppearance.BorderSize = 2;
            this.scanBtn.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.scanBtn.Location = new System.Drawing.Point(820, 22);
            this.scanBtn.Margin = new System.Windows.Forms.Padding(2);
            this.scanBtn.Name = "scanBtn";
            this.scanBtn.Size = new System.Drawing.Size(151, 38);
            this.scanBtn.TabIndex = 27;
            this.scanBtn.Text = "スキャン";
            this.scanBtn.UseVisualStyleBackColor = false;
            this.scanBtn.Click += new System.EventHandler(this.OnScanBtn_Click);
            // 
            // preScanBtn
            // 
            this.preScanBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.preScanBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.preScanBtn.Enabled = false;
            this.preScanBtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.preScanBtn.FlatAppearance.BorderSize = 2;
            this.preScanBtn.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preScanBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.preScanBtn.Location = new System.Drawing.Point(452, 22);
            this.preScanBtn.Margin = new System.Windows.Forms.Padding(2);
            this.preScanBtn.Name = "preScanBtn";
            this.preScanBtn.Size = new System.Drawing.Size(151, 38);
            this.preScanBtn.TabIndex = 26;
            this.preScanBtn.Text = "プレスキャン";
            this.preScanBtn.UseVisualStyleBackColor = false;
            this.preScanBtn.Click += new System.EventHandler(this.PreScanBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.closeBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.closeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.closeBtn.FlatAppearance.BorderSize = 2;
            this.closeBtn.Font = new System.Drawing.Font("Segoe UI Historic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.closeBtn.Location = new System.Drawing.Point(103, 22);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(151, 38);
            this.closeBtn.TabIndex = 25;
            this.closeBtn.Text = "閉じる";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Location = new System.Drawing.Point(897, 115);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 712);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(821, 712);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(12, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 29);
            this.label3.TabIndex = 37;
            this.label3.Text = "Scannation";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(1526, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 63);
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // Scanation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1727, 915);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Scanation";
            this.Text = "Scanation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button decisionBtn;
        private System.Windows.Forms.Button previewBtn;
        private System.Windows.Forms.Button scanBtn;
        private System.Windows.Forms.Button preScanBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button removeFrameBtn;
        private System.Windows.Forms.Button addFrameBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox printDevicesCb1;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnRemoveDrop2;
        private System.Windows.Forms.Button btnAddDrop2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox dpiTb1;
        private System.Windows.Forms.TextBox dpiTb2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox printDevicesCb2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

