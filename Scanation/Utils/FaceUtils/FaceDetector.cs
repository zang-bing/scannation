using Accord.Vision.Detection;
using Accord.Vision.Detection.Cascades;
using Scanation.Utils.FaceUtils.Types;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Scanation.Utils.FaceUtils
{
    internal class FaceDetector
    {
        private static HaarObjectDetector _detector = new HaarObjectDetector(new FaceHaarCascade());

        public static IEnumerable<Face> ExtractFaces(Bitmap picture, FaceDetectorParameters faceDetectorParameters) =>
            picture == null ?
            Enumerable.Empty<Face>() :
            ProcessFrame(picture, faceDetectorParameters).Select(rec => new Face(rec));

        private static IEnumerable<Rectangle> ProcessFrame(Bitmap picture, FaceDetectorParameters faceDetectorParameters)
        {
            _detector.MinSize = new Size(faceDetectorParameters.MinimumSize, faceDetectorParameters.MinimumSize);
            _detector.ScalingFactor = faceDetectorParameters.ScalingFactor;
            _detector.ScalingMode = faceDetectorParameters.ScalingMode;
            _detector.SearchMode = faceDetectorParameters.SearchMode;
            _detector.UseParallelProcessing = faceDetectorParameters.UseParallelProcessing;
            _detector.MaxSize = new Size(600, 600);
            _detector.Suppression = 2;
            return _detector.ProcessFrame(picture);
        }
    }
}
