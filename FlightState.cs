using System;

public class FlightData
{
    public long Time { get; set; }
    public List<FlightState> States { get; set; }
}

[System.Serializable]
public class FlightState
{
    public string Aircraft { get; set; }
    public string FlightNumber { get; set; }
    public string Country { get; set; }
    public long Time { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public double Altitude { get; set; }
    public bool IsOnGround { get; set; }
    public double Speed { get; set; }
    public double Heading { get; set; }
    public double VerticalRate { get; set; }
    public object? Squawk { get; set; }
    public double? Spi { get; set; }
    public string? PositionSource { get; set; }
    public bool? IsMlat { get; set; }
    public int? ArrivalTime { get; set; }
}
