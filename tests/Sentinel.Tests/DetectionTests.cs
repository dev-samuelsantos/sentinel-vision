namespace Sentinel.Tests;

public class DetectionTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(480)]
    public void Constructor_AcceptsPositiveHeight(int height)
    {
        var detection = new Detection("person", 0.95, 0, 0, 200, height);

        Assert.Equal(height, detection.Height);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    public void Constructor_RejectsNonPositiveHeight(int height)
    {
        Assert.Throws<ArgumentOutOfRangeException>(nameof(Detection.Height),
            () => new Detection("person", 0.95, 0, 0, 200, height));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(900)]
    public void Height_CanBeUpdatedToPositiveValue(int height)
    {
        var detection = new Detection("person", 0.95, 0, 0, 200, 480);

        detection.Height = height;

        Assert.Equal(height, detection.Height);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    public void Height_RejectsInvalidUpdateAndPreservesPreviousValue(int height)
    {
        var detection = new Detection("person", 0.95, 0, 0, 200, 480);

        Assert.Throws<ArgumentOutOfRangeException>(nameof(Detection.Height),
            () => detection.Height = height);
        Assert.Equal(480, detection.Height);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(200)]
    public void Constructor_AcceptsPositiveWidth(int width)
    {
        var detection = new Detection("person", 0.95, 0, 0, width, 480);

        Assert.Equal(width, detection.Width);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    public void Constructor_RejectsNonPositiveWidth(int width)
    {
        Assert.Throws<ArgumentOutOfRangeException>(nameof(Detection.Width),
            () => new Detection("person", 0.95, 0, 0, width, 480));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(350)]
    public void Width_CanBeUpdatedToPositiveValue(int width)
    {
        var detection = new Detection("person", 0.95, 0, 0, 200, 480);

        detection.Width = width;

        Assert.Equal(width, detection.Width);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    public void Width_RejectsInvalidUpdateAndPreservesPreviousValue(int width)
    {
        var detection = new Detection("person", 0.95, 0, 0, 200, 480);

        Assert.Throws<ArgumentOutOfRangeException>(nameof(Detection.Width),
            () => detection.Width = width);
        Assert.Equal(200, detection.Width);
    }

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
