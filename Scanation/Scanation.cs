using Scanation.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Scanation
{
    public partial class Scanation : Form
    {
        public Scanation()
        {
            InitializeComponent();
        }

        private void Scanation_Load(object sender, EventArgs e)
        {
            List<string> listDevices = new List<string>();
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                listDevices.Add(printer);
            }

            printDevicesCb1.DataSource = listDevices;
            printDevicesCb2.DataSource = listDevices;
            dpiCb1.SelectedIndex = 4;
            dpiCb2.SelectedIndex = 4;

            var fakeImg = "https://lh3.googleusercontent.com/LBZbzy9NXoY_0vQQOkDQnVSzu27am8yxvcsxOk0CPhfnr7uraTv-9ONUje1b7zcK0bTqTbI1_pY2hVzXu4aGbSQ9";
            Bitmap bitmap = ImageUtils.FromUrl(fakeImg);
            bitmap.SetResolution((float)(bitmap.Width * 0.5), (float)(bitmap.Height * .5));
            pictureBox.Image = bitmap;
            var size = int.Parse(dpiCb1.SelectedItem.ToString());
            pictureBox.Image = ImageUtils.Resize(pictureBox.Image, size, size);
        }

        private void OnScanBtn_Click(object sender, EventArgs e)
        {
            var printDocument = new System.Drawing.Printing.PrintDocument();
            PrintDialog printDialog = new PrintDialog();
            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(OnPrintDocument_PrintPage);
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void OnPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.DrawToBitmap(bitmap, new Rectangle(0, 0, pictureBox.Width, pictureBox.Height));
            e.Graphics.DrawImage(bitmap, 0, 0);
            bitmap.Dispose();
        }

        private void OnDpiTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void DpiCb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int size = int.Parse(comboBox.SelectedItem.ToString());
            pictureBox.Image = ImageUtils.Resize(pictureBox.Image, size, size);
        }

        private void previewBtn_Click(object sender, EventArgs e)
        {
            Form preViewForm = new Form();
            
            var picture = new PictureBox();
            
            picture.Image = ImageUtils.FromUrl("https://lh3.googleusercontent.com/LBZbzy9NXoY_0vQQOkDQnVSzu27am8yxvcsxOk0CPhfnr7uraTv-9ONUje1b7zcK0bTqTbI1_pY2hVzXu4aGbSQ9");
            Size size = new Size(picture.Image.Width, picture.Image.Height);
            picture.Size = size;
            preViewForm.Width = picture.Width;
            preViewForm.Height = picture.Height;
            preViewForm.Controls.Add(picture);
            preViewForm.ShowDialog();
        }

        private void decisionBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
