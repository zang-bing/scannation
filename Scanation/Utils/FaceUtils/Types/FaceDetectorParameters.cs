﻿using Accord.Vision.Detection;

namespace Scanation.Utils.FaceUtils.Types
{
    internal class FaceDetectorParameters
    {
        public float ScalingFactor { get; private set; }
        public ObjectDetectorScalingMode ScalingMode { get; private set; }
        public ObjectDetectorSearchMode SearchMode { get; private set; }
        public bool UseParallelProcessing { get; private set; }
        public int MinimumSize { get; private set; }

        public bool IsValid { get; private set; }
        public int Suppression { get; private set; }

        private FaceDetectorParameters(float scalingFactor, int minimumSize, ObjectDetectorScalingMode objectDetectorScalingMode,
            ObjectDetectorSearchMode objectDetectorSearchMode, bool useParallelProcessing, bool isValid, int suppression)
        {
            ScalingFactor = scalingFactor;
            MinimumSize = minimumSize;
            ScalingMode = objectDetectorScalingMode;
            SearchMode = objectDetectorSearchMode;
            UseParallelProcessing = useParallelProcessing;
            IsValid = isValid;
            Suppression = suppression;
        }

        public static FaceDetectorParameters Create(float scalingFactor, int minimumSize, ObjectDetectorScalingMode objectDetectorScalingMode,
            ObjectDetectorSearchMode objectDetectorSearchMode, bool useParallelProcessing, int suppression) =>
                new FaceDetectorParameters(scalingFactor, minimumSize, objectDetectorScalingMode, objectDetectorSearchMode, useParallelProcessing, true, suppression);
    }
}
