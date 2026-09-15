public class Detection
{
    public string Label {get; set;}
    public double Confidence {get; set;}
    public int X {get; set;}
    public int Y {get; set;}
    public int Width {get; set;}
    public int Height {get; set;}

    public Detection (
        string label,
        double confidence,
        int x,
        int y,
        int width,
        int height)
    {
        Label = label;
        Confidence = confidence;
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }
}


