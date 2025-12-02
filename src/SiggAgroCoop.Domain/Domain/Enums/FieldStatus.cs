namespace SiggAgroCoop.Domain.Enums;

public enum FieldStatus
{
    Idle = 0,       // No crop currently in process
    Planting = 1,   // Field is in planting process
    Growing = 2,    // Crop is growing (optional, futuro)
    Harvest = 3     // Field is in harvest process
}
