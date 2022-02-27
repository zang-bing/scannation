using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Scanation.Utils
{
    public static class ImageUtils
    {
        public static Bitmap Resize(Image image, int targetWidth, int targetHeight)
        {
            var destRect = new Rectangle(0, 0, targetWidth, targetHeight);
            var destImage = new Bitmap(targetWidth, targetHeight);

            if (image == null) return destImage;

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var g = Graphics.FromImage(destImage))
            {
                g.CompositingMode = CompositingMode.SourceCopy;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    g.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            image.Dispose();
            return destImage;
        }

        public static Bitmap CvResize(Bitmap bitmap, int targetWidth, int targetHeight)
        {
            var cvImage = bitmap?.ToImage<Bgr, byte>();
            return cvImage?.Resize(targetWidth, targetHeight, Emgu.CV.CvEnum.Inter.LinearExact).ToBitmap();
        }

        public static async Task<Bitmap> FromUrl(string url)
        {
            var request = System.Net.WebRequest.Create(url);
            var response = await request.GetResponseAsync();
            var responseStream = response.GetResponseStream();

            if (responseStream == null) return null;
            var bitmap = new Bitmap(responseStream);
            return bitmap;
        }

        public static void Print(Bitmap bitmap, string printerName)
        {
            try
            {
                var printDocument = new PrintDocument();
                if (printDocument.PrinterSettings.IsValid)
                {
                    PrintController printController = new StandardPrintController();
                    printDocument.PrintController = printController;
                    printDocument.PrinterSettings.PrinterName = printerName;

                    var unixTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

                    printDocument.DocumentName = unixTimestamp.ToString();

                   /* if (printerName == "Microsoft Print to PDF") {
                        printDocument.PrinterSettings.PrintFileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + printerName + ".pdf";
                    }*/

                    printDocument.PrintPage += (_, printEvt) =>
                    {
                        printEvt.Graphics.DrawImage(
                            bitmap,
                            (printEvt.PageBounds.Width - bitmap.Width) / 2,
                            (printEvt.PageBounds.Height - bitmap.Height) / 2);
                    };
                    printDocument.Print();
                    printDocument.Dispose();
                }
                else
                {
                    MessageBox.Show("Printer is not valid");
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public static void SaveToFile(Bitmap bitmap)
        {
            try
            {
                if (bitmap == null) return;
                if (!Directory.Exists(Constants.IMAGE_LOCATION))
                {
                    Directory.CreateDirectory(Constants.IMAGE_LOCATION);
                }
                var fileName = $@"{Guid.NewGuid()}.jpg";
                //bitmap.Save($"{Constants.IMAGE_LOCATION}\\{fileName}", ImageFormat.Jpeg);

                using (var memory = new MemoryStream())
                {
                    using (var fs = new FileStream($"{Constants.IMAGE_LOCATION}\\{fileName}", FileMode.Create, FileAccess.ReadWrite))
                    {
                        bitmap.Save(memory, ImageFormat.Jpeg);
                        var bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex);
            }
            
        }
    }
}
