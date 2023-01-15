namespace RSA_Cipher
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
            this.EncodeGroupBox = new System.Windows.Forms.GroupBox();
            this.EncodeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PTextBox = new System.Windows.Forms.TextBox();
            this.QTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NTextbox = new System.Windows.Forms.TextBox();
            this.DTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DecodeButton = new System.Windows.Forms.Button();
            this.EncodeGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EncodeGroupBox
            // 
            this.EncodeGroupBox.BackColor = System.Drawing.SystemColors.Info;
            this.EncodeGroupBox.Controls.Add(this.QTextBox);
            this.EncodeGroupBox.Controls.Add(this.PTextBox);
            this.EncodeGroupBox.Controls.Add(this.label2);
            this.EncodeGroupBox.Controls.Add(this.label1);
            this.EncodeGroupBox.Controls.Add(this.EncodeButton);
            this.EncodeGroupBox.Location = new System.Drawing.Point(13, 14);
            this.EncodeGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EncodeGroupBox.Name = "EncodeGroupBox";
            this.EncodeGroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EncodeGroupBox.Size = new System.Drawing.Size(173, 147);
            this.EncodeGroupBox.TabIndex = 0;
            this.EncodeGroupBox.TabStop = false;
            // 
            // EncodeButton
            // 
            this.EncodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EncodeButton.Location = new System.Drawing.Point(13, 79);
            this.EncodeButton.Name = "EncodeButton";
            this.EncodeButton.Size = new System.Drawing.Size(148, 58);
            this.EncodeButton.TabIndex = 0;
            this.EncodeButton.Text = "Encode";
            this.EncodeButton.UseVisualStyleBackColor = true;
            this.EncodeButton.Click += new System.EventHandler(this.EncodeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "P =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Q =";
            // 
            // PTextBox
            // 
            this.PTextBox.Location = new System.Drawing.Point(47, 17);
            this.PTextBox.Name = "PTextBox";
            this.PTextBox.Size = new System.Drawing.Size(114, 26);
            this.PTextBox.TabIndex = 3;
            this.PTextBox.Text = "7";
            // 
            // QTextBox
            // 
            this.QTextBox.Location = new System.Drawing.Point(47, 47);
            this.QTextBox.Name = "QTextBox";
            this.QTextBox.Size = new System.Drawing.Size(114, 26);
            this.QTextBox.TabIndex = 4;
            this.QTextBox.Text = "13";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Info;
            this.groupBox1.Controls.Add(this.NTextbox);
            this.groupBox1.Controls.Add(this.DTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DecodeButton);
            this.groupBox1.Location = new System.Drawing.Point(194, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(173, 147);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // NTextbox
            // 
            this.NTextbox.Location = new System.Drawing.Point(47, 47);
            this.NTextbox.Name = "NTextbox";
            this.NTextbox.Size = new System.Drawing.Size(114, 26);
            this.NTextbox.TabIndex = 4;
            // 
            // DTextBox
            // 
            this.DTextBox.Location = new System.Drawing.Point(47, 17);
            this.DTextBox.Name = "DTextBox";
            this.DTextBox.Size = new System.Drawing.Size(114, 26);
            this.DTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "N =";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "D =";
            // 
            // DecodeButton
            // 
            this.DecodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DecodeButton.Location = new System.Drawing.Point(13, 79);
            this.DecodeButton.Name = "DecodeButton";
            this.DecodeButton.Size = new System.Drawing.Size(148, 58);
            this.DecodeButton.TabIndex = 0;
            this.DecodeButton.Text = "Decode";
            this.DecodeButton.UseVisualStyleBackColor = true;
            this.DecodeButton.Click += new System.EventHandler(this.DecodeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 163);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.EncodeGroupBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "RSA";
            this.EncodeGroupBox.ResumeLayout(false);
            this.EncodeGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox EncodeGroupBox;
        private System.Windows.Forms.Button EncodeButton;
        private System.Windows.Forms.TextBox QTextBox;
        private System.Windows.Forms.TextBox PTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox NTextbox;
        private System.Windows.Forms.TextBox DTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button DecodeButton;
    }
}

