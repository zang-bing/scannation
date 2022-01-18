using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            var fakeImg = "https://upload.wikimedia.org/wikipedia/vi/1/1d/N%C6%A1i_n%C3%A0y_c%C3%B3_anh_-_Single_Cover.jpg";
            pictureBox.Load(fakeImg);
        }
    }
}
