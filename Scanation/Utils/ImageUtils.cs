using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Scanation.Utils
{
    public static class ImageUtils
    {
        public static Bitmap Resize(Image image, int targetWidth, int targetHeight)
        {
            Rectangle destRect = new Rectangle(0, 0, targetWidth, targetHeight);
            Bitmap destImage = new Bitmap(targetWidth, targetHeight);

            if (image != null)
            {
                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
                using (var g = Graphics.FromImage(destImage))
                {
                    g.CompositingMode = CompositingMode.SourceCopy;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    using (var wrapmode = new ImageAttributes())
                    {
                        wrapmode.SetWrapMode(WrapMode.TileFlipXY);
                        g.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapmode);
                    }
                }
                image.Dispose();
            }
            return destImage;
        }

        public static Bitmap CvResize(Bitmap bitmap, int targetWidth, int targetHeight)
        {
            if (bitmap != null)
            {
                var cvImage = bitmap.ToImage<Bgr, byte>();
                return cvImage.Resize(targetWidth, targetHeight, Emgu.CV.CvEnum.Inter.LinearExact).ToBitmap();
            }
            return null;
        }

        public static Bitmap FromUrl(string url)
        {
            var request = System.Net.WebRequest.Create(url);
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            Bitmap bitmap = new Bitmap(responseStream);
            return bitmap;
        }

        public static void Print(Bitmap bitmap)
        {
            var printDocument = new System.Drawing.Printing.PrintDocument();
            PrintDialog printDialog = new PrintDialog();
            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler((object _, System.Drawing.Printing.PrintPageEventArgs printEvt) =>
            {
                printEvt.Graphics.DrawImage(
                    bitmap,
                    (printEvt.PageBounds.Width - bitmap.Width) / 2,
                    (printEvt.PageBounds.Height - bitmap.Height) / 2);
            });
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
            printDocument.Dispose();
        }

        public static void SaveToFile(Bitmap bitmap)
        {
            if (!Directory.Exists(Constants.IMAGE_LOCATION))
            {
                Directory.CreateDirectory(Constants.IMAGE_LOCATION);
            }
            var fileName = string.Format(@"{0}.jpg", Guid.NewGuid());
            //bitmap.Save($"{Constants.IMAGE_LOCATION}\\{fileName}", ImageFormat.Jpeg);

            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream($"{Constants.IMAGE_LOCATION}\\{fileName}", FileMode.Create, FileAccess.ReadWrite))
                {
                    bitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
        }
    }
}
