Console.WriteLine("Sentinel iniciado");

double confidenceThreshold = 0.90;
int approvedCount = 0;
int rejectedCount = 0;

List<Detection> detections = new List<Detection>();

detections.Add(
    new Detection("car", 0.60, 750, 400, 430, 220)
);
detections.Add(
    new Detection("person", 0.91, 320, 150, 200, 480)
);
detections.Add(
    new Detection("horse", 0.95, 300, 200, 350, 900)
);
detections.Add(
    new Detection("super human", 0.99, 400, 150, 600, 800)
);
detections.Add(
    new Detection("criminal", 0.30, 100, 200, 450, 300)
);

void PrintDetection (Detection detection)
{
    Console.WriteLine($"Objeto: {detection.Label} ");
    Console.WriteLine($"Confiança: {detection.Confidence}");
    Console.WriteLine($"Posição: X:{detection.X} Y:{detection.Y}");
    Console.WriteLine($"Tamanho: {detection.Width} x {detection.Height}");
    Console.WriteLine($"Área: {GetDetectionArea(detection)} pixels²");
    Console.WriteLine($"Categoria de tamanho: {GetDetectionSizeCategory(detection)}");
    Console.WriteLine();
}

bool IsDetectionApproved(Detection detection, double confidenceThreshold)
{
    return detection.Confidence >= confidenceThreshold;
}

int GetDetectionArea(Detection detection)
{
    return detection.Width * detection.Height;
}

DetectionSizeCategory GetDetectionSizeCategory(Detection detection)
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

foreach (Detection detection in detections)
{
        if (IsDetectionApproved (detection, confidenceThreshold))  {
            approvedCount++;
            PrintDetection(detection);
    }
        else
    {
            rejectedCount++;  
            Console.WriteLine("A detecção rejeitada foi: " + detection.Label);
    }
}

Console.WriteLine("Contabilidade de detecções aprovadas: " + approvedCount);    
Console.WriteLine("Contabilidade de detecções rejeitadas: " + rejectedCount);