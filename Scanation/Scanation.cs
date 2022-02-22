using Scanation.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Scanation.Utils.FaceUtils;
using Scanation.Utils.FaceUtils.Types;
using Accord.Vision.Detection;
using System.Xml.Linq;
using Scanation.Extensions;

namespace Scanation
{
    public partial class Scanation : Form
    {
        // image
        private Bitmap _initialImage;

        private List<FrameSelection> _frames = new List<FrameSelection>();
        private int _initalFramePos = 10;
        public string url = "";

        // constants
        private const int FRAME_SIZE = 100;

        public Scanation(string id, string name, string url)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
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
            ImageUtils.Print(bitmap, printDevicesCb1.Text);
            ImageUtils.SaveToFile(bitmap);
        }

        private void PrintFrames()
        {
            foreach (var frame in _frames)
            {
                ImageUtils.Print(frame.SelectedBitmap, printDevicesCb1.Text);
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
            dpiTb1.Text = $"{Constants.MIN_DPI * 5}";
            dpiTb2.Text = $"{Constants.MIN_DPI * 5}";

            Bitmap bitmap = ImageUtils.FromUrl(url);
            _initialImage = (Bitmap)bitmap.Clone();
            pictureBox.Image = bitmap;
            var size = int.Parse(dpiTb1.Text);
            pictureBox.Image = ImageUtils.Resize(pictureBox.Image, size, size);

            EnableComponents();

            DetecFaces();
        }

        private void DetecFaces()
        {
            float ScaleFactor = 1.1f;
            int MinSize = 5;
            ObjectDetectorScalingMode ScaleMode = ObjectDetectorScalingMode.GreaterToSmaller;
            ObjectDetectorSearchMode SearchMode = ObjectDetectorSearchMode.Average;
            bool Parallel = true;
            FaceDetector.ExtractFaces(
                        new ImageProcessor((Bitmap)pictureBox.Image).Grayscale().EqualizeHistogram().Result,
                        FaceDetectorParameters.Create(ScaleFactor, MinSize, ScaleMode, SearchMode, Parallel))
                    .HasElements(pictureBox.Refresh)
                    .ForEach((face) =>
                    {
                        var sizableRect = new FrameSelection(face.FaceRectangle);
                        _initalFramePos += 10;
                        sizableRect.SetPictureBox(pictureBox);
                        _frames.Add(sizableRect);
                        pictureBox.Invalidate();
                    });
            if (_frames.Count > 0)
            {
                removeFrameBtn.Enabled = true;
            }
        }

        private void EnableComponents()
        {
            printDevicesCb1.Enabled = true;
            dpiTb1.Enabled = true;
            scanBtn.Enabled = true;
            preScanBtn.Enabled = true;
            addFrameBtn.Enabled = true;
            btnAddDrop2.Enabled = true;
            printDevicesCb2.Enabled = true;
            dpiTb2.Enabled = true;
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
            AddFrame(1);
        }

        private void AddFrame(int tab)
        {
            if (tab == 1 && _frames.Count < 1)
            {
                var sizableRect = new FrameSelection(new Rectangle(_initalFramePos, _initalFramePos, FRAME_SIZE, FRAME_SIZE));
                _initalFramePos += 10;
                sizableRect.SetPictureBox(pictureBox);
                _frames.Add(sizableRect);
                pictureBox.Invalidate();
            } 
            if (tab == 2)
            {
                var sizableRect = new FrameSelection(new Rectangle(_initalFramePos, _initalFramePos, FRAME_SIZE, FRAME_SIZE));
                _initalFramePos += 10;
                sizableRect.SetPictureBox(pictureBox);
                _frames.Add(sizableRect);
                pictureBox.Invalidate();
            }

            if (!removeFrameBtn.Enabled)
            {
                removeFrameBtn.Enabled = true;
            }
        }
        private void RemoveFrameBtn_Click(object sender, EventArgs e)
        {
            foreach(var frame in _frames)
            {
                if (frame.Selected)
                {
                    frame.Dispose();
                }
            }
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

        private void btnAddDrop2_Click(object sender, EventArgs e)
        {
            AddFrame(2);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            foreach (var frame in _frames)
            {
                frame.Dispose();
            }
            pictureBox.Invalidate();
            _frames.Clear();
            removeFrameBtn.Enabled = false;
            btnRemoveDrop2.Enabled = false;
        }
    }
}
