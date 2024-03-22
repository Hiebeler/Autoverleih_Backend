namespace Autoverleih_Backend.Models;

public class Car
{
    public int Id { get; set; }
    public int Seats { get; set; }
    public string CarBrand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int TrunkSpace { get; set; }
    public CarTypes Type { get; set; }
}

public enum CarTypes
{
    Estate,
    Sedan,
    SUV,
    PickUp,
    Hatchback
} 