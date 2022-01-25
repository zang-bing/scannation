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

        private Point RectStartPoint;
        private Rectangle Rect = new Rectangle();
        private Brush selectionBrush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));

        private Stack<FrameSelection> _frames = new Stack<FrameSelection>();
        private int _initalFramePos = 10;

        // constants
        private const int FRAME_SIZE = 100;

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
            _initialImage = (Bitmap)bitmap.Clone();
            _grayImage = ((Bitmap)bitmap.Clone()).ToImage<Gray, byte>().ToBitmap();
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
            if (pictureBox.Image == null) return;
            var newImage = ImageUtils.CvResize(new Bitmap(_initialImage), size, size);
            if (newImage != null)
            {
                pictureBox.Image = newImage;
            }
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

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            RectStartPoint = e.Location;
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            Point tempEndPoint = e.Location;
            Rect.Location = new Point(
                Math.Min(RectStartPoint.X, tempEndPoint.X),
                Math.Min(RectStartPoint.Y, tempEndPoint.Y));
            Rect.Size = new Size(
                Math.Abs(RectStartPoint.X - tempEndPoint.X),
                Math.Abs(RectStartPoint.Y - tempEndPoint.Y));
            pictureBox.Invalidate();
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox.Image != null)
            {
                if (Rect != null && Rect.Width > 0 && Rect.Height > 0)
                {
                    e.Graphics.FillRectangle(selectionBrush, Rect);
                }
            }
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
    }
}
