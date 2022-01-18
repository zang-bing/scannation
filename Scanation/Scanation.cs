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
            List<string> listDevices = new List<string>();
            InitializeComponent();

            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                listDevices.Add(printer);
            }

            cbxPrintDevices.DataSource = listDevices;
        }
    }
}
