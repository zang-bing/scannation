using Scanation.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Scanation
{
    public partial class Scanation : Form
    {
        // image
        private Bitmap _initialImage;

        private Stack<FrameSelection> _frames = new Stack<FrameSelection>();
        private int _initalFramePos = 10;
        private int _currentDpi = 300;
        public string url = "";

        // constants
        private const int FRAME_SIZE = 100;

        public Scanation(string id, string name, string url)
        {
            InitializeComponent();
            textBoxId.Text = id;
            textBoxName.Text = name;
            this.url = "http://" + url;
        }

        public Scanation(string url)
        {
            InitializeComponent();
            this.url = "http://" + url;
        }

        private void OnScanBtn_Click(object sender, EventArgs e)
        {
            if (_frames.Count > 0)
            {
                PrintFrames();
                return;
            } else
            {
                PrintPicture();
            }
        }

        private void PrintPicture()
        {
            var width = pictureBox.Image.Width;
            var height = pictureBox.Image.Height;
            Bitmap bitmap = new Bitmap(width, height);
            pictureBox.DrawToBitmap(bitmap, new Rectangle(0, 0, width, height));
            ImageUtils.Print(bitmap);
            ImageUtils.SaveToFile(bitmap);
        }

        private void PrintFrames()
        {
            foreach (var frame in _frames)
            {
                ImageUtils.Print(frame.SelectedBitmap);
                ImageUtils.SaveToFile(frame.SelectedBitmap);
            }
        }

        private void DpiCb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int size = int.Parse(comboBox.SelectedItem.ToString());
            if (pictureBox.Image == null) return;
            var newImage = ImageUtils.CvResize(new Bitmap(_initialImage), size, size);
            if (newImage != null)
            {
                pictureBox.Image = newImage;
            }
        }

        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            List<string> listDevices = new List<string>();
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                listDevices.Add(printer);
            }

            printDevicesCb1.DataSource = listDevices;
            printDevicesCb2.DataSource = listDevices;
            dpiTb1.Text = $"{Constants.MIN_DPI * 20}";
            dpiTb2.Text = $"{Constants.MIN_DPI * 20}";

            Bitmap bitmap = ImageUtils.FromUrl(url);
            _initialImage = (Bitmap)bitmap.Clone();
            pictureBox.Image = bitmap;
            var size = int.Parse(dpiTb1.Text);
            pictureBox.Image = ImageUtils.Resize(pictureBox.Image, size, size);

            EnableComponents();
        }

        private void EnableComponents()
        {
            printDevicesCb1.Enabled = true;
            dpiTb1.Enabled = true;
            scanBtn.Enabled = true;
            preScanBtn.Enabled = true;
            addFrameBtn.Enabled = true;
        }

        private void DecisionBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void AddFrameBtn_Click(object sender, EventArgs e)
        {
            //int pictureBoxBmpX = pictureBox.Image.GetBounds().X;
            var sizableRect = new FrameSelection(new Rectangle(_initalFramePos, _initalFramePos, FRAME_SIZE, FRAME_SIZE));
            _initalFramePos += 10;
            sizableRect.SetPictureBox(pictureBox);
            _frames.Push(sizableRect);
            pictureBox.Invalidate();

            if (!removeFrameBtn.Enabled)
            {
                removeFrameBtn.Enabled = true;
            }
        }

        private void RemoveFrameBtn_Click(object sender, EventArgs e)
        {
            var frame = _frames.Pop();
            frame.Dispose();
            pictureBox.Invalidate();

            if (_frames.Count <= 0)
            {
                removeFrameBtn.Enabled = false;
            }
        }

        private void PreScanBtn_Click(object sender, EventArgs e)
        {
            var images = new List<Bitmap>();
            foreach (var frame in _frames)
            {
                images.Add(frame.SelectedBitmap);
            }
            var preScanForm = new PrescanForm(images);
            preScanForm.Show();
        }

        private void printDevicesCb1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DpiTb_TextChanged(object sender, EventArgs e)
        {
            if (pictureBox.Image == null) return;
            int size;
            var check = int.TryParse(dpiTb1.Text, out size);
            if (!check) return;
            if (size < Constants.MIN_DPI || size > Constants.MAX_DPI)
            {
                return;
            }
            var newImage = ImageUtils.Resize(new Bitmap(_initialImage), size, size);
            if (newImage != null)
            {
                pictureBox.Image = newImage;
            }
        }

        private void DpiTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
