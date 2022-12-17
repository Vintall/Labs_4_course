//AUTHOR: Ismail JH + Wassem Kassoumeh from Arab International University

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.IO;

namespace SDES_Project
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
            label2.Text = "Ready";
        }
        SDES my_Des;
        Random rand = new Random();

        private void btn_Enc(object sender, EventArgs e)
        {
            try
            {
                if (txt_Enc_Key.Text.Length == 10)
                {
                    my_Des = new SDES(txt_Enc_Key.Text);
                    Encrypt();
                    label2.Text = "Encryption succeeded";
                }
                else
                    MessageBox.Show("Key length should equal 10.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                label2.Text = "Encryption failed ! --> ";
                label2.Text += "The archive is either in unknown format or damaged";

            }
        }

        private void btn_Dec(object sender, EventArgs e)
        {
            try
            {
                if (txt_Dec_Key.Text.Length == 10)
                {
                    my_Des = new SDES(txt_Dec_Key.Text);
                    Decrypt();
                    label2.Text = "Decryption succeeded";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                label2.Text = "Decryption failed ! --> ";
                label2.Text += "The archive is either in unknown format or damaged";
            }
        }
        
        private void btn_Browes1(object sender, EventArgs e)
        {
            label2.Text = "Ready";
            openFileDialog1.Filter = "All Files (*.*)|*.*";
            openFileDialog1.FileName = "";
            if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txt_enc_in.Text = this.openFileDialog1.FileName;
                string output = txt_enc_in.Text + ".!#";
                int q = 1;
                while (File.Exists(output))
                {
                    output = output.Insert(output.IndexOf('.'), q.ToString());
                    q++;
                }
                txt_enc_out.Text = output;
            }
        }

        private void btn_Browes2(object sender, EventArgs e)
        {
            label2.Text = "Ready";
            openFileDialog1.Filter = "Encrypted Files (*.!#)|*.!#";
            openFileDialog1.FileName = "";
            if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txt_dec_in.Text = this.openFileDialog1.FileName;
                string output = txt_dec_in.Text.Remove(txt_dec_in.Text.IndexOf(".!#"), 3);
                int q = 1;
                while (File.Exists(output))
                {
                    output = output.Insert(output.IndexOf('.'), q.ToString());
                    q++;
                }
                txt_dec_out.Text = output;
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            txt_dec_in.Text = "";
            txt_Dec_Key.Text = "";
            txt_dec_out.Text = "";
            txt_enc_in.Text = "";
            txt_Enc_Key.Text = "";
            txt_enc_out.Text = "";
            label2.Text = "Ready";
        }

        private void Encrypt()
        {
            FileStream fs = new FileStream(txt_enc_in.Text, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            FileStream fs2 = new FileStream(txt_enc_out.Text, FileMode.Create);
            BinaryWriter bwr = new BinaryWriter(fs2);
            int blocksize = 4 * 1024;
            int iteration_number;
            if (fs.Length < blocksize)
                iteration_number = 1;
            else if (fs.Length % blocksize == 0)
                iteration_number = (int)fs.Length / blocksize;
            else
                iteration_number = ((int)fs.Length / blocksize) + 1;
            while (iteration_number-- > 0)
            {
                if (iteration_number == 0)
                    blocksize = (int)fs.Length % blocksize;
                byte[] input = br.ReadBytes(blocksize);
                byte[] output = new byte[input.Length];
                for (int i = 0; i < output.Length; i++)
                {
                    output[i] = my_Des.Encrypt(input[i]);
                }
                bwr.Write(output);
                bwr.Flush();
            }
            bwr.Close();
            fs2.Close();
            br.Close();
            fs.Close();
        }

        private void Decrypt()
        {
            FileStream fs = new FileStream(txt_dec_in.Text, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            FileStream fs2 = new FileStream(txt_dec_out.Text, FileMode.Create);
            BinaryWriter bwr = new BinaryWriter(fs2);
            int blocksize = 4 * 1024;
            int iteration_number;
            if (fs.Length < blocksize)
                iteration_number = 1;
            else if (fs.Length % blocksize == 0)
                iteration_number = (int)fs.Length / blocksize;
            else
                iteration_number = ((int)fs.Length / blocksize) + 1;
            while (iteration_number-- > 0)
            {
                if (iteration_number == 0)
                    blocksize = (int)fs.Length % blocksize;
                byte[] input = br.ReadBytes(blocksize);
                byte[] output = new byte[input.Length];
                for (int i = 0; i < output.Length; i++)
                {
                    output[i] = my_Des.Decrypt(input[i]);
                }
                bwr.Write(output);
                bwr.Flush();
            }
            bwr.Close();
            fs2.Close();
            br.Close();
            fs.Close();
        }

        private void Generate_Key_button_Click(object sender, EventArgs e)
        {
            int key = rand.Next(0, 1025);
            txt_Enc_Key.Text = decimal2binstr(key);
            while (txt_Enc_Key.Text.Length < 10)
            {
                txt_Enc_Key.Text = "0" + txt_Enc_Key.Text;
            }
        }

        public string decimal2binstr(int num)
        {
            string ret = "";
            for (int i = 0; i < 8; i++)
            {
                if (num % 2 == 1)
                    ret = "1" + ret;
                else
                    ret = "0" + ret;
                num >>= 1;
            }
            return ret;
        }

    }
}