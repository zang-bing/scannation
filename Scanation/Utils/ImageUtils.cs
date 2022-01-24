﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
    }
}