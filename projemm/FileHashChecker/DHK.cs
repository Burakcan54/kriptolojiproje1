using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Policy;


namespace FileHashChecker
{
    public partial class DHK : Form
    {
        public DHK()
        {
            InitializeComponent();
        }
        public static class Algorithms
        {
            public static readonly HashAlgorithm MD5 = new MD5CryptoServiceProvider();
        }
        public static string GetHashFromFile(string fileName, HashAlgorithm algorithm)
        {
            using (var stream = new BufferedStream(File.OpenRead(fileName), 100000))
            {
                return BitConverter.ToString(algorithm.ComputeHash(stream)).Replace("-", string.Empty).ToLowerInvariant();
            }
        }
        private void Sec_Click(object sender, EventArgs e)
        {
            if(Dosya.ShowDialog() == DialogResult.OK)
            {
                string Yol = Dosya.FileName;
                textBox1.Text = Yol;
                if (File.Exists(Yol)) 
                {
                    string dosyaAd = Dosya.SafeFileName;
                    FileInfo fileInfo = new FileInfo(Yol);
                    label3.Text = dosyaAd;
                }
                string Md5 = GetHashFromFile(Yol, Algorithms.MD5);
                textBox2.Text = Md5;
            }
        }
        private void Karsilastir_Click(object sender, EventArgs e)
        {
            if( textBox3.Text == textBox2.Text)
            {
                label6.Visible = true;
                label7.Visible = false;
            }
            else 
            {
                label6.Visible = false;
                label7.Visible= true;
            }
        }
    }
}
