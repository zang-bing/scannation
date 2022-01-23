using System;
using System.Collections.Generic;
using Scanation.Utils;
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

            cbxPrintDevices.DataSource = listDevices;

            var fakeImg = "https://lh3.googleusercontent.com/LBZbzy9NXoY_0vQQOkDQnVSzu27am8yxvcsxOk0CPhfnr7uraTv-9ONUje1b7zcK0bTqTbI1_pY2hVzXu4aGbSQ9";
            pictureBox.Load(fakeImg);
        }

        private void previewBtn_Click(object sender, EventArgs e)
        {
            Form preViewForm = new Form();
            var picture = new PictureBox();
            picture.Image = ImageUtils.FromUrl("https://lh3.googleusercontent.com/LBZbzy9NXoY_0vQQOkDQnVSzu27am8yxvcsxOk0CPhfnr7uraTv-9ONUje1b7zcK0bTqTbI1_pY2hVzXu4aGbSQ9");
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
