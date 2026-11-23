namespace Sentinel.Tests;

public class DetectionServiceTests
{
    private readonly DetectionService service = new();

    [Theory]
    [InlineData(200, 480, 96000)]
    [InlineData(350, 900, 315000)]
    [InlineData(1, 1, 1)]
    public void GetDetectionArea_ReturnsWidthTimesHeight(int width, int height, int expectedArea)
    {
        var detection = new Detection("person", 0.95, 320, 150, width, height);

        Assert.Equal(expectedArea, service.GetDetectionArea(detection));
    }

    [Theory]
    [InlineData(49999, DetectionSizeCategory.Small)]
    [InlineData(50000, DetectionSizeCategory.Medium)]
    [InlineData(50001, DetectionSizeCategory.Medium)]
    [InlineData(149999, DetectionSizeCategory.Medium)]
    [InlineData(150000, DetectionSizeCategory.Medium)]
    [InlineData(150001, DetectionSizeCategory.Large)]
    public void GetDetectionSizeCategory_ClassifiesAreaBoundaries(int area, DetectionSizeCategory expectedCategory)
    {
        var detection = new Detection("person", 0.95, 0, 0, area, 1);

        Assert.Equal(expectedCategory, service.GetDetectionSizeCategory(detection));
    }

    [Theory]
    [InlineData(0.8999, 0.90, false)]
    [InlineData(0.90, 0.90, true)]
    [InlineData(0.9001, 0.90, true)]
    [InlineData(0.74, 0.75, false)]
    [InlineData(0.75, 0.75, true)]
    [InlineData(0.0, 0.0, true)]
    [InlineData(1.0, 1.0, true)]
    public void IsDetectionApproved_UsesInclusiveConfidenceThreshold(double confidence, double threshold, bool expected)
    {
        var detection = new Detection("person", confidence, 0, 0, 200, 480);

        Assert.Equal(expected, service.IsDetectionApproved(detection, threshold));
    }

    [Theory]
    [InlineData(0.90, 150001, true)]
    [InlineData(0.95, 150001, true)]
    [InlineData(0.8999, 150001, false)]
    [InlineData(0.95, 150000, false)]
    [InlineData(0.95, 49999, false)]
    [InlineData(0.50, 49999, false)]
    public void IsHighPriorityDetection_RequiresApprovalAndLargeSize(double confidence, int area, bool expected)
    {
        var detection = new Detection("person", confidence, 0, 0, area, 1);

        Assert.Equal(expected, service.IsHighPriorityDetection(detection, 0.90));
    }
}
