namespace Scanation
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dpiCb1 = new System.Windows.Forms.ComboBox();
            this.removeFrameBtn = new System.Windows.Forms.Button();
            this.addFrameBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.printDevicesCb1 = new System.Windows.Forms.ComboBox();
            this.button11 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dpiCb2 = new System.Windows.Forms.ComboBox();
            this.printDevicesCb2 = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.decisionBtn = new System.Windows.Forms.Button();
            this.previewBtn = new System.Windows.Forms.Button();
            this.scanBtn = new System.Windows.Forms.Button();
            this.preScanBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 14);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(547, 444);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dpiCb1);
            this.tabPage1.Controls.Add(this.removeFrameBtn);
            this.tabPage1.Controls.Add(this.addFrameBtn);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.printDevicesCb1);
            this.tabPage1.Controls.Add(this.button11);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(539, 415);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "遺影";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dpiCb1
            // 
            this.dpiCb1.FormattingEnabled = true;
            this.dpiCb1.Items.AddRange(new object[] {
            "72",
            "96",
            "150",
            "203",
            "300",
            "2540",
            "4000"});
            this.dpiCb1.Location = new System.Drawing.Point(147, 283);
            this.dpiCb1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dpiCb1.Name = "dpiCb1";
            this.dpiCb1.Size = new System.Drawing.Size(228, 24);
            this.dpiCb1.TabIndex = 5;
            this.dpiCb1.SelectedIndexChanged += new System.EventHandler(this.DpiCb1_SelectedIndexChanged);
            // 
            // removeFrameBtn
            // 
            this.removeFrameBtn.Enabled = false;
            this.removeFrameBtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.removeFrameBtn.FlatAppearance.BorderSize = 2;
            this.removeFrameBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeFrameBtn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.removeFrameBtn.Location = new System.Drawing.Point(400, 338);
            this.removeFrameBtn.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.removeFrameBtn.Name = "removeFrameBtn";
            this.removeFrameBtn.Size = new System.Drawing.Size(99, 23);
            this.removeFrameBtn.TabIndex = 7;
            this.removeFrameBtn.Text = "選択枠を削除";
            this.removeFrameBtn.UseVisualStyleBackColor = true;
            this.removeFrameBtn.Click += new System.EventHandler(this.RemoveFrameBtn_Click);
            // 
            // addFrameBtn
            // 
            this.addFrameBtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.addFrameBtn.FlatAppearance.BorderSize = 2;
            this.addFrameBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addFrameBtn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.addFrameBtn.Location = new System.Drawing.Point(200, 338);
            this.addFrameBtn.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.addFrameBtn.Name = "addFrameBtn";
            this.addFrameBtn.Size = new System.Drawing.Size(108, 23);
            this.addFrameBtn.TabIndex = 6;
            this.addFrameBtn.Text = "選択枠を追加";
            this.addFrameBtn.UseVisualStyleBackColor = true;
            this.addFrameBtn.Click += new System.EventHandler(this.AddFrameBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 283);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 35;
            this.label1.Text = "解像度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(400, 283);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "dpi";
            // 
            // printDevicesCb1
            // 
            this.printDevicesCb1.FormattingEnabled = true;
            this.printDevicesCb1.Location = new System.Drawing.Point(147, 228);
            this.printDevicesCb1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.printDevicesCb1.Name = "printDevicesCb1";
            this.printDevicesCb1.Size = new System.Drawing.Size(228, 24);
            this.printDevicesCb1.TabIndex = 3;
            // 
            // button11
            // 
            this.button11.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.button11.FlatAppearance.BorderSize = 2;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button11.Location = new System.Drawing.Point(400, 228);
            this.button11.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 4;
            this.button11.Text = "選択";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(40, 228);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 30;
            this.label8.Text = "ディバイス";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(487, 123);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 16);
            this.label9.TabIndex = 29;
            this.label9.Text = "家";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(147, 92);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(247, 80);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(147, 31);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(335, 22);
            this.textBox2.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(40, 31);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 16);
            this.label10.TabIndex = 26;
            this.label10.Text = "コード";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.dpiCb2);
            this.tabPage2.Controls.Add(this.printDevicesCb2);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(539, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "メモリアル";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button2.Location = new System.Drawing.Point(300, 274);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "選択枠を削除";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button3.Location = new System.Drawing.Point(149, 274);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "選択枠を追加";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 47;
            this.label3.Text = "解像度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(300, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 16);
            this.label4.TabIndex = 46;
            this.label4.Text = "dpi";
            // 
            // dpiCb2
            // 
            this.dpiCb2.FormattingEnabled = true;
            this.dpiCb2.Items.AddRange(new object[] {
            "72",
            "96",
            "150",
            "203",
            "300",
            "2540",
            "4000"});
            this.dpiCb2.Location = new System.Drawing.Point(147, 283);
            this.dpiCb2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dpiCb2.Name = "dpiCb2";
            this.dpiCb2.Size = new System.Drawing.Size(228, 24);
            this.dpiCb2.TabIndex = 5;
            // 
            // printDevicesCb2
            // 
            this.printDevicesCb2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.printDevicesCb2.FormattingEnabled = true;
            this.printDevicesCb2.Location = new System.Drawing.Point(147, 228);
            this.printDevicesCb2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.printDevicesCb2.Name = "printDevicesCb2";
            this.printDevicesCb2.Size = new System.Drawing.Size(228, 24);
            this.printDevicesCb2.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.button4.FlatAppearance.BorderSize = 2;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button4.Location = new System.Drawing.Point(300, 185);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "選択";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 42;
            this.label5.Text = "ディバイス";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(365, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 16);
            this.label6.TabIndex = 41;
            this.label6.Text = "家";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(109, 75);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(247, 80);
            this.textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(109, 25);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(335, 22);
            this.textBox4.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 16);
            this.label7.TabIndex = 38;
            this.label7.Text = "コード";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.decisionBtn);
            this.panel5.Controls.Add(this.previewBtn);
            this.panel5.Controls.Add(this.scanBtn);
            this.panel5.Controls.Add(this.preScanBtn);
            this.panel5.Controls.Add(this.closeBtn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 466);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1235, 100);
            this.panel5.TabIndex = 1;
            // 
            // decisionBtn
            // 
            this.decisionBtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.decisionBtn.FlatAppearance.BorderSize = 2;
            this.decisionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decisionBtn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.decisionBtn.Location = new System.Drawing.Point(789, 39);
            this.decisionBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.decisionBtn.Name = "decisionBtn";
            this.decisionBtn.Size = new System.Drawing.Size(75, 23);
            this.decisionBtn.TabIndex = 29;
            this.decisionBtn.Text = "決定";
            this.decisionBtn.UseVisualStyleBackColor = true;
            this.decisionBtn.Click += new System.EventHandler(this.decisionBtn_Click);
            // 
            // previewBtn
            // 
            this.previewBtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.previewBtn.FlatAppearance.BorderSize = 2;
            this.previewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewBtn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.previewBtn.Location = new System.Drawing.Point(624, 39);
            this.previewBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(91, 23);
            this.previewBtn.TabIndex = 28;
            this.previewBtn.Text = "プレビュー";
            this.previewBtn.UseVisualStyleBackColor = true;
            this.previewBtn.Click += new System.EventHandler(this.previewBtn_Click);
            // 
            // scanBtn
            // 
            this.scanBtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.scanBtn.FlatAppearance.BorderSize = 2;
            this.scanBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanBtn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.scanBtn.Location = new System.Drawing.Point(436, 39);
            this.scanBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.scanBtn.Name = "scanBtn";
            this.scanBtn.Size = new System.Drawing.Size(75, 23);
            this.scanBtn.TabIndex = 27;
            this.scanBtn.Text = "スキャン";
            this.scanBtn.UseVisualStyleBackColor = true;
            this.scanBtn.Click += new System.EventHandler(this.OnScanBtn_Click);
            // 
            // preScanBtn
            // 
            this.preScanBtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.preScanBtn.FlatAppearance.BorderSize = 2;
            this.preScanBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preScanBtn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.preScanBtn.Location = new System.Drawing.Point(227, 39);
            this.preScanBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.preScanBtn.Name = "preScanBtn";
            this.preScanBtn.Size = new System.Drawing.Size(95, 23);
            this.preScanBtn.TabIndex = 26;
            this.preScanBtn.Text = "プレスキャン";
            this.preScanBtn.UseVisualStyleBackColor = true;
            // 
            // closeBtn
            // 
            this.closeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.closeBtn.FlatAppearance.BorderSize = 2;
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.closeBtn.Location = new System.Drawing.Point(63, 39);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 25;
            this.closeBtn.Text = "閉じる";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(571, 39);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(656, 415);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // Scanation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 566);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Scanation";
            this.Text = "Scanation";
            this.Load += new System.EventHandler(this.Scanation_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dpiCb2;
        private System.Windows.Forms.ComboBox printDevicesCb2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox dpiCb1;
    }
}

