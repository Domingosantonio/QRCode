using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorCodeQR
{
    public partial class Form1 : Form
    {
        SaveFileDialog SaveArquivo = new SaveFileDialog();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(txtCodQR.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            picFoto.Image = qrCodeImage;
            //SALVADO 
            SaveArquivo.Filter = "JPG (*.jpg)|*.jpg*";
            SaveArquivo.AddExtension = true;
            SaveArquivo.DefaultExt = ".jpg";
            if (SaveArquivo.ShowDialog() == DialogResult.OK)
            {
                picFoto.Image.Save(SaveArquivo.FileName);
                MessageBox.Show("O Code QR salvo com sucesso!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
