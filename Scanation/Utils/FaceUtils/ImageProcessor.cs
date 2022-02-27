using System.Drawing;
using Accord.Imaging.Filters;

namespace Scanation.Utils.FaceUtils
{
    internal class ImageProcessor
    {
        public Bitmap Result { get; private set; }

        public ImageProcessor(Bitmap bitmap)
        {
            Result = bitmap;
        }
        internal ImageProcessor GrayScale()
        {
            var grayScale = new Grayscale(0.2125, 0.7154, 0.0721);
            Result = grayScale.Apply(Result);
            return this;
        }

        internal ImageProcessor EqualizeHistogram()
        {
            var filter = new HistogramEqualization();
            filter.ApplyInPlace(Result);
            return this;
        }

        internal ImageProcessor Resize(Size size)
        {
            Result = new Bitmap(Result, size);
            return this;
        }
    }
}
