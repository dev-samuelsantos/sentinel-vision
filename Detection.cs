public class Detection
{
    public string Label {get; set;}
    private double confidence;

    public double Confidence
    {
        get => confidence;
        set
        {
            if (!double.IsFinite(value) || value < 0 || value > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(Confidence), value,
                    "A confiança deve ser um número finito entre 0 e 1.");
            }

            confidence = value;
        }
    }
    public int X {get; set;}
    public int Y {get; set;}
    private int width;

    public int Width
    {
        get => width;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Width), value,
                    "A largura deve ser maior que zero.");
            }

            width = value;
        }
    }
    private int height;

    public int Height
    {
        get => height;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Height), value,
                    "A altura deve ser maior que zero.");
            }

            height = value;
        }
    }
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


