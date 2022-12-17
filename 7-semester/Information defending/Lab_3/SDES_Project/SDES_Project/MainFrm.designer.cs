namespace SDES_Project
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Generate_Key_button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Enc_Key = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_enc_out = new System.Windows.Forms.TextBox();
            this.btn_enc_browser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEnc = new System.Windows.Forms.Button();
            this.txt_enc_in = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Dec_Key = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_dec_out = new System.Windows.Forms.TextBox();
            this.btn_dec_browser = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDec = new System.Windows.Forms.Button();
            this.txt_dec_in = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.label2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 326);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(586, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label2
            // 
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(586, 326);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.Generate_Key_button);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txt_Enc_Key);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txt_enc_out);
            this.tabPage1.Controls.Add(this.btn_enc_browser);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnEnc);
            this.tabPage1.Controls.Add(this.txt_enc_in);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(578, 300);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Encrypt";
            // 
            // Generate_Key_button
            // 
            this.Generate_Key_button.Location = new System.Drawing.Point(481, 75);
            this.Generate_Key_button.Name = "Generate_Key_button";
            this.Generate_Key_button.Size = new System.Drawing.Size(63, 21);
            this.Generate_Key_button.TabIndex = 16;
            this.Generate_Key_button.Text = "Generate Key";
            this.Generate_Key_button.UseVisualStyleBackColor = true;
            this.Generate_Key_button.Click += new System.EventHandler(this.Generate_Key_button_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Input key path:";
            // 
            // txt_Enc_Key
            // 
            this.txt_Enc_Key.Location = new System.Drawing.Point(33, 75);
            this.txt_Enc_Key.MaxLength = 10;
            this.txt_Enc_Key.Name = "txt_Enc_Key";
            this.txt_Enc_Key.Size = new System.Drawing.Size(401, 20);
            this.txt_Enc_Key.TabIndex = 14;
            this.txt_Enc_Key.Text = "1111111111";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Output file path:";
            // 
            // txt_enc_out
            // 
            this.txt_enc_out.Enabled = false;
            this.txt_enc_out.Location = new System.Drawing.Point(33, 223);
            this.txt_enc_out.Name = "txt_enc_out";
            this.txt_enc_out.Size = new System.Drawing.Size(401, 20);
            this.txt_enc_out.TabIndex = 12;
            // 
            // btn_enc_browser
            // 
            this.btn_enc_browser.Location = new System.Drawing.Point(481, 35);
            this.btn_enc_browser.Name = "btn_enc_browser";
            this.btn_enc_browser.Size = new System.Drawing.Size(63, 21);
            this.btn_enc_browser.TabIndex = 11;
            this.btn_enc_browser.Text = "Browse";
            this.btn_enc_browser.UseVisualStyleBackColor = true;
            this.btn_enc_browser.Click += new System.EventHandler(this.btn_Browes1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Input file path:";
            // 
            // btnEnc
            // 
            this.btnEnc.Location = new System.Drawing.Point(481, 215);
            this.btnEnc.Name = "btnEnc";
            this.btnEnc.Size = new System.Drawing.Size(63, 40);
            this.btnEnc.TabIndex = 9;
            this.btnEnc.Text = "Encrypt";
            this.btnEnc.UseVisualStyleBackColor = true;
            this.btnEnc.Click += new System.EventHandler(this.btn_Enc);
            // 
            // txt_enc_in
            // 
            this.txt_enc_in.Enabled = false;
            this.txt_enc_in.Location = new System.Drawing.Point(33, 35);
            this.txt_enc_in.Name = "txt_enc_in";
            this.txt_enc_in.Size = new System.Drawing.Size(401, 20);
            this.txt_enc_in.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txt_Dec_Key);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txt_dec_out);
            this.tabPage2.Controls.Add(this.btn_dec_browser);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.btnDec);
            this.tabPage2.Controls.Add(this.txt_dec_in);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(578, 304);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Decrypt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Input key path:";
            // 
            // txt_Dec_Key
            // 
            this.txt_Dec_Key.Location = new System.Drawing.Point(33, 75);
            this.txt_Dec_Key.MaxLength = 10;
            this.txt_Dec_Key.Name = "txt_Dec_Key";
            this.txt_Dec_Key.Size = new System.Drawing.Size(401, 20);
            this.txt_Dec_Key.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Output file path:";
            // 
            // txt_dec_out
            // 
            this.txt_dec_out.Enabled = false;
            this.txt_dec_out.Location = new System.Drawing.Point(33, 223);
            this.txt_dec_out.Name = "txt_dec_out";
            this.txt_dec_out.Size = new System.Drawing.Size(401, 20);
            this.txt_dec_out.TabIndex = 21;
            // 
            // btn_dec_browser
            // 
            this.btn_dec_browser.Location = new System.Drawing.Point(481, 35);
            this.btn_dec_browser.Name = "btn_dec_browser";
            this.btn_dec_browser.Size = new System.Drawing.Size(63, 21);
            this.btn_dec_browser.TabIndex = 20;
            this.btn_dec_browser.Text = "Browse";
            this.btn_dec_browser.UseVisualStyleBackColor = true;
            this.btn_dec_browser.Click += new System.EventHandler(this.btn_Browes2);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Input file path:";
            // 
            // btnDec
            // 
            this.btnDec.Location = new System.Drawing.Point(481, 215);
            this.btnDec.Name = "btnDec";
            this.btnDec.Size = new System.Drawing.Size(63, 40);
            this.btnDec.TabIndex = 18;
            this.btnDec.Text = "Decrypt";
            this.btnDec.UseVisualStyleBackColor = true;
            this.btnDec.Click += new System.EventHandler(this.btn_Dec);
            // 
            // txt_dec_in
            // 
            this.txt_dec_in.Enabled = false;
            this.txt_dec_in.Location = new System.Drawing.Point(33, 35);
            this.txt_dec_in.Name = "txt_dec_in";
            this.txt_dec_in.Size = new System.Drawing.Size(401, 20);
            this.txt_dec_in.TabIndex = 17;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(586, 348);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SDES";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_enc_out;
        private System.Windows.Forms.Button btn_enc_browser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEnc;
        private System.Windows.Forms.TextBox txt_enc_in;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Enc_Key;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Dec_Key;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_dec_out;
        private System.Windows.Forms.Button btn_dec_browser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDec;
        private System.Windows.Forms.TextBox txt_dec_in;
        private System.Windows.Forms.Button Generate_Key_button;
    }
}

