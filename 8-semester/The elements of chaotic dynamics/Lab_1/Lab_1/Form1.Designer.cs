namespace Lab_1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_T1_V2 = new System.Windows.Forms.TextBox();
            this.textBox_T1_V1 = new System.Windows.Forms.TextBox();
            this.textBox_T1_M22 = new System.Windows.Forms.TextBox();
            this.textBox_T1_M21 = new System.Windows.Forms.TextBox();
            this.textBox_T1_M12 = new System.Windows.Forms.TextBox();
            this.textBox_T1_M11 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(511, 152);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(511, 120);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Iterations";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(594, 118);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(74, 26);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.textBox_T1_V2);
            this.groupBox1.Controls.Add(this.textBox_T1_V1);
            this.groupBox1.Controls.Add(this.textBox_T1_M22);
            this.groupBox1.Controls.Add(this.textBox_T1_M21);
            this.groupBox1.Controls.Add(this.textBox_T1_M12);
            this.groupBox1.Controls.Add(this.textBox_T1_M11);
            this.groupBox1.Location = new System.Drawing.Point(511, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 89);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "T1";
            this.groupBox1.Visible = false;
            // 
            // textBox_T1_V2
            // 
            this.textBox_T1_V2.Location = new System.Drawing.Point(135, 57);
            this.textBox_T1_V2.Name = "textBox_T1_V2";
            this.textBox_T1_V2.Size = new System.Drawing.Size(50, 26);
            this.textBox_T1_V2.TabIndex = 5;
            this.textBox_T1_V2.Text = "0";
            // 
            // textBox_T1_V1
            // 
            this.textBox_T1_V1.Location = new System.Drawing.Point(135, 25);
            this.textBox_T1_V1.Name = "textBox_T1_V1";
            this.textBox_T1_V1.Size = new System.Drawing.Size(50, 26);
            this.textBox_T1_V1.TabIndex = 4;
            this.textBox_T1_V1.Text = "0";
            // 
            // textBox_T1_M22
            // 
            this.textBox_T1_M22.Location = new System.Drawing.Point(62, 57);
            this.textBox_T1_M22.Name = "textBox_T1_M22";
            this.textBox_T1_M22.Size = new System.Drawing.Size(50, 26);
            this.textBox_T1_M22.TabIndex = 3;
            this.textBox_T1_M22.Text = "0.8";
            // 
            // textBox_T1_M21
            // 
            this.textBox_T1_M21.Location = new System.Drawing.Point(6, 57);
            this.textBox_T1_M21.Name = "textBox_T1_M21";
            this.textBox_T1_M21.Size = new System.Drawing.Size(50, 26);
            this.textBox_T1_M21.TabIndex = 2;
            this.textBox_T1_M21.Text = "0.6";
            // 
            // textBox_T1_M12
            // 
            this.textBox_T1_M12.Location = new System.Drawing.Point(62, 25);
            this.textBox_T1_M12.Name = "textBox_T1_M12";
            this.textBox_T1_M12.Size = new System.Drawing.Size(50, 26);
            this.textBox_T1_M12.TabIndex = 1;
            this.textBox_T1_M12.Text = "0.7";
            // 
            // textBox_T1_M11
            // 
            this.textBox_T1_M11.Location = new System.Drawing.Point(6, 25);
            this.textBox_T1_M11.Name = "textBox_T1_M11";
            this.textBox_T1_M11.Size = new System.Drawing.Size(50, 26);
            this.textBox_T1_M11.TabIndex = 0;
            this.textBox_T1_M11.Text = "0.9";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(511, 197);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(194, 35);
            this.button2.TabIndex = 6;
            this.button2.Text = "Make one more iteration";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(503, 240);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(214, 264);
            this.listBox1.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(716, 500);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_T1_V2;
        private System.Windows.Forms.TextBox textBox_T1_V1;
        private System.Windows.Forms.TextBox textBox_T1_M22;
        private System.Windows.Forms.TextBox textBox_T1_M21;
        private System.Windows.Forms.TextBox textBox_T1_M12;
        private System.Windows.Forms.TextBox textBox_T1_M11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Timer timer1;
    }
}

