public class DetectionService
{
    public int GetDetectionArea (Detection detection)
    {
        return detection.Width * detection.Height;
    }
    
    public DetectionSizeCategory GetDetectionSizeCategory(Detection detection)
    {   
        int  area = GetDetectionArea(detection);

        if (area < 50000)
        {
            return DetectionSizeCategory.Small;
        }
        else if (area <= 150000)
        {
            return DetectionSizeCategory.Medium;
        }
        else
        {
            return DetectionSizeCategory.Large;
        }
    }
    public bool IsDetectionApproved(Detection detection, double confidenceThreshold)
    {
        return detection.Confidence >= confidenceThreshold;
    }

    public bool IsHighPriorityDetection(Detection detection, double confidenceThreshold)
    {
        return IsDetectionApproved(detection, confidenceThreshold) && GetDetectionSizeCategory(detection) == DetectionSizeCategory.Large;

    }
}