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
using System.IO;

namespace Scanation
{
    public partial class Scanation : Form
    {
        // image
        private Bitmap _initialImage;

        private List<FrameSelection> _frames = new List<FrameSelection>();
        private int _initalFramePos = 10;
        public string url = "";
        public bool status = false;
        public string token = "";

        // constants
        private const int FRAME_SIZE = 100;
        private int CURRENT_TAB = 0;
        private LongOperation _longOperation;

        private TypeAssistant _dpiChangeAssistant;

        public Scanation(string id, string name, string token, string url)
        {
            InitializeComponent();
            InitializeOthers();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            textBoxId.Text = id;
            textBoxId2.Text = id;
            textBoxName.Text = name;
            textBoxName2.Text = name;
            this.token = token;
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
            try
            {
                _longOperation = new LongOperation(this, LongOperationSettings.Default);
                var listDevices = System.Drawing.Printing.PrinterSettings.InstalledPrinters.Cast<string>().ToList();

                printDevicesCb1.DataSource = listDevices;
                printDevicesCb2.DataSource = listDevices;
                const int initialDpi = Constants.MIN_DPI * 20;
                dpiTb1.Text = $@"{initialDpi}";
                dpiTb2.Text = $@"{initialDpi}";

                _dpiChangeAssistant = new TypeAssistant();
                _dpiChangeAssistant.Idled += (sender, args) =>
                {
                    this.Invoke(new MethodInvoker(async () =>
                    {
                        if (pictureBox.Image == null) return;
                        var text = CURRENT_TAB == 0 ? dpiTb1.Text : dpiTb2.Text;
                        var check = int.TryParse(text, out var size);
                        if (!check || size < Constants.MIN_DPI || size > Constants.MAX_DPI)
                        {
                            size = pictureBox.ClientSize.Width;
                        }

                        var newImage = ImageUtils.Resize(new Bitmap(_initialImage), size, size);
                        if (newImage == null) return;
                        pictureBox.Image = newImage;
                        ClearFrames();
                        await DetectFaces();
                    }));
                };
            } catch (Exception ex) { }
            
        }

        private async void OnScanBtn_Click(object sender, EventArgs e)
        {
            var printerName = printDevicesCb1.Text;
            using (_longOperation.Start())
            {
                if (_frames.Count > 0)
                {
                    await PrintFrames(printerName);
                } else
                {
                    PrintPicture(printerName);
                }
            }
        }

        private void PrintPicture(string printerName)
        {
            var width = pictureBox.Image.Width;
            var height = pictureBox.Image.Height;
            var bitmap = new Bitmap(width, height);
            pictureBox.DrawToBitmap(bitmap, new Rectangle(0, 0, width, height));
            ImageUtils.Print(bitmap, printerName);
            ImageUtils.SaveToFile(bitmap, token);
        }

        private async Task PrintFrames(string printerName)
        {
            await Task.Run(() =>
            {
                foreach (var frame in _frames)
                {
                    ImageUtils.Print(frame.SelectedBitmap, printerName);
                    ImageUtils.SaveToFile(frame.SelectedBitmap, token);
                }
            });
        }

        private async void PreviewBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFrames();
                previewBtn.Enabled = false;
                var bitmap = await ImageUtils.FromUrl(url);
                _initialImage = (Bitmap)bitmap.Clone();
                var text = CURRENT_TAB == 0 ? dpiTb1.Text : dpiTb2.Text;
                var check = int.TryParse(text, out var size);
                if (CURRENT_TAB == 0)
                {
                    if (!check || size < Constants.MIN_DPI || size > Constants.MAX_DPI)
                    {
                        size = pictureBox.ClientSize.Width;
                    }
                    pictureBox.Invoke(new MethodInvoker(() =>
                    {
                        pictureBox.Image = ImageUtils.Resize(bitmap, size, size);
                    }));
                } else
                {
                    if (!check || size < Constants.MIN_DPI || size > Constants.MAX_DPI)
                    {
                        size = pictureBox.ClientSize.Width;
                    }
                    pictureBox.Invoke(new MethodInvoker(() =>
                    {
                        pictureBox.Image = ImageUtils.Resize(bitmap, size, size);
                    }));
                }
                
                EnableComponents();
                await DetectFaces();
                previewBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("image not found");
                previewBtn.Enabled = true;
            }

        }

        private async Task DetectFaces()
        {
            try
            {
                ClearFrames();
                await Task.Run(() =>
                {
                    var scaleFactor = 1.1f;
                    var minSize = 5;
                    var scaleMode = ObjectDetectorScalingMode.GreaterToSmaller;
                    var searchMode = ObjectDetectorSearchMode.Average;
                    var parallel = true;
                    var suppression = 5;

                    if (int.Parse(dpiTb1.Text) > 2000) suppression = 4;
                    if (int.Parse(dpiTb2.Text) > 2000) suppression = 4;
                    if (int.Parse(dpiTb2.Text) >= Constants.MAX_DPI) suppression = 5;
                    pictureBox.Invoke(new MethodInvoker(() =>
                    {
                        var faces = FaceDetector.ExtractFaces(
                                new ImageProcessor((Bitmap)pictureBox.Image).GrayScale().EqualizeHistogram().Result,
                                FaceDetectorParameters.Create(scaleFactor, minSize, scaleMode, searchMode, parallel, suppression))
                            .HasElements(pictureBox.Refresh);

                        for (int i = 0; i < faces.Count(); i++)
                        {
                            if (CURRENT_TAB == 0 && _frames.Count != 1 && i == 2)
                            {
                                if (faces.ElementAt(i).FaceRectangle.Width < 30) return;
                                var sizableRect = new FrameSelection(faces.ElementAt(i).FaceRectangle);
                                _initalFramePos += 10;
                                sizableRect.SetPictureBox(pictureBox);
                                _frames.Add(sizableRect);
                                pictureBox.Invalidate();
                            }
                            if (CURRENT_TAB == 1)
                            {
                                if (faces.ElementAt(i).FaceRectangle.Width < 30) return;
                                var sizableRect = new FrameSelection(faces.ElementAt(i).FaceRectangle);
                                _initalFramePos += 10;
                                sizableRect.SetPictureBox(pictureBox);
                                _frames.Add(sizableRect);
                                pictureBox.Invalidate();
                            }
                        }

                        if (_frames.Count > 0)
                        {
                            removeFrameBtn.Enabled = true;
                            btnRemoveDrop2.Enabled = true;
                        }
                    }));
                });
            } catch (Exception ex) { }

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
            btnAccept.Enabled = true;
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
            Console.WriteLine(_frames.Count);
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

            if (!removeFrameBtn.Enabled || !btnRemoveDrop2.Enabled)
            {
                removeFrameBtn.Enabled = true;
                btnRemoveDrop2.Enabled = true;
            }
        }
        private void RemoveFrameBtn1_Click(object sender, EventArgs e)
        {
            FrameSelection currentFrame = null;
            foreach (var frame in _frames.Where(frame => frame.Selected))
            {
                frame.Dispose();
                currentFrame = frame;
            }
            pictureBox.Invalidate();

            if (currentFrame != null) _frames.Remove(currentFrame);
            

            if (_frames.Count <= 0)
            {
                removeFrameBtn.Enabled = false;
            }
        }

        private void RemoveFrameBtn2_Click(object sender, EventArgs e)
        {
            _frames.RemoveAll(frame =>
            {
                var selected = frame.Selected;
                if (selected) frame.Dispose();
                return selected;
            });
            pictureBox.Invalidate();

            if (_frames.Count <= 0)
            {
                btnRemoveDrop2.Enabled = false;
                btnAddDrop2.Focus();
            }
        }

        private void PreScanBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var images = _frames.Select(frame => frame.SelectedBitmap).ToList();
                var preScanForm = new PrescanForm(images);
                preScanForm.Show();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        private void DpiTb1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dpiTb1.Text == "") return;
                _dpiChangeAssistant?.TextChanged();
                dpiTb2.Text = dpiTb1.Text;
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            
        }

        private void DpiTb2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dpiTb2.Text == "") return;
                _dpiChangeAssistant?.TextChanged();
                dpiTb1.Text = dpiTb2.Text;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        private void DpiTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void BtnAddDrop2_Click(object sender, EventArgs e)
        {
            AddFrame(2);
        }

        private async void TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            CURRENT_TAB = tabControl1.SelectedIndex;
            ClearFrames();
            removeFrameBtn.Enabled = false;
            btnRemoveDrop2.Enabled = false;

            if (_initialImage != null)
            {
                await DetectFaces();
            }

            if (CURRENT_TAB == 0) dpiTb1.Text = dpiTb2.Text;

            if (CURRENT_TAB == 1) dpiTb2.Text = dpiTb1.Text;

            if (_frames.Count > 0)
            {
                removeFrameBtn.Enabled = true;
                btnRemoveDrop2.Enabled = true;
            }
        }

        private void ClearFrames()
        {
            foreach (var frame in _frames)
            {
                frame.Dispose();
            }
            _frames.Clear();
            pictureBox.Invalidate();
        }

        private async void chooseFie()
        {
            status = true;
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "" +
                    "jpg files (*.jpg)|*.jpg|" +
                    "jpeg files (*.jpeg)|*.jpeg|" +
                    "png files (*.png)|*.png|" +
                    "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            var bitmap = await ImageUtils.FromPC(filePath);
            _initialImage = (Bitmap)bitmap.Clone();
            //pictureBox.Image = bitmap;
            var size = int.Parse(dpiTb1.Text);
            pictureBox.Invoke(new MethodInvoker(() =>
            {
                pictureBox.Image = ImageUtils.Resize(bitmap, size, size);
            }));

            EnableComponents();
            await DetectFaces();
            previewBtn.Enabled = true;
        }

        private void btnChooseFile2_Click_1(object sender, EventArgs e)
        {
            chooseFie();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            chooseFie();
        }
    }
}
