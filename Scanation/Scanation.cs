using Scanation.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scanation.Utils.FaceUtils;
using Scanation.Utils.FaceUtils.Types;
using Accord.Vision.Detection;
using LoadingIndicator.WinForms;

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
        private int CURRENT_TAB = 1;
        private LongOperation _longOperation;

        public Scanation(string id, string name, string url)
        {
            InitializeComponent();
            InitializeOthers();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            textBoxId.Text = id;
            textBoxName.Text = name;
            this.url = "http://" + url;
        }

        public Scanation(string url)
        {
            InitializeComponent();
            InitializeOthers();
            this.url = "http://" + url;
        }

        private void InitializeOthers()
        {
            _longOperation = new LongOperation(this, LongOperationSettings.Default);
        }

        private void OnScanBtn_Click(object sender, EventArgs e)
        {
            if (_frames.Count > 0)
            {
                PrintFrames();
                return;
            }
            PrintPicture();
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

        private async void PreviewBtn_Click(object sender, EventArgs e)
        {
            using (_longOperation.Start())
            {
                previewBtn.Enabled = false;
                await Task.Run(async () =>
                {
                    var listDevices = System.Drawing.Printing.PrinterSettings.InstalledPrinters.Cast<string>().ToList();

                    printDevicesCb1.DataSource = listDevices;
                    printDevicesCb2.DataSource = listDevices;
                    dpiTb1.Text = $@"{Constants.MIN_DPI * 5}";
                    dpiTb2.Text = $@"{Constants.MIN_DPI * 5}";

                    var bitmap = await ImageUtils.FromUrl(url);
                    _initialImage = (Bitmap) bitmap.Clone();
                    pictureBox.Image = bitmap;
                    var size = int.Parse(dpiTb1.Text);
                    pictureBox.Image = ImageUtils.Resize(pictureBox.Image, size, size);

                    EnableComponents();
                });

                await DetectFaces();
                previewBtn.Enabled = true;
            }
        }

        private async Task DetectFaces()
        {
            await Task.Run(() =>
            {
                var scaleFactor = 1.1f;
                var minSize = 5;
                var scaleMode = ObjectDetectorScalingMode.GreaterToSmaller;
                var searchMode = ObjectDetectorSearchMode.Average;
                var parallel = true;
                FaceDetector.ExtractFaces(
                        new ImageProcessor((Bitmap)pictureBox.Image).Grayscale().EqualizeHistogram().Result,
                        FaceDetectorParameters.Create(scaleFactor, minSize, scaleMode, searchMode, parallel))
                    .HasElements(pictureBox.Refresh)
                    .ForEach((face) =>
                    {
                        if (face._selectionRectangle.Width <= 30 || face._selectionRectangle.Height <= 30) return;
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
            });
        }

        private void EnableComponents()
        {
            printDevicesCb1.Enabled = true;
            dpiTb1.Enabled = true;
            scanBtn.Enabled = true;
            preScanBtn.Enabled = true;
            addFrameBtn.Enabled = true;
            btnAddDrop2.Enabled = true;
            btnRemoveDrop2.Enabled = true;
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
                btnRemoveDrop2.Enabled = true;
            }
        }
        private void RemoveFrameBtn_Click(object sender, EventArgs e)
        {
            FrameSelection currentFrame = null;
            foreach(var frame in _frames)
            {
                if (frame.Selected)
                {
                    frame.Dispose();
                    currentFrame = frame;
                }
            }
            pictureBox.Invalidate();

            if (currentFrame != null) _frames.Remove(currentFrame);

            if (_frames.Count <= 0)
            {
                removeFrameBtn.Enabled = false;
            }
        }

        private void PreScanBtn_Click(object sender, EventArgs e)
        {
            var images = _frames.Select(frame => frame.SelectedBitmap).ToList();
            var preScanForm = new PrescanForm(images);
            preScanForm.Show();
        }

        private async void DpiTb_TextChanged(object sender, EventArgs e)
        {
            using (_longOperation.Start())
            {
                if (pictureBox.Image == null) return;
                var check = int.TryParse(dpiTb1.Text, out var size);
                if (!check) return;
                if (size < Constants.MIN_DPI || size > Constants.MAX_DPI)
                {
                    return;
                }
                var newImage = ImageUtils.Resize(new Bitmap(_initialImage), size, size);
                if (newImage == null) return;
                pictureBox.Image = newImage;
                ClearFrames();
                await DetectFaces();
            }
        }

        private void DpiTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void BtnAddDrop2_Click(object sender, EventArgs e)
        {
            AddFrame(2);
        }

        private async void TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            using (_longOperation.Start())
            {
                await Task.Run(() =>
                {
                    CURRENT_TAB = tabControl1.SelectedIndex;
                    foreach (var frame in _frames)
                    {
                        frame.Dispose();
                    }

                    pictureBox.Invalidate();
                    _frames.Clear();
                    removeFrameBtn.Enabled = false;
                    btnRemoveDrop2.Enabled = false;
                });

                if (_initialImage != null)
                {
                    await DetectFaces();
                }
            }
        }

        private void BtnRemoveDrop2_Click(object sender, EventArgs e)
        {
            FrameSelection currentFrame = null;
            foreach (var frame in _frames)
            {
                if (frame.Selected)
                {
                    frame.Dispose();
                    currentFrame = frame;
                }
            }
            pictureBox.Invalidate();

            if (currentFrame != null) _frames.Remove(currentFrame);

            if (_frames.Count <= 0)
            {
                removeFrameBtn.Enabled = false;
            }
        }

        private void ClearFrames()
        {
            foreach (var frame in _frames)
            {
                
                frame.Dispose();
            }
            pictureBox.Invalidate();
        }
    }
}
