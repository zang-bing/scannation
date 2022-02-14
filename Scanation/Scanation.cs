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
        private Bitmap _grayImage;

        private Stack<FrameSelection> _frames = new Stack<FrameSelection>();
        private int _initalFramePos = 10;

        // constants
        private const int FRAME_SIZE = 100;

        public Scanation(string id, string name)
        {
            InitializeComponent();
            textBoxId.Text = id;
            textBoxName.Text = name;
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
            _initialImage = (Bitmap)bitmap.Clone();
            _grayImage = ((Bitmap)bitmap.Clone()).ToImage<Gray, byte>().ToBitmap();
            pictureBox.Image = bitmap;
            var size = int.Parse(dpiCb1.SelectedItem.ToString());
            pictureBox.Image = ImageUtils.Resize(pictureBox.Image, size, size);
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
        }

        private void PrintFrames()
        {
            foreach (var frame in _frames)
            {
                ImageUtils.Print(frame.SelectedBitmap);
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

        private void preScanBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
