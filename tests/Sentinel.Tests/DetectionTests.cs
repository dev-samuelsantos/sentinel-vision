namespace Sentinel.Tests;

public class DetectionTests
{
    [Theory]
    [InlineData(0.0)]
    [InlineData(0.95)]
    [InlineData(1.0)]
    public void Constructor_AcceptsConfidenceWithinInclusiveRange(double confidence)
    {
        var detection = new Detection("person", confidence, 0, 0, 200, 480);

        Assert.Equal(confidence, detection.Confidence);
    }

    [Theory]
    [InlineData(-0.01)]
    [InlineData(1.01)]
    [InlineData(double.NaN)]
    [InlineData(double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity)]
    public void Constructor_RejectsInvalidConfidence(double confidence)
    {
        Assert.Throws<ArgumentOutOfRangeException>(nameof(Detection.Confidence),
            () => new Detection("person", confidence, 0, 0, 200, 480));
    }

    [Theory]
    [InlineData(0.0)]
    [InlineData(0.95)]
    [InlineData(1.0)]
    public void Confidence_CanBeUpdatedToValidValue(double confidence)
    {
        var detection = new Detection("person", 0.5, 0, 0, 200, 480);

        detection.Confidence = confidence;

        Assert.Equal(confidence, detection.Confidence);
    }

    [Theory]
    [InlineData(-0.01)]
    [InlineData(1.01)]
    [InlineData(double.NaN)]
    [InlineData(double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity)]
    public void Confidence_RejectsInvalidUpdateAndPreservesPreviousValue(double confidence)
    {
        var detection = new Detection("person", 0.95, 0, 0, 200, 480);

        Assert.Throws<ArgumentOutOfRangeException>(nameof(Detection.Confidence),
            () => detection.Confidence = confidence);
        Assert.Equal(0.95, detection.Confidence);
    }
}
