﻿namespace BicycleRentals.Domain;
/// <summary>
/// Bicycle - a class describing the bicycle
/// </summary> 
public class Bicycle
{
    /// <summary>
    /// SerialNumber - shows the Bicycle's id
    /// </summary>  
    public int SerialNumber { get; set; }
    /// <summary>
    /// TypeId - shows the Type's id
    /// </summary>  
    public int TypeId { get; set; }
    /// <summary>
    /// Model - shows the Bicycle's model
    /// </summary>     
    public string? Model { get; set; }
    /// <summary>
    /// Color - shows the Bicycle's color
    /// </summary> 
    public string? Color { get; set; }
    /// <summary>
    /// Rentals - shows the Rentals 
    /// </summary>
    public List<BicycleRental> Rentals { get; set; } = new List<BicycleRental>();
}